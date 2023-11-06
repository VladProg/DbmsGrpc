from Models import Values
from Protos import Types_pb2


class Type:

    @staticmethod
    def from_message(message):
        instance_case = message.WhichOneof('Instance')
        if instance_case == 'Char':
            return Char()
        elif instance_case == 'Color':
            return Color()
        elif instance_case == 'ColorInvl':
            return ColorInvl(
                r1=message.ColorInvl.R1,
                r2=message.ColorInvl.R2,
                g1=message.ColorInvl.G1,
                g2=message.ColorInvl.G2,
                b1=message.ColorInvl.B1,
                b2=message.ColorInvl.B2
            )
        elif instance_case == 'Integer':
            return Integer()
        elif instance_case == 'Real':
            return Real()
        elif instance_case == 'String':
            return String()
        else:
            raise ValueError("Unsupported Type")


class Char(Type):
    def parse(self, s):
        return Values.Char(self, s)

    def __eq__(self, other):
        return isinstance(other, Char)

    def __str__(self):
        return "Char"

    def to_message(self):
        return Types_pb2.Type(Char=Types_pb2.Char(), ToStr=str(self))


class Color(Type):
    def parse(self, s):
        return Values.Color(self, s)

    def __eq__(self, other):
        return isinstance(other, Color)

    def __str__(self):
        return "Color"

    def to_message(self):
        return Types_pb2.Type(Color=Types_pb2.Color(), ToStr=str(self))


class Integer(Type):
    def parse(self, s):
        return Values.Integer(self, s)

    def __eq__(self, other):
        return isinstance(other, Integer)

    def __str__(self):
        return "Integer"

    def to_message(self):
        return Types_pb2.Type(Integer=Types_pb2.Integer(), ToStr=str(self))


class Real(Type):
    def parse(self, s):
        return Values.Real(self, s)

    def __eq__(self, other):
        return isinstance(other, Real)

    def __str__(self):
        return "Real"

    def to_message(self):
        return Types_pb2.Type(Real=Types_pb2.Real(), ToStr=str(self))


class String(Type):
    def parse(self, s):
        return Values.String(self, s)

    def __eq__(self, other):
        return isinstance(other, String)

    def __str__(self):
        return "String"

    def to_message(self):
        return Types_pb2.Type(String=Types_pb2.String(), ToStr=str(self))


class ColorInvl:
    def __init__(self, r1, r2, g1, g2, b1, b2):
        self.r1 = r1
        self.r2 = r2
        self.g1 = g1
        self.g2 = g2
        self.b1 = b1
        self.b2 = b2
        self._validate()

    def _validate(self):
        if min(self.r1, self.r2, self.g1, self.g2, self.b1, self.b2) < 0 or max(self.r1, self.r2, self.g1, self.g2, self.b1, self.b2) > 255:
            raise ValueError("RGB bounds bust be in [0..255]")
        if self.r1 > self.r2:
            raise ValueError("Minimum bound of R must be less than or equal to maximum bound of R")
        if self.g1 > self.g2:
            raise ValueError("Minimum bound of G must be less than or equal to maximum bound of G")
        if self.b1 > self.b2:
            raise ValueError("Minimum bound of B must be less than or equal to maximum bound of B")

    def parse(self, s):
        return Values.ColorInvl(self, s)

    def __eq__(self, other):
        return (
                isinstance(other, ColorInvl) and
                self.r1 == other.r1 and self.r2 == other.r2 and
                self.g1 == other.g1 and self.g2 == other.g2 and
                self.b1 == other.b1 and self.b2 == other.b2
        )

    def __str__(self):
        return f"ColorInvl (R∈[{self.r1}..{self.r2}], G∈[{self.g1}..{self.g2}], B∈[{self.b1}..{self.b2}])"

    def to_message(self):
        return Types_pb2.Type(
            ColorInvl=Types_pb2.ColorInvl(R1=self.r1, R2=self.r2, G1=self.g1, G2=self.g2, B1=self.b1, B2=self.b2),
            ToStr=str(self)
        )
