from Models.Table import Table
from Models.TableDifference import TableDifference
from Protos import Messages_pb2


class Database:
    def __init__(self):
        self.tables = {}
        self._next_id = 0

    def add_table(self, name, columns):
        table = Table(self._next_id, name, columns)
        self.tables[self._next_id] = table
        self._next_id += 1
        return table

    def remove_table(self, id):
        if id in self.tables:
            del self.tables[id]

    def to_message_info(self):
        message = Messages_pb2.DatabaseInfo()
        message.Tables.extend(table.to_message_info() for table in self.tables.values())

        table_differences = (
            difference.to_message_info()
            for left_table in self.tables.values()
            for right_table in self.tables.values()
            if left_table.id != right_table.id
            for difference in [TableDifference.create_or_null(left_table, right_table)]
            if difference is not None
        )
        message.TableDifferences.extend(table_differences)

        return message
