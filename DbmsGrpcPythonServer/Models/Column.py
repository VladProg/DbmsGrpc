from Protos import Messages_pb2


class Column:
    def __init__(self, name: str, type):
        self.name = name
        self.type = type

    def to_message(self):
        return Messages_pb2.Column(Name=self.name, Type=self.type.to_message())
