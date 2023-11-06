from Protos import Messages_pb2


class Row:
    def __init__(self, id, cells):
        self.id = id
        self.cells = cells

    def __eq__(self, other):
        if not isinstance(other, Row):
            return False
        return self.cells == other.cells

    def to_message(self):
        message = Messages_pb2.Row(Id=self.id)
        message.Cells.extend(str(cell) for cell in self.cells)
        return message
