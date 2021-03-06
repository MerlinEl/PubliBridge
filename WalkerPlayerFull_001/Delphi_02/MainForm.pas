// https://docwiki.embarcadero.com/RADStudio/Sydney/en/Default_Keyboard_Shortcuts

unit MainForm;

interface

uses
    Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants,
    System.Classes, Vcl.Graphics, StrUtils, Math, IOUtils,
    Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Vcl.ExtCtrls,
    Vcl.ButtonGroup, Generics.Collections, TypInfo, WalkerPlayer,
    WalkerPlayerOptions, FileManager,
    Data.Bind.EngExt, Vcl.Bind.DBEngExt, Data.Bind.Components;

type
    TForm1 = class(TForm)
        GroupBox6: TGroupBox;
        TxtConsole: TMemo;
        grp1: TGroupBox;
        BtnLoadFile2D: TButton;
        BtnSayHello: TButton;
        lbl4: TLabel;
        lbl2: TLabel;
        lbl3: TLabel;
        BtnLoadFile3D: TButton;
        grpOptions: TGroupBox;
        grpWalkerPlayer: TGroupBox;
        BtnPlayLesson: TButton;
        BtnPlay3D: TButton;
        BtnPlayVideo: TButton;
        BtnPlayAudio: TButton;
        BtnPlayImages: TButton;
        lbl1: TLabel;
        Cbx3DList: TComboBox;
        lbl5: TLabel;
        CbxVideoList: TComboBox;
        lbl6: TLabel;
        CbxAudioList: TComboBox;
        lbl7: TLabel;
        CbxPhotosList: TComboBox;
        lbl8: TLabel;
        ChkFullScreen: TCheckBox;
        ChkFitToScreen: TCheckBox;
        ChkCenterToScreen: TCheckBox;
        ChkEscapeEnabled: TCheckBox;
        ChkAutoPlay: TCheckBox;
        ChkSkipLogo: TCheckBox;
        ChkHiddenPlayer: TCheckBox;
        ChkHiddenConsole: TCheckBox;
        CbxSwfFiles: TComboBox;
        CbxSwfDirs: TComboBox;
        CbxLessonList: TComboBox;
    CbxBookDirAll: TComboBox;
    grp2: TGroupBox;
    CbxUserName: TComboBox;
    Label4: TLabel;
    lbl9: TLabel;
    cbb1: TComboBox;
        procedure BtnSayHelloClick(Sender: TObject);
        procedure BtnLoadFile2DClick(Sender: TObject);
        procedure OnBookDirectoryChanged(Sender: TObject);
        procedure OnSwfDirectoryChanged(Sender: TObject);
        procedure BtnLoadFile3DClick(Sender: TObject);
        procedure OnFormShown(Sender: TObject);
        procedure BtnPlayLessonClick(Sender: TObject);
        procedure BtnPlayVideoClick(Sender: TObject);
        procedure BtnPlayAudioClick(Sender: TObject);
        procedure BtnPlayImagesClick(Sender: TObject);
        procedure OnUserDirectoryChanged(Sender: TObject);
    procedure BtnPlay3DClick(Sender: TObject);
    private
        { Private declarations }
    public
        { Public declarations }
    end;

var
    Form1: TForm1;

implementation

{$R *.DFM}

// ..............................//
// Utility Methods
// ..............................//
procedure Log(Str: String);
begin
    Form1.TxtConsole.Lines.Append(Str);
end;

// ..............................//
// Primary Events
// ..............................//
function GetBookDir() :string;
var
 userName, dropboxDir: string;
begin
    userName := Form1.CbxUserName.Text;
    dropboxDir := Form1.CbxBookDirAll.Text;
    Result := 'C:\Users\' + userName + '\' + dropboxDir;
end;

function GetFilesDirByType(swfDir: string): String;
var
  filesDir: string;
begin
    filesDir := GetBookDir() + '\' + swfDir;
    Log('MainForm > GetFilesDirByType > dir: ( ' + filesDir + ' )');
    Result := filesDir;
end;

procedure TForm1.BtnPlay3DClick(Sender: TObject);
var
    options: OWPlayer;
begin
    options := OWPlayerDefault;
    options.ViewMode := '3D';
    options.RootDir := GetBookDir();
    options.FilePath := GetFilesDirByType('3d') + '\' + Cbx3DList.Text;
    //WPlayer.Log('Delphi ( MainForm )', options.ToString());
    //ShowMessage('Delphi ( MainForm )' + options.ToString());
    //ShowMessage('Delphi ( MainForm )' + WPlayer.OptionsToString(options));
    WPlayer.Log('Delphi ( MainForm )', WPlayer.OptionsToString(options));
    WPlayer.LoadFile(options);
end;

procedure TForm1.BtnPlayAudioClick(Sender: TObject);
begin
    // TODO
end;

procedure TForm1.BtnPlayImagesClick(Sender: TObject);
begin
    // TODO
end;

procedure TForm1.BtnPlayLessonClick(Sender: TObject);
var
    options: OWPlayer;
begin
    options := OWPlayerDefault;
    options.RootDir := GetBookDir();
    options.FilePath := GetFilesDirByType('lessons') + '\' + CbxLessonList.Text;
    //ShowMessage('Delphi ( MainForm )' + WPlayer.OptionsToString(options));
    WPlayer.Log('Delphi ( MainForm )', WPlayer.OptionsToString(options));
    WPlayer.LoadFile(options);
