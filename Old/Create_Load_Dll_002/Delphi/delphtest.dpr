program delphtest;

uses
  Vcl.Forms,
  Unit1 in 'E:\Aprog\Orien\FlashC#\PubliBridge\Create_Load_Dll_002\Unit1.pas' {Form1};

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
