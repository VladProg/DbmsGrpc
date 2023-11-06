from concurrent import futures
import grpc
import google.protobuf.empty_pb2
from grpc_interceptor import ServerInterceptor
from grpc_interceptor.exceptions import GrpcException

from Protos import DbmsGrpc_pb2, DbmsGrpc_pb2_grpc, Messages_pb2
import Models


class DbmsProcessorServicer(DbmsGrpc_pb2_grpc.DbmsProcessorServicer):

    def __init__(self):
        self.databases = {}

    def _get_full_database(self, dbName, context):
        if dbName not in self.databases:
            context.abort(grpc.StatusCode.NOT_FOUND, f"Cannot find database '{dbName}'")
        return self.databases[dbName]

    def _get_full_table(self, dbName, tableId, context):
        ids = Models.TableDifference.parse_id(tableId)
        if ids is not None:
            return self._get_full_table_difference(dbName, ids[0], ids[1], context)
        database = self._get_full_database(dbName, context)
        if tableId not in database.tables:
            context.abort(grpc.StatusCode.NOT_FOUND, f"Database '{dbName}' doesn't contain table #{tableId}")
        return database.tables[tableId]

    def _get_full_table_difference(self, dbName, leftTableId, rightTableId, context):
        leftTable = self._get_full_table(dbName, leftTableId, context)
        rightTable = self._get_full_table(dbName, rightTableId, context)
        difference = Models.TableDifference.create(leftTable, rightTable)
        difference.calculate()
        return difference

    def CreateDatabase(self, request, context):
        if request.DbName in self.databases:
            context.abort(grpc.StatusCode.ALREADY_EXISTS, f"Database '{request.DbName}' already exists")
        else:
            database = Models.Database()
            database.add_table('Python', [])
            self.databases[request.DbName] = database
        return google.protobuf.empty_pb2.Empty()

    def GetDatabase(self, request, context):
        return self._get_full_database(request.DbName, context).to_message_info()

    def DeleteDatabase(self, request, context):
        if request.DbName in self.databases:
            del self.databases[request.DbName]
        else:
            context.abort(grpc.StatusCode.NOT_FOUND, f"Cannot find database '{request.DbName}'")
        return google.protobuf.empty_pb2.Empty()

    def AddTable(self, request, context):
        database = self._get_full_database(request.DbName, context)
        columns = [Models.Column(column.Name, Models.Types.Type.from_message(column.Type)) for column in
                   request.Columns]
        id = database.add_table(request.TableName, columns).id
        return DbmsGrpc_pb2.TableIdResponse(TableId=id)

    def RemoveTable(self, request, context):
        database = self._get_full_database(request.DbName, context)
        database.remove_table(request.TableId)
        return google.protobuf.empty_pb2.Empty()

    def GetTable(self, request, context):
        return self._get_full_table(request.DbName, request.TableId, context).to_message()

    def AddRow(self, request, context):
        table = self._get_full_table(request.DbName, request.TableId, context)
        if len(request.Cells) != len(table.columns):
            context.abort(grpc.StatusCode.INVALID_ARGUMENT, "Row length must be the same as number of columns")
        values = []
        try:
            for i in range(len(request.Cells)):
                values.append(table.columns[i].type.parse(request.Cells[i]))
            id = table.add_row(values).id
            return DbmsGrpc_pb2.RowIdResponse(RowId=id)
        except Exception as e:
            context.abort(grpc.StatusCode.INVALID_ARGUMENT, str(e))

    def RemoveRow(self, request, context):
        table = self._get_full_table(request.DbName, request.TableId, context)
        try:
            table.remove_row(request.RowId)
        except Exception as e:
            context.abort(grpc.StatusCode.NOT_FOUND, str(e))
        return google.protobuf.empty_pb2.Empty()

    def ValidateCell(self, request, context):
        table = self._get_full_table(request.DbName, request.TableId, context)
        try:
            table.columns[request.ColumnId].type.parse(request.Value)
        except Exception as e:
            context.abort(grpc.StatusCode.INVALID_ARGUMENT, str(e))
        return google.protobuf.empty_pb2.Empty()

    def UpdateCell(self, request, context):
        table = self._get_full_table(request.DbName, request.TableId, context)
        try:
            table.rows[request.RowId].cells[request.ColumnId] = table.columns[request.ColumnId].type.parse(
                request.Value)
        except Exception as e:
            context.abort(grpc.StatusCode.INVALID_ARGUMENT, str(e))
        return google.protobuf.empty_pb2.Empty()

    def GetTableDifference(self, request, context):
        try:
            return self._get_full_table_difference(request.DbName, request.LeftTableId, request.RightTableId,
                                                   context).to_message()
        except Exception as e:
            context.abort(grpc.StatusCode.INVALID_ARGUMENT, str(e))

    def TableExists(self, request, context):
        try:
            self._get_full_table(request.DbName, request.TableId, context)
            return DbmsGrpc_pb2.TableExistsResponse(Exists=True)
        except:
            return DbmsGrpc_pb2.TableExistsResponse(Exists=False)


class LoggingInterceptor(ServerInterceptor):
    def intercept(self, method, request, context, method_name):
        print('=' * 20)
        print(f"Method: {method_name}")
        print(f"Parameters:\n{request}".rstrip().replace('\n', '\n    '))
        try:
            response = method(request, context)
            print(f"Response:\n{response}".rstrip().replace('\n', '\n    '))
            return response
        except:
            print(f"RPC exception: code={context.code()}, detail={context.details().decode('utf-8')!r}")
            raise


def serve():
    server = grpc.server(futures.ThreadPoolExecutor(max_workers=10), interceptors=(LoggingInterceptor(),))
    DbmsGrpc_pb2_grpc.add_DbmsProcessorServicer_to_server(DbmsProcessorServicer(), server)
    server.add_insecure_port('[::]:5000')
    server.start()
    server.wait_for_termination()


if __name__ == '__main__':
    serve()
