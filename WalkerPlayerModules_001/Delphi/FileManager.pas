unit FileManager;

interface

uses
  Winapi.Windows, System.StrUtils, System.SysUtils, Dialogs,
  System.IOUtils, Vcl.StdCtrls;

// Public static method declaration
procedure FillSWFList(cbx: TComboBox; dir, extension: string);

implementation

// ..............................//
// Form Methods
// ..............................//

procedure FillSWFList(cbx: TComboBox; dir, extension: string);
var
  path: string;
begin
  if not DirectoryExists(dir) then
    ShowMessage('FileManager > FillSWFList > Directory not found at:' + dir)
  else
  begin
    cbx.Clear();
    begin
      for path in TDirectory.GetFiles(dir, '*.' + extension) do
        cbx.Items.Add(extractfilename(path));
    end;
    if cbx.Items.Count > 0 then
      cbx.ItemIndex := 0;
  end;

  // -------------------------------------//
  // Debug only (select item Walker.swf) //

  if (cbx.Items.Count > 0) then
  begin
    var
      index: Integer;
    index := cbx.Items.IndexOf('Walker.swf');
    if index > -1 then
    begin
      cbx.ItemIndex := index;
    end;
  end;

  // Debug only (select item Walker.swf) //
  // -------------------------------------//

end;

end.
