unit Utils;

interface

uses
  System.SysUtils, TypInfo;

type
  UtilsClass = class
  private
    //class constructor EnumFields(RecInfo: PTypeInfo);
  end;

implementation
   {
class constructor UtilsClass.EnumFields(RecInfo: PTypeInfo);
var
  Data: PTypeData;
  i: Integer;
  MF: PManagedField;
begin
  if not Assigned(RecInfo) or (RecInfo^.Kind <> tkRecord) then
    Exit;
  Writeln('Record type=', RecInfo^.Name);
  Data := GetTypeData(RecInfo);
  MF := Pointer(PByte(@Data^.ManagedFldCount) + SizeOf(Data^.ManagedFldCount));
  for i := 1 to Data^.ManagedFldCount do
  begin
    Writeln('Type=', MF^.TypeRef^.Name, ', offset=', MF^.FldOffset);
    Inc(MF);
  end;
end;
     }
end.
