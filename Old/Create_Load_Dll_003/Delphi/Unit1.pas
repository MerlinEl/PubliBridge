// https://docwiki.embarcadero.com/RADStudio/Sydney/en/Default_Keyboard_Shortcuts

unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants,
  System.Classes, Vcl.Graphics, StrUtils, Math,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Vcl.ExtCtrls;

type
  TForm1 = class(TForm)
    Label2: TLabel;
    TxtConsole: TMemo;
    GroupBox1: TGroupBox;
    Label1: TLabel;
    Label3: TLabel;
    BtnMin: TButton;
    EdtValA: TEdit;
    EdtValB: TEdit;
    BtnMax: TButton;
    GroupBox2: TGroupBox;
    Label4: TLabel;
    BtnSayHello: TButton;
    EdtName: TEdit;
    BtnMsgBox: TButton;
    Button1: TButton;
    GroupBox3: TGroupBox;
    Button2: TButton;
    procedure BtnMinClick(Sender: TObject);
    procedure BtnMaxClick(Sender: TObject);
    procedure BtnSayHelloClick(Sender: TObject);
    procedure BtnShowMsgStrClick(Sender: TObject);
    procedure BtnShowMsgIntClick(Sender: TObject);
    procedure OnFormCreate(Sender: TObject);
    procedure BtnShowPanelClick(Sender: TObject);
    procedure BtnShowSWFPanel(Sender: TObject);

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
// Here declare functions which should be found externally, in the dll
function Min(i, j: Integer): Integer; stdcall; external 'cshpdll.dll';
function SayHello(s: String): Integer; stdcall; external 'cshpdll.dll';
procedure ShowMsgBoxInt(n: Integer); external 'cshpdll.dll';
procedure ShowMsgBoxStr(s: String); external 'cshpdll.dll';
procedure ShowGalleryPanel(); external 'cshpdll.dll';
procedure ShowSWFPanel(); external 'cshpdll.dll';

// This procedure uses the "external" call to the DLL
procedure TForm1.BtnMinClick(Sender: TObject);
var
  i, j: Integer;

begin
  i := strtoint(EdtValA.Text);
  j := strtoint(EdtValB.Text);
  TxtConsole.Lines.Append(inttostr(Min(i, j)));
  // Easy, eh?
end;


// This calls the DLL directly through the Win API.
// More code, more control.

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
      TxtConsole.Lines.Append(inttostr(k));
    end;

    // Unload library
    FreeLibrary(Handle);
  end;
end;

// Test Call a String
procedure TForm1.BtnSayHelloClick(Sender: TObject);
var
  userName, msg: String;

begin
  userName := EdtName.Text;
  msg := inttostr(SayHello(userName));
  TxtConsole.Lines.Append(msg);
end;

procedure TForm1.BtnShowMsgIntClick(Sender: TObject);
begin
  ShowMessage('Msg:' + EdtName.Text + ' length:' +
    inttostr(length(EdtName.Text)));
  ShowMsgBoxInt(length(EdtName.Text));
end;

procedure TForm1.BtnShowMsgStrClick(Sender: TObject);
var
  str: String;

begin
  // str := StringReplace(EdtName.Text, '''', '"', [rfReplaceAll]);
  // ShowMsgBoxStr(str);
  // ShowMsgBoxStr(PAnsiChar(AnsiString(EdtName.Text)));
  ShowMsgBoxStr(EdtName.Text);

end;

procedure TForm1.BtnShowPanelClick(Sender: TObject);
begin
  ShowGalleryPanel();
end;

procedure TForm1.OnFormCreate(Sender: TObject);
begin
  // newLine := IfThen(next_line, sLineBreak, '');
  // ShowMessage('From was Created.');
end;

procedure TForm1.BtnShowSWFPanel(Sender: TObject);
begin
   ShowSWFPanel();
end;

end.
