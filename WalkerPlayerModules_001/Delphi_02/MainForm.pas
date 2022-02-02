// https://docwiki.embarcadero.com/RADStudio/Sydney/en/Default_Keyboard_Shortcuts

unit MainForm;

interface

uses
    Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants,
    System.Classes, Vcl.Graphics, StrUtils, Math, IOUtils,
    Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Vcl.ExtCtrls,
    Vcl.ButtonGroup, Generics.Collections, TypInfo, WalkerPlayer,
    WalkerPlayerOptions, FileManager, MainFormSettings,
    Data.Bind.EngExt, Vcl.Bind.DBEngExt, Data.Bind.Components;

type
    TForm1 = class(TForm)
        GroupBox6: TGroupBox;
        TxtConsole: TMemo;
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
        CbxPhotoList: TComboBox;
        lbl8: TLabel;
        ChkFitToScreen: TCheckBox;
        ChkEscapeEnabled: TCheckBox;
        ChkAutoPlay: TCheckBox;
        ChkSkipLogo: TCheckBox;
        ChkHiddenPlayer: TCheckBox;
        ChkHiddenConsole: TCheckBox;
        CbxLessonList: TComboBox;
        Label4: TLabel;
        CbxUserName: TComboBox;
        CbxBookDir: TComboBox;
        lbl9: TLabel;
        Button1: TButton;
        BtnAddUser: TButton;
        BtnRemoveUser: TButton;
    ChkResizable: TCheckBox;
        procedure BtnSayHelloClick(Sender: TObject);
        procedure OnFormShown(Sender: TObject);
        procedure BtnPlayLessonClick(Sender: TObject);
        procedure BtnPlayVideoClick(Sender: TObject);
        procedure BtnPlayAudioClick(Sender: TObject);
        procedure BtnPlayImagesClick(Sender: TObject);
        procedure BtnPlay3DClick(Sender: TObject);
        procedure OnUserDirectoryChanged(Sender: TObject);
        procedure OnBookDirectoryChanged(Sender: TObject);
        procedure OnFormClose(Sender: TObject; var Action: TCloseAction);
        procedure BtnAddUserClick(Sender: TObject);
        procedure BtnRemoveUserClick(Sender: TObject);
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
function BoolToInt(chk : TCheckBox):Integer;
begin
  Result := IfThen(chk.Checked, 1, 0);
end;

// ..............................//
// Primary Events
// ..............................//
function GetBookDir(): string;
var
    userName, dropboxDir: string;
begin
    userName := Form1.CbxUserName.Text;
    dropboxDir := Form1.CbxBookDir.Text;
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
function GetWPOptions(): OWPlayer;
var options: OWPlayer;
begin
    // Set-Up options
    options.Name := 'Walker Player Options.';
    options.MediaType := 'LESSON';
    options.WindowSize := 'AUTO';
    options.WindowPos := 'CENTER'; // centred on screen
    options.RootDir := GetBookDir();
    options.HiddenPlayer := BoolToInt(Form1.ChkHiddenPlayer);
    options.HiddenConsole := BoolToInt(Form1.ChkHiddenConsole);
    options.AutoPlay := BoolToInt(Form1.ChkAutoPlay);
    options.FitToScreen := BoolToInt(Form1.ChkFitToScreen);
    options.EscapeEnabled := BoolToInt(Form1.ChkEscapeEnabled);
    options.SkipLogo := BoolToInt(Form1.ChkSkipLogo);
    options.Resizable := BoolToInt(Form1.ChkResizable);
    Result := options;
end;
procedure FillListsByType();
var
    dir: string;
