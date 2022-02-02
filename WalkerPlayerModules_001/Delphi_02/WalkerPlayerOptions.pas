unit WalkerPlayerOptions;

interface

uses
  System.SysUtils, Rtti, TypInfo;

// Walker Player Options (used by LoadFile(options))
type
  OWPlayer = record
    _Type: Integer; // Type is a reserved word in Delphi
    Name: PAnsiChar;
    MediaType: PAnsiChar; // AUDIO, VIDEO, IMAGES, LESSON, STAGE3D
    WindowSize: PAnsiChar;  // Window position size AUTO or 800,600
    WindowPos: PAnsiChar;  // Window position CENTER or 120,120
    FilePath: WideString; // swf file path
    RootDir: WideString; // directory with xml setting
    HiddenPlayer: Integer; // output > True = 1, False =  0
    HiddenConsole: Integer;
    AutoPlay: Integer;
    Resizable: Integer;
    FitToScreen: Integer;
    EscapeEnabled: Integer;
    SkipLogo: Integer;
    function ToString: String;
    function ToStringAll: string;
  end;

CONST
  OWPlayerDefault: OWPlayer = (
      Name: 'Walker Player Options.';
      MediaType: 'LESSON';
      WindowSize: 'AUTO';
      WindowPos: 'CENTER';
      FilePath: '';
      RootDir: '';
      HiddenPlayer: 0;
      HiddenConsole: 0;
      AutoPlay: 1;
      Resizable: 0;
      FitToScreen: 1;
      EscapeEnabled: 1;
      SkipLogo: 0
    );

const
  StrNewLine = AnsiString(#13#10);
  // "#13" = CR(carriage return) #10 = LF(line feed).

const
  StrTab = AnsiString(#9); // #9 = TAB(horizontal tab)

implementation

function EscapeQuotes(const S: String): String;
begin
  // Easy but not best performance
  Result := StringReplace(S, '\', '\\', [rfReplaceAll]);
  Result := StringReplace(Result, '"', '\"', [rfReplaceAll]);
end;

function OWPlayer.ToString: String;
var
  AContext: TRttiContext;
  AField: TRttiField;
  ARecord: TRttiRecordType;
  AFldName: String;
  AValue: TValue;
begin
  Result := '';
  AContext := TRttiContext.Create;
  try
    ARecord := AContext.GetType(TypeInfo(OWPlayer)).AsRecord;
    for AField in ARecord.GetFields do
    begin
      AFldName := AField.Name;
      AValue := AField.GetValue(@Self);
      Result := Result + AFldName + '="' + EscapeQuotes(AValue.ToString) + '";';
    end;
  finally
    AContext.Free;
  end;
end;

function OWPlayer.ToStringAll(): string;
var
  ctx: TRttiContext;
  t: TRttiType;
  field: TRttiField;
  S: WideString;
begin
  S := '';
  ctx := TRttiContext.Create;
  for field in ctx.GetType(TypeInfo(OWPlayer)).GetFields do
  begin
    t := field.FieldType;
    S := S + StrTab + 'OWPlayer.ToString > ' + 'Field: ' + field.Name + 'Type: '
      + t.Name + 'Value: ' + field.GetValue(@Self).ToString + StrNewLine;
    // TODO newline and tab not works
  end;
  Result := S;
end;

{
  S := S + Format('%sOWPlayer.ToString > Field :%s : Type : %s Value : %s%s',[
  StrTab,
  field.Name,
  t.Name,
  field.GetValue(@Self).ToString,
  StrNewLine
  ]);
}
end.