end;

procedure TForm1.BtnPlayVideoClick(Sender: TObject);
begin
    // TODO
end;

function GetFilesDir(): String;
var
    userName, dropboxDir, swfDir, subDir: string;
begin
    userName := Form1.CbxUserName.Text;
    dropboxDir := Form1.CbxBookDirAll.Text;
    swfDir := Form1.CbxSwfDirs.Text;
    subDir := 'C:\Users\' + userName + '\' + dropboxDir;
    if not swfDir.Equals('root') then
        subDir := subDir + '\' + Form1.CbxSwfDirs.Text;
    Log('MainForm > GetFilesDir > ( ' + subDir + ' )');
    Result := subDir;
end;

procedure TForm1.OnBookDirectoryChanged(Sender: TObject);
begin
    FillSWFList(CbxSwfFiles, GetFilesDir(), 'swf');
end;

procedure TForm1.OnSwfDirectoryChanged(Sender: TObject);
begin
    FillSWFList(CbxSwfFiles, GetFilesDir(), 'swf');
end;

procedure TForm1.OnUserDirectoryChanged(Sender: TObject);
begin
    FillSWFList(CbxSwfFiles, GetFilesDir(), 'swf');
end;
// ..............................//
// Initialize Form and Variables
// ..............................//

procedure TForm1.OnFormShown(Sender: TObject);
var
    dir: string;
begin
    // ShowMessage('From was shown.');
    WalkerPlayer.CreateWPlayerInstance();
    dir := GetFilesDir();
    if DirectoryExists(dir) then
    begin
        // Fil Test List
        FillSWFList(CbxSwfFiles, dir, 'swf');
        Log('MainForm > OnFormShown > ( ' + CbxSwfFiles.Items.Count.ToString() +
          ' ) Swf Files from dir:' + dir);
        // Fill Final Lists by Type
        FillSWFList(Cbx3DList, GetFilesDirByType('3d'), 'swf');
        FillSWFList(CbxAudioList, GetFilesDirByType('audio'), 'mp3');
        FillSWFList(CbxLessonList, GetFilesDirByType('lessons'), 'swf');
        FillSWFList(CbxPhotosList, GetFilesDirByType('photos'), 'jpg');
        FillSWFList(CbxVideoList, GetFilesDirByType('video'), 'flv');

    end;
end;

// ..............................//
// Test Events
// ..............................//
procedure TForm1.BtnSayHelloClick(Sender: TObject);
begin
    WPlayer.SayHello('> [ Mr.' + CbxUserName.Text + ' ]');
end;

procedure TForm1.BtnLoadFile2DClick(Sender: TObject);
var
    fpath: WideString;
    options: OWPlayer;
begin
    // Open walker player and load a file in to it
    fpath := GetFilesDir() + '\' + CbxSwfFiles.Text;
    Log('LoadFile > fpath:' + fpath);
    // Set-Up options
    options.Name := 'Walker Player Options.';
    options.ViewMode := '2D';
    options.FilePath := fpath;
    options.RootDir := CbxBookDirAll.Text;
    options.HiddenPlayer := PChar(ChkHiddenPlayer.Checked);
    options.HiddenConsole := PChar(ChkHiddenConsole.Checked);
    options.AutoPlay := PChar(ChkAutoPlay.Checked);
    options.FullScreen := PChar(ChkFullScreen.Checked);
    options.CenterToScreen := PChar(ChkCenterToScreen.Checked);
    options.FitToScreen := PChar(ChkFitToScreen.Checked);
    options.EscapeEnabled := PChar(ChkEscapeEnabled.Checked);
    options.SkipLogo := PChar(ChkSkipLogo.Checked);
    // Print options into Walker Console
    // WPlayer.SayHello(options.ToString()) ;
    // WPlayer.Log('Delphi ( MainForm )', options.ToString());
    WPlayer.Log('Delphi ( MainForm )', WPlayer.OptionsToString(options));
    // Load Media File (swf)
    WPlayer.LoadFile(options);
end;

procedure TForm1.BtnLoadFile3DClick(Sender: TObject);
var
    fpath: WideString;
    options: OWPlayer;
begin
    // Open walker player and load a file in to it
    fpath := GetFilesDir() + '\' + CbxSwfFiles.Text;
    Log('LoadFile > fpath:' + fpath);
    // Set-Up options
    options.Name := 'Walker Player Options.';
    options.ViewMode := '3D';
    options.FilePath := fpath;
    options.RootDir := CbxBookDirAll.Text;
    options.HiddenPlayer := PChar(ChkHiddenPlayer.Checked);
    options.HiddenConsole := PChar(ChkHiddenConsole.Checked);
    options.AutoPlay := PChar(ChkAutoPlay.Checked);
    options.FullScreen := PChar(ChkFullScreen.Checked);
    options.CenterToScreen := PChar(ChkCenterToScreen.Checked);
    options.FitToScreen := PChar(ChkFitToScreen.Checked);
    options.EscapeEnabled := PChar(ChkEscapeEnabled.Checked);
    options.SkipLogo := PChar(ChkSkipLogo.Checked);
    WPlayer.Log('Delphi ( MainForm )', WPlayer.OptionsToString(options));
    // WPlayer.Log('Delphi ( MainForm )', EnumFields(TypeInfo(OWPlayer)));
    // Load Media File (swf)
    WPlayer.LoadFile(options);
end;
end.