begin
    dir := GetBookDir();
    if DirectoryExists(dir) then
    begin
        // Fill Lists by Type
        Log('MainForm > FillListsByType > BookDir: ( ' + dir + ' )');
        FillSWFList(Form1.Cbx3DList, GetFilesDirByType('3d'), 'swf');
        FillSWFList(Form1.CbxAudioList, GetFilesDirByType('audio'), 'mp3');
        FillSWFList(Form1.CbxLessonList, GetFilesDirByType('lessons'), 'swf');
        FillSWFList(Form1.CbxPhotoList, GetFilesDirByType('photos'), 'jpg');
        FillSWFList(Form1.CbxVideoList, GetFilesDirByType('video'), 'flv');
        Log(#9 + '3DList:> ( ' + Form1.Cbx3DList.Items.Count.ToString() + ' )');
        Log(#9 + 'AudioList:> ( ' + Form1.CbxAudioList.Items.Count.ToString
          () + ' )');
        Log(#9 + 'LessonList:> ( ' + Form1.CbxLessonList.Items.Count.ToString
          () + ' )');
        Log(#9 + 'PhotoList:> ( ' + Form1.CbxPhotoList.Items.Count.ToString
          () + ' )');
        Log(#9 + 'VideoList:> ( ' + Form1.CbxVideoList.Items.Count.ToString
          () + ' )');
    end
    else
    begin
        // Clear All Lists
        Form1.Cbx3DList.Clear();
        Form1.CbxAudioList.Clear();
        Form1.CbxLessonList.Clear();
        Form1.CbxPhotoList.Clear();
        Form1.CbxVideoList.Clear();
    end;
end;

procedure TForm1.OnUserDirectoryChanged(Sender: TObject);
begin
    FillListsByType();
end;

procedure TForm1.OnBookDirectoryChanged(Sender: TObject);
begin
    FillListsByType();
end;

procedure TForm1.BtnAddUserClick(Sender: TObject);
begin
    CbxUserName.Items.Add(CbxUserName.Text);
end;

procedure TForm1.BtnRemoveUserClick(Sender: TObject);
begin
    CbxUserName.Items.Delete(CbxUserName.ItemIndex);
    if CbxUserName.Items.Count > 0 then
        CbxUserName.ItemIndex := 0;
end;

procedure TForm1.BtnPlay3DClick(Sender: TObject);
//var options: OWPlayer;
begin
//    options := GetWPOptions();
//    options.MediaType := 'STAGE3D';
//    options.FilePath := GetFilesDirByType('3d') + '\' + Cbx3DList.Text;
    // TODO insert newlines and tabs for output
    // WPlayer.Log('Delphi ( MainForm )', options.ToString());
    // ShowMessage('Delphi ( MainForm )' + options.ToString());
    // ShowMessage('Delphi ( MainForm )' + WPlayer.OptionsToString(options));
//    WPlayer.Log('Delphi ( MainForm )', WPlayer.OptionsToString(options));
//    WPlayer.LoadFile(options);
end;

procedure TForm1.BtnPlayAudioClick(Sender: TObject);
var options: OWPlayer;
begin
    options := OWPlayerDefault;
    options.Name := 'Audio Player:';
    options.MediaType := 'AUDIO';
    // relative path to book
    options.FilePath := 'audio' + '/' + CbxAudioList.Text;
    options.RootDir := GetBookDir();
    options.WindowSize := '240,140';
    options.WindowPos := 'CENTER'; // center on screen or set pos exam(100,200)
    WPlayer.Log('Delphi ( MainForm )', WPlayer.OptionsToString(options));
    WPlayer.LoadFile(options);
end;

procedure TForm1.BtnPlayImagesClick(Sender: TObject);
var options: OWPlayer;
begin
    options := OWPlayerDefault;
    options.Name := 'Image Player:';
    options.MediaType := 'IMAGES';
    // IMAGE_ID ( 24_01_01 )
    // 24 > page     > number of current page
    // 01 > set      > group of images
    // 01 > count    > sequence index
    options.ButtonID = CbxAudioList.Text;

    options.FilePath := 'audio' + '/' + CbxAudioList.Text;
    options.RootDir := GetBookDir();
    options.WindowSize := '240,140';
    options.WindowPos := 'CENTER'; // center on screen or set pos exam(100,200)
    WPlayer.Log('Delphi ( MainForm )', WPlayer.OptionsToString(options));
    WPlayer.LoadFile(options);
end;

procedure TForm1.BtnPlayLessonClick(Sender: TObject);
var options: OWPlayer;
begin
    options := OWPlayerDefault;
    options.Name := 'Lesson Player:';
    options.MediaType := 'LESSONS';
    options.RootDir := GetBookDir();
    // relative path to book
    options.FilePath := 'lessons' + '/' + CbxLessonList.Text;
    options.WindowSize := 'FULLSCREEN'; // set window size to full screen
    WPlayer.Log('Delphi ( MainForm )', WPlayer.OptionsToString(options));
    WPlayer.LoadFile(options);
end;

procedure TForm1.BtnPlayVideoClick(Sender: TObject);
begin
    // TODO
end;

// ..............................//
// Initialize Form and Variables
// ..............................//
procedure TForm1.OnFormClose(Sender: TObject; var Action: TCloseAction);
begin
    SaveSettings(CbxUserName, Application.ExeName);
end;

procedure TForm1.OnFormShown(Sender: TObject);
begin
    // ShowMessage('From was shown.');
    WalkerPlayer.CreateWPlayerInstance();
    FillListsByType();
    ReadSettings(CbxUserName, Application.ExeName);
end;

// ..............................//
// Test Events
// ..............................//
procedure TForm1.BtnSayHelloClick(Sender: TObject);
var
    msg, dir: string;
begin
    dir := GetBookDir();
    msg := '>'+ #13#10 +'[ Mr.' + CbxUserName.Text + ' ]'  +
      #13#10 + 'Book path was se to >' + #13#10 + '[ ' + dir + ' ]';
    WPlayer.SayHello(msg);
end;
end.