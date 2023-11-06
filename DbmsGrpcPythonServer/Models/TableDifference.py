from Models.Table import Table
from Models.Column import Column
from Protos import Messages_pb2


class TableDifference(Table):
    def __init__(self, id, name, columns, left_table, right_table):
        super().__init__(id, name, columns)
        self.left_table = left_table
        self.right_table = right_table

    def calculate(self):
        super().clear_rows()
        for row in self.left_table.rows.values():
            if not self.right_table.contains_row(row):
                super().add_row(row.cells)

    @staticmethod
    def create(left_table, right_table):
        if len(left_table.columns) != len(right_table.columns):
            raise ValueError("Table difference: tables have different column counts")
        for i in range(len(left_table.columns)):
            if left_table.columns[i].type != right_table.columns[i].type:
                raise ValueError("Table difference: tables have different column types")
        columns = [Column(
            left_table.columns[i].name if left_table.columns[i].name == right_table.columns[i].name
            else f'"{left_table.columns[i].name}" / "{right_table.columns[i].name}"',
            left_table.columns[i].type)
            for i in range(len(left_table.columns))]
        difference = TableDifference(
            left_table.id | (right_table.id << 16) | ~((1 << 31) - 1),
            f'Difference "{left_table.name}" - "{right_table.name}"',
            columns,
            left_table,
            right_table)
        return difference

    @staticmethod
    def create_or_null(left_table, right_table):
        try:
            return TableDifference.create(left_table, right_table)
        except:
            return None

    def add_row(self, cells):
        raise NotImplementedError("Table difference is read-only")

    def remove_row(self, id):
        raise NotImplementedError("Table difference is read-only")

    def clear_rows(self):
        raise NotImplementedError("Table difference is read-only")

    def to_message_info(self):
        return Messages_pb2.TableInfo(Id=self.id, Name=self.name,
                                      TableDifferenceInfo=Messages_pb2.TableDifferenceInfo(
                                          LeftTableInfo=self.left_table.to_message_info(),
                                          RightTableInfo=self.right_table.to_message_info()))

    def to_message(self):
        message = Messages_pb2.Table(Id=self.id, Name=self.name, TableDifference=Messages_pb2.TableDifference())
        message.Columns.extend(column.to_message() for column in self.columns)
        for key, value in self.rows.items():
            message.Rows[key].CopyFrom(value.to_message())
        return message

    @staticmethod
    def parse_id(id):
        if (id & (1 << 31)) == 0:
            return None
        id ^= ~((1 << 31) - 1)
        return id & ((1 << 16) - 1), id >> 16
