// https://docwiki.embarcadero.com/RADStudio/Sydney/en/Default_Keyboard_Shortcuts

unit MainForm;

interface

uses
    Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants,
    System.Classes, Vcl.Graphics, StrUtils, Math, IOUtils,
    Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Vcl.ExtCtrls,
    Vcl.ButtonGroup, Generics.Collections, TypInfo, Utils;

type
    TForm1 = class(TForm)
        GroupBox6: TGroupBox;
        TxtConsole: TMemo;
        grp1: TGroupBox;
        BtnShowPlayer: TButton;
        BtnSayHello: TButton;
        CbxBookDirs: TComboBox;
        lbl4: TLabel;
        BtnBrowseDir: TButton;
        EdtName: TEdit;
        Label4: TLabel;
        lbl2: TLabel;
        ChkAutoPlay: TCheckBox;
        lbl3: TLabel;
        CbxSwfFiles: TComboBox;
        CbxSwfDirs: TComboBox;
        ChkFullScreen: TCheckBox;
        ChkHidden: TCheckBox;
        ChkFitToScreen: TCheckBox;
        ChkCenterToScreen: TCheckBox;
        ChkEscapeEnabled: TCheckBox;
        procedure BtnSayHelloClick(Sender: TObject);
        procedure BtnShowPlayerClick(Sender: TObject);
        procedure BtnBrowseDirClick(Sender: TObject);
        procedure OnBookDirectoryChanged(Sender: TObject);
        procedure OnFormShown(Sender: TObject);
        procedure OnSwfDirectoryChanged(Sender: TObject);

    private
        { Private declarations }
    public
        { Public declarations }
    end;

var
    Form1: TForm1;

implementation

{$R *.DFM}
// ...................//
// External DLL SETUP //
// ...................//

// Walker Player Options (used by LoadFile(options))
type
    OWPlayer = record
        _Type: Integer; // Type is a reserved word in Delphi
        Name: PAnsiChar;
        FilePath: WideString; // swf file path
        RootDir: WideString; // directory with xml setting
        Hidden: PChar; // output > True = 1, False =  0
        AutoPlay: PChar;
        FullScreen: PChar;
        FitToScreen: PChar;
        CenterToScreen: PChar;
        EscapeEnabled: PChar;
        //function ToString(options: OWPlayer): string; safecall;
    end;
 {
function OWPlayer.ToString(options: OWPlayer): string; safecall;
var
    msg: WideString;
begin
    msg := '';
    UtilsClass.EnumFields(TypeInfo(OWPlayer));
end;
}

// Walker Player Interface (should be found externally, in the dll)
type
    IWPlayer = interface(IInterface)
        ['{ab7026b2-02d5-4eea-8f35-6bc69037dba1}']
        procedure Log(tabName, msg: WideString); safecall;
        procedure SayHello(a: WideString); safecall;
        procedure ShowPanel(state: Boolean); safecall;
        procedure LoadFile(options: OWPlayer); stdcall;
        procedure UnloadAll(); safecall;
        procedure FullScreen(state: Boolean); safecall;
        function OptionsToString(options : OWPlayer):string; safecall;
    end;

    // ..............................//
    // External DLL Static Methods
    // ..............................//
    // Define a local variable which will hold class instance
var
    WPlayer: IWPlayer;

    // Call this method to create instance from external DLL Class
function CreateWPlayerInstance(): IWPlayer;
type
    TFunc = function(var i: IWPlayer): Boolean; stdcall;
var
    Lhnd: THandle;
    Lfunc: TFunc;
    Lif: IInterface;
    LifPlayer: IWPlayer;
    a: Integer;
    s: WideString;
begin
    Lhnd := LoadLibrary('WalkerPlayer.dll');
    try
        Lfunc := GetProcAddress(Lhnd, 'GetInstance');
        if Lfunc(LifPlayer) then
        begin
            WPlayer := LifPlayer;
            { if Supports(Lif, IWPlayer, LifPlayer) then
              ShowMessage(LifPlayer.IAdd.ToString)
              else
              raise Exception.Create('Error'); }
        end;
    finally
        FreeLibrary(Lhnd);
    end;
