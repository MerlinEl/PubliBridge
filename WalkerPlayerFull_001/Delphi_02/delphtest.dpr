program delphtest;

uses
  Vcl.Forms,
  MainForm in 'MainForm.pas' {Form1} ,
  WalkerPlayerOptions in 'WalkerPlayerOptions.pas',
  WalkerPlayer in 'WalkerPlayer.pas',
  FileManager in 'FileManager.pas';

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TForm1, Form1);
  Application.Run;

end.
