import re
from decimal import Decimal


class Value:
    def __init__(self, type):
        self.type = type

    def __eq__(self, other):
        return isinstance(other, Value) and self.type == other.type


class Char(Value):
    def __init__(self, type, val):
        super().__init__(type)
        if len(val) != 1:
            raise ValueError("Char must contain a single character")
        self.val = val

    def __str__(self):
        return str(self.val)

    def __eq__(self, other):
        return super().__eq__(other) and isinstance(other, Char) and self.val == other.val


class Integer(Value):
    def __init__(self, type, val):
        super().__init__(type)
        try:
            self.val = int(val)
        except:
            raise ValueError("Incorrect value for type Integer")

    def __str__(self):
        return str(self.val)

    def __eq__(self, other):
        return super().__eq__(other) and isinstance(other, Integer) and self.val == other.val


class Real(Value):
    def __init__(self, type, val):
        super().__init__(type)
        try:
            self.val = Decimal(val)
        except:
            raise ValueError("Incorrect value for type Real")

    def __str__(self):
        return str(self.val)

    def __eq__(self, other):
        return super().__eq__(other) and isinstance(other, Real) and self.val == other.val


class String(Value):
    def __init__(self, type, val):
        super().__init__(type)
        self.val = val

    def __str__(self):
        return str(self.val)

    def __eq__(self, other):
        return super().__eq__(other) and isinstance(other, String) and self.val == other.val


class Color(Value):
    def __init__(self, type, *args):
        super().__init__(type)
        if len(args) == 3 and all(isinstance(arg, int) for arg in args):
            self.r, self.g, self.b = map(Color.parse_byte, args)
        elif len(args) == 1 and isinstance(args[0], str):
            numbers = re.findall(r'\d+', args[0])
            if len(numbers) != 3:
                raise ValueError("RGB-color must contain exactly 3 numbers (R, G, B)")
            self.r = Color.parse_byte("R", numbers[0])
            self.g = Color.parse_byte("G", numbers[1])
            self.b = Color.parse_byte("B", numbers[2])
        else:
            raise ValueError("Invalid arguments for Color construction")

    @staticmethod
    def parse_byte(name, string):
        try:
            value = int(string)
            if not 0 <= value <= 255:
                raise ValueError
            return value
        except ValueError:
            raise ValueError(f"{name} = {string} but allowed range is [0..255]")

    def __str__(self):
        return f"(R={self.r}, G={self.g}, B={self.b})"

    def __eq__(self, other):
        if not isinstance(other, Color) or not super().__eq__(other):
            return False
        return self.r == other.r and self.g == other.g and self.b == other.b


class ColorInvl(Value):
    def __init__(self, type, *args):
        super().__init__(type)
        if len(args) == 3 and all(isinstance(arg, int) for arg in args):
            self.r, self.g, self.b = args
            self.validate()
        elif len(args) == 1 and isinstance(args[0], str):
            numbers = re.findall(r'\d+', args[0])
            if len(numbers) != 3:
                raise ValueError("RGB-color must contain exactly 3 numbers (R, G, B)")
            self.r = ColorInvl.parse_byte("R", numbers[0], self.type.r1, self.type.r2)
            self.g = ColorInvl.parse_byte("G", numbers[1], self.type.g1, self.type.g2)
            self.b = ColorInvl.parse_byte("B", numbers[2], self.type.b1, self.type.b2)
        else:
            raise ValueError("Invalid arguments for ColorInvl construction")

    @staticmethod
    def parse_byte(name, string, min, max):
        try:
            value = int(string)
            if not min <= value <= max:
                raise ValueError
            return value
        except ValueError:
            raise ValueError(f"{name} = {string} but allowed range is [{min}..{max}]")

    def __str__(self):
        return f"(R={self.r}, G={self.g}, B={self.b})"

    def __eq__(self, other):
        if not isinstance(other, ColorInvl) or not super().__eq__(other):
            return False
        return self.r == other.r and self.g == other.g and self.b == other.b

    def validate(self):
        ColorInvl.validate_range("R", self.r, self.type.r1, self.type.r2)
        ColorInvl.validate_range("G", self.g, self.type.g1, self.type.g2)
        ColorInvl.validate_range("B", self.b, self.type.b1, self.type.b2)

    @staticmethod
    def validate_range(name, val, min_val, max_val):
        if val < min_val or val > max_val:
            raise ValueError(f"{name} = {val} but allowed range is [{min_val}..{max_val}]")
