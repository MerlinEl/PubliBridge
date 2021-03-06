unit WalkerPlayerUtils;

interface

uses
  Winapi.Windows, System.StrUtils, System.SysUtils, Dialogs,
  System.IOUtils, Vcl.StdCtrls, System.Math;

// Public static methods declaration
function ExtractFNameWithoutExt(const FileName: string): string;
function BoolToInt(b:Boolean) :Integer;
function GetUserName():string;
function GetBookDir(): string;
function GetVideoType(str:string): string;
function StrToAnsi(str: WideString): AnsiString;
procedure FillMediaList(cbx: TComboBox; dir, extension: string);
procedure FillMediaListByType();

implementation
  uses MainForm;

// Public static methods
function BoolToInt(b:Boolean): Integer;
begin
  Result := IfThen(b , 1, 0);
end;

function ExtractFNameWithoutExt(const FileName: string): string;
begin
  Result := ChangeFileExt(ExtractFileName(FileName), '');
end;

function IsWebStream(str:string): Boolean;
begin
   Result := string(str).IndexOf('.mp4') > -1;
end;

function IsWebLink(str:string): Boolean;
begin
   Result := string(str).IndexOf('://') > -1;
end;

function GetVideoType(str:string): string;
var buttonId: string;
begin
   if IsWebStream(str) then buttonId := 'WEBSTREAM' // play video embeded
   else if IsWebLink(str) then buttonId := 'WEBLINK' // open video in browser
   else buttonId := 'LOCAL'; // play video from hd
   Result := buttonId;
end;

function GetUserName():string;
begin
  Result := GetEnvironmentVariable('USERNAME');
end;

function GetBookDir(): string;
var
    userName, dropboxDir, bookDir: string;
begin
    userName := Form1.EdtUserName.Text;
    dropboxDir := Form1.CbxBookDir.Text;
    if userName = 'Pan Chcitojinak' then
      Result := dropboxDir
    else
      Result := 'C:\Users\' + userName + '\' + dropboxDir;
end;

function GetFilesDirByType(swfDir: string): String;
var
    filesDir: string;
begin
    filesDir := GetBookDir() + '\' + swfDir;
    Form1.Log('WalkerPlayerUtils > GetFilesDirByType > dir: ( ' + filesDir + ' )');
    Result := filesDir;
end;

procedure FillMediaList(cbx: TComboBox; dir, extension: string);
var
  path: string;
begin
  if not DirectoryExists(dir) then
    ShowMessage('WalkerPlayerUtils > FillSWFList > Directory not found at:' + dir)
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
procedure FillMediaListByType();
var
    dir: string;
begin
    dir := GetBookDir();
    if DirectoryExists(dir) then
    begin
        // Fill Lists by Type
        Form1.Log('MainForm > FillListsByType > BookDir: ( ' + dir + ' )');
        FillMediaList(Form1.CbxLessonList, GetFilesDirByType('lessons'), 'swf');
        FillMediaList(Form1.Cbx3DList, GetFilesDirByType('3d'), 'swf');

        // 1) Video Local
        FillMediaList(Form1.CbxVideoList, GetFilesDirByType('video'), 'flv');

        // 2) Video Webstream
        {Dejepis 7 str.55}
        Form1.CbxVideoList.Items.Add('https://www.ceskatelevize.cz/porady/10169631969-stity-kralovstvi-ceskeho/207562235200001-jak-rostly-hrady/');
        {Dejepis 7 str.59}
        Form1.CbxVideoList.Items.Add('https://v11-a.sdn.cz/v_11/vd_10004867_1485859405/h264_aac_720p_mp4/eff19af5.mp4');
        {Dejepis 7 str.65}
        Form1.CbxVideoList.Items.Add('https://v11-a.sdn.cz/v_11/vd_627474_1485976697/h264_aac_720p_mp4/c5ef1af2.mp4');
        {Dejepis 7 str.25} // not used from stream (was downloaded)
        Form1.CbxVideoList.Items.Add('https://www.youtube.com/watch?v=6ldHiLvbVe0');

        // 3) Video Weblink
        {Dejepis 7 str.125}
        Form1.CbxVideoList.Items.Add('https://www.ceskatelevize.cz/ivysilani/10361869257-narodni-klenoty/211563235200002-telc-jezerni-ruze');
        {Dejepis 7 str.106}
        Form1.CbxVideoList.Items.Add('https://www.stream.cz/vylety-do-minulosti/kralovnin-korzar-francis-drake-obeplul-svet-26-9-1580-317312');

        Form1.Log(#9 + '3DList:> ( ' + Form1.Cbx3DList.Items.Count.ToString() + ' )');
        Form1.Log(#9 + 'AudioList:> ( ' + Form1.CbxAudioList.Items.Count.ToString
          () + ' )');
        Form1.Log(#9 + 'LessonList:> ( ' + Form1.CbxLessonList.Items.Count.ToString
          () + ' )');
        Form1.Log(#9 + 'PhotoList:> ( ' + Form1.CbxImageList.Items.Count.ToString
          () + ' )');
        Form1.Log(#9 + 'VideoList:> ( ' + Form1.CbxVideoList.Items.Count.ToString
          () + ' )');

        FillMediaList(Form1.CbxAudioList, GetFilesDirByType('audio'), 'mp3');
        FillMediaList(Form1.CbxImageList, GetFilesDirByType('photos'), 'jpg');
    end
    else
    begin
        // Clear All Lists
        Form1.Cbx3DList.Clear();
        Form1.CbxAudioList.Clear();
        Form1.CbxLessonList.Clear();
        Form1.CbxImageList.Clear();
        Form1.CbxVideoList.Clear();
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

