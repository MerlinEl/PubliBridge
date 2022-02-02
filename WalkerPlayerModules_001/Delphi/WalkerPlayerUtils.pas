unit WalkerPlayerUtils;

interface

uses
  Winapi.Windows, System.StrUtils, System.SysUtils, Dialogs,
  System.IOUtils, Vcl.StdCtrls, System.Math;

// Public static methods declaration
function BoolToInt(state: Boolean): Integer;
function ExtractFNameWithoutExt(const FileName: string): string;
function GetUserName():string;
function StrToAnsi(str: WideString): AnsiString;
procedure FillSWFList(cbx: TComboBox; dir, extension: string);

implementation

// Public static methods
function ExtractFNameWithoutExt(const FileName: string): string;
begin
  Result := ChangeFileExt(ExtractFileName(FileName), '');
end;

function BoolToInt(state: Boolean): Integer;
begin
  Result := IfThen(state, 1, 0);
end;

function GetUserName():string;
begin
  Result := GetEnvironmentVariable('USERNAME');
end;

procedure FillSWFList(cbx: TComboBox; dir, extension: string);
var
  path: string;
begin
  if not DirectoryExists(dir) then
    ShowMessage('FileManager > FillSWFList > Directory not found at:' + dir)
  else
  begin
    cbx.Clear();
    begin
      for path in TDirectory.GetFiles(dir, '*.' + extension) do
        cbx.Items.Add(ExtractFileName(path));
    end;
    if cbx.Items.Count > 0 then
      cbx.ItemIndex := 0;
  end;
end;
// String to AnsiString Conversion
function bintoAscii(const bin: array of byte): AnsiString;
var i: integer;
begin
  SetLength(Result, Length(bin));
  for i := 0 to Length(bin)-1 do
    Result[1+i] := AnsiChar(bin[i]);
end;

function StrToAnsi(str: WideString): AnsiString;
var
  Buf: TBytes;
begin
  //Result:=AnsiString(UTF8Decode(str));
  //Result:=AnsiString(str);
  //Result := TEncoding.ANSI.GetString(buf);
  Buf := TEncoding.ANSI.GetBytes(str);
  Result := bintoAscii(Buf);
end;



{:Converts Ansi string to Unicode string using specified code page.
  @param   s        Ansi string.
  @param   codePage Code page to be used in conversion.
  @returns Converted wide string.
}
{
function StringToWideString(const s: AnsiString; codePage: Word): WideString;
var
  l: integer;
begin
  if s = '' then
    Result := ''
  else
  begin
    l := MultiByteToWideChar(codePage, MB_PRECOMPOSED, PChar(@s[1]), - 1, nil, 0);
    SetLength(Result, l - 1);
    if l > 1 then MultiByteToWideChar(CodePage, MB_PRECOMPOSED, PChar(@s[1]), - 1, PWideChar(@Result[1]), l - 1);
  end;
end;}
end.
