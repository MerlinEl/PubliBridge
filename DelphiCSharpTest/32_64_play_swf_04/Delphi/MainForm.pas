// https://docwiki.embarcadero.com/RADStudio/Sydney/en/Default_Keyboard_Shortcuts

unit MainForm;

interface

uses
    Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants,
    System.Classes, Vcl.Graphics, StrUtils, Math, IOUtils,
    Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Vcl.ExtCtrls,
    Vcl.ButtonGroup, Generics.Collections, TypInfo, WalkerPlayer,
    Data.Bind.EngExt, Vcl.Bind.DBEngExt, Data.Bind.Components;

type
    TForm1 = class(TForm)
        GroupBox6: TGroupBox;
        TxtConsole: TMemo;
        grpOptions: TGroupBox;
        Button1: TButton;
        BtnOpenCSharpPanel: TButton;
    EdtUserName: TLabeledEdit;
        procedure BtnSayHelloClick(Sender: TObject);
        procedure OnFormShown(Sender: TObject);
        procedure BtnOpenCSharpPanelClick(Sender: TObject);
    private
        { Private declarations }
    public
        { Public declarations }
        procedure Log(Str: string);
        procedure LogClear();
    end;

var
    Form1: TForm1;

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
// Button Events
// ..............................//
procedure TForm1.BtnOpenCSharpPanelClick(Sender: TObject);
begin
   WPlayer.ShowPanel(true);
end;

procedure TForm1.BtnSayHelloClick(Sender: TObject);
var
    msg: string;
begin
    msg := '>' + #13#10 + '[ Mr.' + EdtUserName.Text + ' ]';
    WPlayer.SayHello(msg);
end;

// ..............................//
// Initialize Form and Variables
// ..............................//
procedure TForm1.OnFormShown(Sender: TObject);
begin
    // ShowMessage('From was shown.');
    Log('OnFormShown > Initializing CSharp DLL Start!');
    WalkerPlayer.CreateWPlayerInstance();
    Log('OnFormShown > Initializing CSharp DLL Done!');
end;

end.
