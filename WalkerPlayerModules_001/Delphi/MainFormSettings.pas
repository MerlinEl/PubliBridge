unit MainFormSettings;
 {
 //@usage
     OnFormShown > ReadSettings(CbxUserName, Application.ExeName);
     OnFormClose > SaveSettings(CbxUserName, Application.ExeName);
 }
interface

uses inifiles, System.SysUtils, System.Classes, Vcl.StdCtrls, Vcl.Dialogs,
  System.IOUtils;

procedure ReadSettings(cbx: TComboBox; appName: string);
procedure SaveSettings(cbx: TComboBox; appName: string);

implementation

procedure ClearIniSection(fpath: string);
var
  FIni: TMemIniFile;
  N, V: string;
  Sections: TStringList;
  i: Integer;
begin
  FIni := TMemIniFile.Create(fpath);
  if Assigned(FIni) then
    try
      Sections := TStringList.Create;
      // ShowMessage('section exists:' + FIni.SectionExists('Users').ToString());
      FIni.EraseSection('Users');
      FIni.UpdateFile();
    finally
      FIni.Free;
    end;
end;

procedure SaveSettings(cbx: TComboBox; appName: string);
var
  FIni: TINIFile;
  fpath: string;
  i: Integer;
begin
  fpath := ChangeFileExt(appName, '.ini');
  if not TFile.Exists(fpath) then
    FileClose(FileCreate(fpath));
  ClearIniSection(fpath);
  FIni := TINIFile.Create(fpath);
  if Assigned(FIni) and (cbx.Items.Count > 0) then
    try
      for i := 0 to cbx.Items.Count - 1 do
      begin
        FIni.WriteString('Users', 'label_' + i.ToString(), cbx.Items[i]);
      end;
    finally
      FIni.Free;
    end;
end;

procedure ReadSettings(cbx: TComboBox; appName: string);
var
  FIni: TMemIniFile;
  fpath, N, V: string;
  Sections: TStringList;
  i: Integer;
begin
  fpath := ChangeFileExt(appName, '.ini');
  if not TFile.Exists(fpath) then
    Exit; // missing settings file
  // ShowMessage('ReadSettings > fpath:' + fpath);
  FIni := TMemIniFile.Create(fpath);
  if Assigned(FIni) then
    try
      cbx.Items.Clear;
      Sections := TStringList.Create;
      FIni.ReadSectionValues('Users', Sections);
      for i := 0 to (Sections.Count - 1) do
      begin
        N := Sections.Names[i]; // The Name
        V := Sections.Values[N]; // The Value
        cbx.Items.Add(V);
      end;
      if cbx.Items.Count > 0 then
        cbx.ItemIndex := 0;
    finally
      FIni.Free;
    end;
end;

end.
