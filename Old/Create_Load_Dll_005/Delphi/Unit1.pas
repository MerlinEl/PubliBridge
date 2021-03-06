// https://docwiki.embarcadero.com/RADStudio/Sydney/en/Default_Keyboard_Shortcuts

unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants,
  System.Classes, Vcl.Graphics, StrUtils, Math, IOUtils,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Vcl.ExtCtrls,
  Vcl.ButtonGroup;

type
  TForm1 = class(TForm)
    GroupBox4: TGroupBox;
    GroupBox5: TGroupBox;
    GroupBox1: TGroupBox;
    BtnMin: TButton;
    BtnMax: TButton;
    GroupBox2: TGroupBox;
    Label4: TLabel;
    BtnSayHello: TButton;
    EdtName: TEdit;
    GroupBox3: TGroupBox;
    BtnShowGalleryPanel: TButton;
    Button2: TButton;
    GroupBox6: TGroupBox;
    TxtConsole: TMemo;
    GroupBox7: TGroupBox;
    BtnInst: TButton;
    Button3: TButton;
    BtnLoadClass: TButton;
    grp1: TGroupBox;
    BtnInstShowSWFPanel: TButton;
    BtnInstShowGalleryPanel: TButton;
    lbl1: TLabel;
    lbl2: TLabel;
    EdtValB: TEdit;
    EdtValA: TEdit;
    GroupBox8: TGroupBox;
    lbl3: TLabel;
    BtnLoadFlFromPath: TButton;
    BtnInstLoadFile: TButton;
    CbxSwfNames: TComboBox;
    lbl4: TLabel;
    CbxSwfPaths: TComboBox;
    BtnBrowseDir: TButton;
    procedure BtnMinClick(Sender: TObject);
    procedure BtnMaxClick(Sender: TObject);
    procedure BtnSayHelloClick(Sender: TObject);
    procedure OnFormCreate(Sender: TObject);
    procedure BtnShowSWFPanel(Sender: TObject);
    procedure BtnInstPlusClick(Sender: TObject);
    procedure BtnInstAddClick(Sender: TObject);
    procedure BtnShowGalleryPanelClick(Sender: TObject);
    procedure BtnInstShowGalleryPanelClick(Sender: TObject);
    procedure BtnInstShowSWFPanelClick(Sender: TObject);
    procedure BtnLoadFlFromPathClick(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure BtnInstLoadFileClick(Sender: TObject);
    procedure BtnBrowseDirClick(Sender: TObject);
    procedure OnDirectoryChanged(Sender: TObject);

  private
    { Private declarations }
  public
    { Public declarations }
  end;

  // TMaxFun becomes a function variable (think of
  // a "pointer to function" without the pointer)
  TMaxFun = function(i, j: Integer): Integer; stdcall;

var
  Form1: TForm1;

implementation

{$R *.DFM}

// ..............................//
// External DLL Class Instance
// ..............................//
// Here declare interface which should be found externally, in the dll
type
  IWPlayer = interface(IInterface)
    ['{ab7026b2-02d5-4eea-8f35-6bc69037dba1}']
    function IAdd: Integer; safecall;
    function IPlus(a, b: Integer): Integer; safecall;
    procedure ISayHello(a, b : WideString); safecall;
    procedure IShowSWFPanelWithPath(a : WideString); safecall;
    procedure IShowSWFPanel(); safecall;
    procedure IShowGallery(); safecall;
  end;
// Define a local variable which will hold class instance
var
  WPlayer: IWPlayer;
// Method call this method to create class instance
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
  Lhnd := LoadLibrary('cshpdll.dll');
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
// External DLL Static Methods
// ..............................//
// Here declare functions which should be found externally, in the dll
function Min(i, j: Integer): Integer; stdcall; external 'cshpdll.dll';
function CombineStrings(a, b: WideString): WideString; stdcall; external 'cshpdll.dll';
procedure ShowGalleryPanel(); external 'cshpdll.dll';
procedure ShowSWFPanel(); external 'cshpdll.dll';
procedure ShowSWFPanelWithPath(a :string); external 'cshpdll.dll';


// ..............................//
// Utility Methods
// ..............................//
procedure Log(Str: String);
begin
  Form1.TxtConsole.Lines.Append(Str);
end;
procedure FillSWFList(dir:string);
var path : string;
begin
  if not DirectoryExists(dir)then
    ShowMessage('Directory not found.\n' + dir)
  else begin
    Log('Fill SWF List from dir:'+dir);
    Form1.CbxSwfNames.Clear();
    begin
      for path in TDirectory.GetFiles(dir, '*.swf')  do
          Form1.CbxSwfNames.Items.Add(extractfilename(path));
    end;
      if Form1.CbxSwfNames.Items.Count > 0 then
        Form1.CbxSwfNames.ItemIndex := 0;
  end;
end;

// ..............................//
// Events
// ..............................//
// This procedure uses the "external" call to the DLL
procedure TForm1.BtnMinClick(Sender: TObject);
begin
  Log('Min:'+inttostr(Min(
     strtoint(EdtValA.Text),
     strtoint(EdtValB.Text)
  )));
end;



// This calls the DLL directly through the Win API.
// More code, more control.

procedure TForm1.BtnInstLoadFileClick(Sender: TObject);
begin
   WPlayer.IShowSWFPanelWithPath(CbxSwfPaths.Text + CbxSwfNames.Text);
end;

procedure TForm1.BtnInstPlusClick(Sender: TObject);
begin
  Log('Plus:'+inttostr(WPlayer.IPlus(
    strtoint(EdtValA.Text),
    strtoint(EdtValB.Text)
  )));
end;

procedure TForm1.BtnInstShowGalleryPanelClick(Sender: TObject);
begin
  WPlayer.IShowGallery();
end;

procedure TForm1.BtnInstShowSWFPanelClick(Sender: TObject);
begin
 WPlayer.IShowSWFPanel();
end;

procedure TForm1.BtnLoadFlFromPathClick(Sender: TObject);
begin

  ShowSWFPanelWithPath(CbxSwfPaths.Text + CbxSwfNames.Text);
end;


procedure TForm1.BtnBrowseDirClick(Sender: TObject);
begin
 with TFileOpenDialog.Create(nil) do
  try
    Options := [fdoPickFolders];
      if Execute then begin
        CbxSwfPaths.Items.BeginUpdate();
        CbxSwfPaths.Items.Add(FileName + '\');
        CbxSwfPaths.Items.EndUpdate();
        CbxSwfPaths.ItemIndex := CbxSwfPaths.Items.Count -1;
        FillSWFList(CbxSwfPaths.Text);
      end;
  finally
    Free;
  end;
end;

procedure TForm1.BtnInstAddClick(Sender: TObject);
begin
  Log('Add:'+WPlayer.IAdd().ToString());
end;

procedure TForm1.BtnSayHelloClick(Sender: TObject);
begin
  Log(CombineStrings('Ahoj', 'Dalibore.'));
end;

procedure TForm1.OnDirectoryChanged(Sender: TObject);
begin
  FillSWFList(CbxSwfPaths.Text);
end;

procedure TForm1.OnFormCreate(Sender: TObject);
begin
  CreateWPlayerInstance();
  // ShowMessage('From was Created.');
end;

procedure TForm1.BtnShowGalleryPanelClick(Sender: TObject);
begin
   ShowGalleryPanel();
end;

procedure TForm1.BtnShowSWFPanel(Sender: TObject);
begin
  ShowSWFPanel();
end;

procedure TForm1.Button3Click(Sender: TObject);
begin
  WPlayer.ISayHello('Hello', EdtName.Text);
end;

procedure TForm1.BtnMaxClick(Sender: TObject);
var
  i, j, k: Integer;
  Handle: THandle;

  // mmax is a function variable; see type declaration
  // of TMaxFun above.
  mmax: TMaxFun;

begin
  i := strtoint(EdtValA.Text);
  j := strtoint(EdtValB.Text);

  // Load the library
  Handle := LoadLibrary('cshpdll.dll');

  // If succesful ...

  if Handle <> 0 then
  begin

    // Assign function Max from the DLL to the
    // function variable mmax
    @mmax := GetProcAddress(Handle, 'Max');

    // If successful

    if @mmax <> nil then
    begin
      k := mmax(i, j);
      Log('Max:'+inttostr(k));
    end;

    // Unload library
    FreeLibrary(Handle);
  end;
end;

end.
