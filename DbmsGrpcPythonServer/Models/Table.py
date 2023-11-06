from Models.Row import Row
from Protos import Messages_pb2


class Table:
    def __init__(self, id, name, columns):
        self.id = id
        self.name = name
        self.columns = columns
        self.rows = {}
        self._next_id = 0

    def add_row(self, cells):
        if len(cells) != len(self.columns):
            raise ValueError("Row length must be the same as number of columns")
        for i in range(len(self.columns)):
            if cells[i].type != self.columns[i].type:
                raise ValueError("Cell type doesn't match corresponding column type")
        row = Row(self._next_id, cells)
        self.rows[self._next_id] = row
        self._next_id += 1
        return row

    def remove_row(self, id):
        if id in self.rows:
            del self.rows[id]

    def contains_row(self, row):
        return any(row == value for value in self.rows.values())

    def clear_rows(self):
        self.rows.clear()

    def to_message_info(self):
        return Messages_pb2.TableInfo(Id=self.id, Name=self.name)

    def to_message(self):
        message = Messages_pb2.Table(Id=self.id, Name=self.name)
        message.Columns.extend(column.to_message() for column in self.columns)
        for key, value in self.rows.items():
            message.Rows[key].CopyFrom(value.to_message())
        return message
