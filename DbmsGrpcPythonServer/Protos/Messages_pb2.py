# -*- coding: utf-8 -*-
# Generated by the protocol buffer compiler.  DO NOT EDIT!
# source: Protos/Messages.proto
"""Generated protocol buffer code."""
from google.protobuf import descriptor as _descriptor
from google.protobuf import descriptor_pool as _descriptor_pool
from google.protobuf import symbol_database as _symbol_database
from google.protobuf.internal import builder as _builder
# @@protoc_insertion_point(imports)

_sym_db = _symbol_database.Default()


from Protos import Types_pb2 as Protos_dot_Types__pb2


DESCRIPTOR = _descriptor_pool.Default().AddSerializedFile(b'\n\x15Protos/Messages.proto\x12\x11\x44\x62msGrpc.Messages\x1a\x12Protos/Types.proto\"C\n\x06\x43olumn\x12\x0c\n\x04Name\x18\x01 \x01(\t\x12+\n\x04Type\x18\x02 \x01(\x0b\x32\x1d.DbmsGrpc.Messages.Types.Type\" \n\x03Row\x12\n\n\x02Id\x18\x01 \x01(\x05\x12\r\n\x05\x43\x65lls\x18\x02 \x03(\t\"j\n\tTableInfo\x12\n\n\x02Id\x18\x01 \x01(\x05\x12\x0c\n\x04Name\x18\x02 \x01(\t\x12\x43\n\x13TableDifferenceInfo\x18\x03 \x01(\x0b\x32&.DbmsGrpc.Messages.TableDifferenceInfo\"\x81\x02\n\x05Table\x12\n\n\x02Id\x18\x01 \x01(\x05\x12\x0c\n\x04Name\x18\x02 \x01(\t\x12*\n\x07\x43olumns\x18\x03 \x03(\x0b\x32\x19.DbmsGrpc.Messages.Column\x12\x30\n\x04Rows\x18\x04 \x03(\x0b\x32\".DbmsGrpc.Messages.Table.RowsEntry\x12;\n\x0fTableDifference\x18\x05 \x01(\x0b\x32\".DbmsGrpc.Messages.TableDifference\x1a\x43\n\tRowsEntry\x12\x0b\n\x03key\x18\x01 \x01(\x05\x12%\n\x05value\x18\x02 \x01(\x0b\x32\x16.DbmsGrpc.Messages.Row:\x02\x38\x01\"\x80\x01\n\x13TableDifferenceInfo\x12\x33\n\rLeftTableInfo\x18\x01 \x01(\x0b\x32\x1c.DbmsGrpc.Messages.TableInfo\x12\x34\n\x0eRightTableInfo\x18\x02 \x01(\x0b\x32\x1c.DbmsGrpc.Messages.TableInfo\"\x11\n\x0fTableDifference\"t\n\x0c\x44\x61tabaseInfo\x12,\n\x06Tables\x18\x01 \x03(\x0b\x32\x1c.DbmsGrpc.Messages.TableInfo\x12\x36\n\x10TableDifferences\x18\x02 \x03(\x0b\x32\x1c.DbmsGrpc.Messages.TableInfob\x06proto3')

_globals = globals()
_builder.BuildMessageAndEnumDescriptors(DESCRIPTOR, _globals)
_builder.BuildTopDescriptorsAndMessages(DESCRIPTOR, 'Protos.Messages_pb2', _globals)
if _descriptor._USE_C_DESCRIPTORS == False:
  DESCRIPTOR._options = None
  _TABLE_ROWSENTRY._options = None
  _TABLE_ROWSENTRY._serialized_options = b'8\001'
  _globals['_COLUMN']._serialized_start=64
  _globals['_COLUMN']._serialized_end=131
  _globals['_ROW']._serialized_start=133
  _globals['_ROW']._serialized_end=165
  _globals['_TABLEINFO']._serialized_start=167
  _globals['_TABLEINFO']._serialized_end=273
  _globals['_TABLE']._serialized_start=276
  _globals['_TABLE']._serialized_end=533
  _globals['_TABLE_ROWSENTRY']._serialized_start=466
  _globals['_TABLE_ROWSENTRY']._serialized_end=533
  _globals['_TABLEDIFFERENCEINFO']._serialized_start=536
  _globals['_TABLEDIFFERENCEINFO']._serialized_end=664
  _globals['_TABLEDIFFERENCE']._serialized_start=405
  _globals['_TABLEDIFFERENCE']._serialized_end=422
  _globals['_DATABASEINFO']._serialized_start=685
  _globals['_DATABASEINFO']._serialized_end=801
# @@protoc_insertion_point(module_scope)