end;

// ..............................//
// Utility Methods
// ..............................//
procedure Log(Str: String);
begin
    Form1.TxtConsole.Lines.Append(Str);
end;

procedure FillSWFList(dir: String);
var
    path: string;
begin
    if not DirectoryExists(dir) then
        ShowMessage('Directory not found at:' + dir)
    else
    begin
        Form1.CbxSwfFiles.Clear();
        begin
            for path in TDirectory.GetFiles(dir, '*.swf') do
                Form1.CbxSwfFiles.Items.Add(extractfilename(path));
        end;
        if Form1.CbxSwfFiles.Items.Count > 0 then
            Form1.CbxSwfFiles.ItemIndex := 0;
    end;
    // -------------------------------------//
    // Debug only (select item Walker.swf) //

    if (Form1.CbxSwfFiles.Items.Count > 0) then
    begin
        var
            index: Integer;
        index := Form1.CbxSwfFiles.Items.IndexOf('Walker.swf');
        if index > -1 then
        begin
            Form1.CbxSwfFiles.ItemIndex := index;
        end;
    end;
    Log('FillSWFList > ( ' + Form1.CbxSwfFiles.Items.Count.ToString() +
      ' ) Swf Files from dir:' + dir);

    // Debug only (select item Walker.swf) //
    // -------------------------------------//
end;

function getSubdir(): String;
begin
    Result := IfThen(Form1.CbxSwfDirs.Text = 'root', '', Form1.CbxSwfDirs.Text);
end;

// ..............................//
// Events
// ..............................//
procedure TForm1.BtnShowPlayerClick(Sender: TObject);
var
    fpath: WideString;
    options, Value: OWPlayer;
begin
    // Open walker player and load a file in to it
    fpath := CbxBookDirs.Text + '\' + getSubdir() + '\' + CbxSwfFiles.Text;
    Log('LoadFile > fpath:' + fpath);
    // Set-Up options
    options.Name := 'Walker Player Options.';
    options.FilePath := fpath;
    options.RootDir := CbxBookDirs.Text;
    options.Hidden := PChar(ChkHidden.Checked);
    options.AutoPlay := PChar(ChkAutoPlay.Checked);
    options.FullScreen := PChar(ChkFullScreen.Checked);
    options.CenterToScreen := PChar(ChkCenterToScreen.Checked);
    options.FitToScreen := PChar(ChkFitToScreen.Checked);
    options.EscapeEnabled := PChar(ChkEscapeEnabled.Checked);
    WPlayer.Log('Delphi ( MainForm )', WPlayer.OptionsToString(options));
    // Load Media File (swf)
    WPlayer.LoadFile(options);
end;

procedure TForm1.BtnBrowseDirClick(Sender: TObject);
begin
    with TFileOpenDialog.Create(nil) do
        try
            options := [fdoPickFolders];
            if Execute then
            begin
                CbxBookDirs.Items.BeginUpdate();
                CbxBookDirs.Items.Add(FileName + '\');
                CbxBookDirs.Items.EndUpdate();
                CbxBookDirs.ItemIndex := CbxBookDirs.Items.Count - 1;
                FillSWFList(CbxBookDirs.Text + '\' + getSubdir());
            end;
        finally
            Free;
        end;
end;

procedure TForm1.BtnSayHelloClick(Sender: TObject);
begin
    WPlayer.SayHello('> [ ' + EdtName.Text + ' ]');
end;

procedure TForm1.OnBookDirectoryChanged(Sender: TObject);
begin
    FillSWFList(CbxBookDirs.Text + '\' + getSubdir());
end;

procedure TForm1.OnSwfDirectoryChanged(Sender: TObject);
begin
    FillSWFList(CbxBookDirs.Text + '\' + getSubdir());
end;

procedure TForm1.OnFormShown(Sender: TObject);
begin
    // ShowMessage('From was shown.');
    CreateWPlayerInstance();
    if DirectoryExists(CbxBookDirs.Text + '\' + getSubdir()) then
    begin
        FillSWFList(CbxBookDirs.Text + '\' + getSubdir());
    end;
end;

end.
