program delphtest;

uses
  Vcl.Forms,
  Unit1 in 'C:\Aprog\Orien\FlashC#\PubliBridge\Create_Load_Dll_005\Delphi\Unit1.pas' {Form1};

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.