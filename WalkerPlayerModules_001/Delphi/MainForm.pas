// https://docwiki.embarcadero.com/RADStudio/Sydney/en/Default_Keyboard_Shortcuts

unit MainForm;

interface

uses
    Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants,
    System.Classes, Vcl.Graphics, StrUtils, Math, IOUtils,
    Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Vcl.ExtCtrls,
    Vcl.ButtonGroup, Generics.Collections, TypInfo, WalkerPlayerCmd,
    WalkerPlayerOptions, MainFormSettings, WalkerPlayerUtils, WalkerPlayer,
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
        CbxImageList: TComboBox;
        lbl8: TLabel;
        ChkEscapeEnabled: TCheckBox;
        ChkAutoPlay: TCheckBox;
        ChkHiddenPlayer: TCheckBox;
        ChkHiddenConsole: TCheckBox;
        CbxLessonList: TComboBox;
        CbxBookDir: TComboBox;
        lbl9: TLabel;
        Button1: TButton;
        ChkResizable: TCheckBox;
        EdtUserName: TEdit;
        CbxWindowSize: TComboBox;
        Label4: TLabel;
        lbl2: TLabel;
        BtnBrowseDir: TButton;
        procedure BtnSayHelloClick(Sender: TObject);
        procedure OnFormShown(Sender: TObject);
        procedure BtnPlayLessonClick(Sender: TObject);
        procedure BtnPlayVideoClick(Sender: TObject);
        procedure BtnPlayAudioClick(Sender: TObject);
        procedure BtnPlayImagesClick(Sender: TObject);
        procedure BtnPlay3DClick(Sender: TObject);
        procedure OnUserDirectoryChanged(Sender: TObject);
        procedure OnBookDirectoryChanged(Sender: TObject);
    procedure BtnBrowseDirClick(Sender: TObject);
    private
        { Private declarations }
    public
        { Public declarations }
        procedure Log(Str: string);
        procedure LogClear();
    end;

var Form1: TForm1;

implementation

{$R *.DFM}

// ..............................//
// Form Public Methods
// ..............................//
procedure TForm1.Log(Str: String);
begin
    Form1.TxtConsole.Lines.Append(Str);
end;
procedure TForm1.LogClear();
begin
  Form1.TxtConsole.Lines.Clear();
end;

// ..............................//
// Get options from Interface
// ..............................//
function GetWPOptions(): OWPlayer;
var
    options: OWPlayer;
begin

    options := OWPlayerDefault;
    options.BookDir := GetBookDir();
    options.HiddenPlayer := BoolToInt(Form1.ChkHiddenPlayer.Checked);
    options.HiddenConsole := BoolToInt(Form1.ChkHiddenConsole.Checked);
    options.AutoPlay := BoolToInt(Form1.ChkAutoPlay.Checked);
    options.EscapeEnabled := BoolToInt(Form1.ChkEscapeEnabled.Checked);
    options.Resizable := BoolToInt(Form1.ChkResizable.Checked);
    options.WindowSize := Form1.CbxWindowSize.Text;
    Result := options;
end;

// ..............................//
// Button Events
// ..............................//
procedure TForm1.OnUserDirectoryChanged(Sender: TObject);
begin
    FillMediaListByType();
end;

procedure TForm1.OnBookDirectoryChanged(Sender: TObject);
begin
    FillMediaListByType();
end;

procedure TForm1.BtnPlayAudioClick(Sender: TObject);
begin
    PlayAudio(GetWPOptions(), CbxAudioList.Text);
end;

procedure TForm1.BtnPlayImagesClick(Sender: TObject);
begin
    PlayImages(GetWPOptions(), CbxImageList.Text);
end;

procedure TForm1.BtnPlayLessonClick(Sender: TObject);
begin
   PlayLesson(GetWPOptions(), CbxLessonList.Text);
end;

procedure TForm1.BtnPlayVideoClick(Sender: TObject);
begin
    PlayVideo(GetWPOptions(), CbxVideoList.Text);
end;

procedure TForm1.BtnBrowseDirClick(Sender: TObject);
begin
    with TFileOpenDialog.Create(nil) do
        try
            options := [fdoPickFolders];
            if Execute then
            begin
                EdtUserName.Text := 'Pan Chcitojinak';
                CbxBookDir.Items.Add(FileName);
                CbxBookDir.ItemIndex := CbxBookDir.Items.Count-1;
                LogClear();
                Log('-----------------------------------');
                Log('Book directory was set to:' + FileName);
                Log('-----------------------------------');
                FillMediaListByType();
            end;
        finally
            Free;
        end;
end;

procedure TForm1.BtnPlay3DClick(Sender: TObject);
begin
    Play3D(GetWPOptions(), Cbx3DList.Text);
end;

// ..............................//
// Initialize Form and Variables
// ..............................//
procedure TForm1.OnFormShown(Sender: TObject);
begin
    // ShowMessage('From was shown.');
    WalkerPlayer.CreateWPlayerInstance();
    EdtUserName.Text := GetUserName();
    FillMediaListByType();
end;

// ..............................//
// Test Events
// ..............................//
procedure TForm1.BtnSayHelloClick(Sender: TObject);
var
    msg, dir: string;
begin
    dir := GetBookDir();
    msg := '>' + #13#10 + '[ Mr.' + EdtUserName.Text + ' ]' + #13#10 +
      'Book path was se to >' + #13#10 + '[ ' + dir + ' ]';
    WPlayer.SayHello(msg);
end;
end.



