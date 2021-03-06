unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants,
  System.Classes, Vcl.Graphics, StrUtils, Math,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Vcl.ExtCtrls;

type
  TForm1 = class(TForm)
    EdtValA: TEdit;
    EdtValB: TEdit;
    BtnMin: TButton;
    BtnMax: TButton;
    Label2: TLabel;
    Panel1: TPanel;
    TxtConsole: TMemo;
    procedure BtnMinClick(Sender: TObject);
    procedure BtnMaxClick(Sender: TObject);

  private
    { Private declarations }
  var
    next_line: boolean;
  public
    { Public declarations }
  end;

  // TMaxFun becomes a function variable (think of
  // a "pointer to function" without the pointer)

  TMaxFun = function(i, j: Integer): Integer; stdcall;

var
  Form1: TForm1;
  X: Integer;

implementation

{$R *.DFM}
// This declares Min as a function which should be found
// externally, in the dll
function Min(i, j: Integer): Integer; stdcall; external 'delhpdll.dll';

// This procedure uses the "external" call to the DLL
procedure TForm1.BtnMinClick(Sender: TObject);
var
  i, j: Integer;
  newLine: string;

begin
  i := strtoint(EdtValA.Text);
  j := strtoint(EdtValB.Text);
  newLine := IfThen(next_line, sLineBreak, '');
  next_line := true;
  TxtConsole.Text := TxtConsole.Text + newLine + inttostr(Min(i, j));
  // Easy, eh?
end;


// This calls the DLL directly through the Win API.
// More code, more control.

procedure TForm1.BtnMaxClick(Sender: TObject);
var
  i, j, k: Integer;
  Handle: THandle;
  newLine: string;

  // mmax is a function variable; see type declaration
  // of TMaxFun above.
  mmax: TMaxFun;

begin
  i := strtoint(EdtValA.Text);
  j := strtoint(EdtValB.Text);

  // Load the library
  Handle := LoadLibrary('DELHPDLL.DLL');

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
      newLine := IfThen(next_line, sLineBreak, '');
      next_line := true;
      TxtConsole.Text := TxtConsole.Text + newLine + inttostr(k);
    end;

    // Unload library
    FreeLibrary(Handle);
  end;
end;

// When app open's
Initialization

// After app closed
Finalization

//ShowMessage('Tester was Closed.');

end.
