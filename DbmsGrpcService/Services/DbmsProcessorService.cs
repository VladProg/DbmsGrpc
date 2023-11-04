using DBMS.Models;
using DbmsGrpc;
using DbmsGrpc.Messages;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System.Reflection;
using System.Xml.Linq;

namespace DbmsGrpc.Services
{
    public class DbmsProcessorService : DbmsProcessor.DbmsProcessorBase
    {
        readonly Dictionary<string, Database> databases = new();

        private Database GetFullDatabase(string dbName)
        {
            if (!databases.ContainsKey(dbName))
                throw new RpcException(new Status(StatusCode.NotFound, $"Cannot find database '{dbName}'"));
            return databases[dbName];
        }

        private DBMS.Models.Table GetTable(string dbName, int tableId)
        {
            var ids = DBMS.Models.TableDifference.ParseId(tableId);
            if (ids.HasValue)
                return GetTableDifference(dbName, ids.Value.leftId, ids.Value.rightId);
            Database database = GetFullDatabase(dbName);
            if (!database.Tables.ContainsKey(tableId))
                throw new RpcException(new Status(StatusCode.NotFound, $"Database '{dbName}' doesn't contain table #{tableId}"));
            return database.Tables[tableId];
        }

        private DBMS.Models.Table GetTableDifference(string dbName, int leftTableId, int rightTableId)
        {
            DBMS.Models.Table leftTable = GetTable(dbName, leftTableId);
            DBMS.Models.Table rightTable = GetTable(dbName, rightTableId);
            DBMS.Models.TableDifference difference = DBMS.Models.TableDifference.Create(leftTable, rightTable);
            difference.Calculate();
            return difference;
        }

        public override Task<Empty> CreateDatabase(DbNameRequest request, ServerCallContext context)
        {
            if (databases.ContainsKey(request.DbName))
                throw new RpcException(new Status(StatusCode.AlreadyExists, $"Database '{request.DbName}' already exists"));
            else
                databases[request.DbName] = new Database();
            return Task.FromResult(new Empty());
        }

        public override Task<DatabaseInfo> GetDatabase(DbNameRequest request, ServerCallContext context)
        {
            return Task.FromResult(GetFullDatabase(request.DbName).ToMessageInfo());
        }

        public override Task<Empty> DeleteDatabase(DbNameRequest request, ServerCallContext context)
        {
            if (databases.ContainsKey(request.DbName))
                databases.Remove(request.DbName);
            else
                throw new RpcException(new Status(StatusCode.NotFound, $"Cannot find database '{request.DbName}'"));
            return Task.FromResult(new Empty());
        }

        public override Task<TableIdResponse> AddTable(AddTableRequest request, ServerCallContext context)
        {
            Database database = GetFullDatabase(request.DbName);
            DBMS.Models.Column[] columns = (from column in request.Columns select new DBMS.Models.Column(column.Name, DBMS.Models.Types.Type.FromMessage(column.Type))).ToArray();
            int id = database.AddTable(request.TableName, columns).Id;
            return Task.FromResult(new TableIdResponse() { TableId = id });
        }

        public override Task<Empty> RemoveTable(TableReferenceRequest request, ServerCallContext context)
        {
            Database database = GetFullDatabase(request.DbName);
            database.RemoveTable(request.TableId);
            return Task.FromResult(new Empty());
        }

        public override Task<Messages.Table> GetTable(TableReferenceRequest request, ServerCallContext context)
        {
            return Task.FromResult(GetTable(request.DbName, request.TableId).ToMessage());
        }

        public override Task<RowIdResponse> AddRow(AddRowRequest request, ServerCallContext context)
        {
            DBMS.Models.Table table = GetTable(request.DbName, request.TableId);
            if (request.Cells.Count != table.Columns.Count)
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Row length must be the same as number of columns"));
            DBMS.Models.Values.Value[] values = new DBMS.Models.Values.Value[request.Cells.Count];
            try
            {
                for (int i = 0; i < request.Cells.Count; i++)
                    values[i] = table.Columns[i].Type.Parse(request.Cells[i]);
                int id = table.AddRow(values).Id;
                return Task.FromResult(new RowIdResponse() { RowId = id });
            }
            catch (Exception e)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, e.Message));
            }
        }

        public override Task<Empty> RemoveRow(RowReferenceRequest request, ServerCallContext context)
        {
            DBMS.Models.Table table = GetTable(request.DbName, request.TableId);
            try
            {
                table.RemoveRow(request.RowId);
            }
            catch (Exception e)
            {
                throw new RpcException(new Status(StatusCode.NotFound, e.Message));
            }
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> ValidateCell(CellReferenceRequest request, ServerCallContext context)
        {
            DBMS.Models.Table table = GetTable(request.DbName, request.TableId);
            try
            {
                table.Columns[request.ColumnId].Type.Parse(request.Value);
            }
            catch (Exception e)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, e.Message));
            }
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> UpdateCell(UpdateCellRequest request, ServerCallContext context)
        {
            DBMS.Models.Table table = GetTable(request.DbName, request.TableId);
            try
            {
                table.Rows[request.RowId].Cells[request.ColumnId] = table.Columns[request.ColumnId].Type.Parse(request.Value);
            }
            catch (Exception e)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, e.Message));
            }
            return Task.FromResult(new Empty());
        }

        public override Task<Messages.Table> GetTableDifference(TableDifferenceRequest request, ServerCallContext context)
        {
            try
            {
                return Task.FromResult(GetTableDifference(request.DbName, request.LeftTableId, request.RightTableId).ToMessage());
            }
            catch (Exception e)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, e.Message));
            }
        }

        public override Task<TableExistsResponse> TableExists(TableReferenceRequest request, ServerCallContext context)
        {
            try
            {
                GetTable(request.DbName, request.TableId);
                return Task.FromResult(new TableExistsResponse { Exists = true });
            }
            catch
            {
                return Task.FromResult(new TableExistsResponse { Exists = false });
            }
        }

    }
}