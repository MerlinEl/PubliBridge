unit WalkerPlayer;

interface

uses
  Winapi.Windows;

// ...................//
// External DLL SETUP //
// ...................//

// Walker Player Interface (should be found externally, in the dll)
type
  IWPlayer = interface(IInterface)
    ['{01aa1059-93b4-40a2-b9da-447d8156deb6}']
    procedure Log(tabName, msg: WideString); safecall;
    procedure SayHello(a: WideString); safecall;
    procedure ShowPanel(state: Boolean); safecall;
  end;

  // Define a local variable which will hold class instance
var
  WPlayer: IWPlayer;

  // Public methods declaration
function CreateWPlayerInstance(): IWPlayer;

implementation

// Call this method to create instance from external DLL Class
function CreateWPlayerInstance(): IWPlayer;
type
  TFunc = function(var i: IWPlayer): Boolean; stdcall;
var
  Lhnd: THandle;
  Lfunc: TFunc;
  // Lif: IInterface;
  LifPlayer: IWPlayer;
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

end.
