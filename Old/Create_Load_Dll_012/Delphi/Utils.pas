unit Utils;

interface

uses
  System.SysUtils, TypInfo;
// Web: https://forum.lazarus.freepascal.org/index.php?topic=49232.0
// Walker Player Options (used by LoadFile(options))
type
  OWPlayer = record
    _Type: Integer; // Type is a reserved word in Delphi
    Name: PAnsiChar;
    ViewMode: PAnsiChar; // View mode 2D - 3D
    FilePath: WideString; // swf file path
    RootDir: WideString; // directory with xml setting
    HiddenPlayer: PChar; // output > True = 1, False =  0
    HiddenConsole: PChar;
    AutoPlay: PChar;
    FullScreen: PChar;
    FitToScreen: PChar;
    CenterToScreen: PChar;
    EscapeEnabled: PChar;
    SkipLogo: PChar;
    function ToString: string;
    function ToString2: string;
  end;
  function EnumFields(RecInfo: PTypeInfo):string;

implementation

function OWPlayer.ToString(): string;
var
  Data: PTypeData;
  i: Integer;
  MF: PManagedField;
  recInfo: PTypeInfo;
  s: string;
begin
  s := '';
  recInfo := TypeInfo(OWPlayer);
  if not Assigned(recInfo) or (recInfo^.Kind <> tkRecord) then
    Exit;
  Data := GetTypeData(recInfo);
  MF := Pointer(PByte(@Data^.ManagedFldCount) + SizeOf(Data^.ManagedFldCount));
  for i := 1 to Data^.ManagedFldCount do
  begin
    s := s + 'Key:' + MF^.TypeRef^.Name + ' Val:' + MF^.FldOffset.ToString() + #13#10;
    // Writeln('Type=', MF^.TypeRef^.Name, ', offset=', MF^.FldOffset);
    Inc(MF);
  end;
  Result := s;
end;

  function OWPlayer.ToString2(): string;
  var s: string;
  begin
    s:='';
    s:= s+'Name:"' + Self.Name + '"' + #13#10;
    s:= s+'FilePath:"' + Self.FilePath + '"' + #13#10;
    Result := s;
  end;


  function EnumFields(RecInfo: PTypeInfo):String;
var
  Data: PTypeData;
  i: Integer;
  MF: PManagedField;
begin
  Result := '';
  if not Assigned(RecInfo) or (RecInfo^.Kind <> tkRecord) then
    Exit;
  Data := GetTypeData(RecInfo);
  MF := Pointer(PByte(@Data^.ManagedFldCount) + SizeOf(Data^.ManagedFldCount));
  for i := 1 to Data^.ManagedFldCount do
  begin
    Result := Result + 'Type=' + MF^.TypeRef^.Name + ', offset=' + MF^.FldOffset.ToString() + #13#10;
    //Writeln('Type=', MF^.TypeRef^.Name, ', offset=', MF^.FldOffset);
    Inc(MF);
  end;
end;
end.
