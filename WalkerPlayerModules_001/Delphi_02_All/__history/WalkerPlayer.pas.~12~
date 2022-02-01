unit WalkerPlayer;

interface

uses
  Winapi.Windows, WalkerPlayerOptions;

// ...................//
// External DLL SETUP //
// ...................//

// Walker Player Interface (should be found externally, in the dll)
type
  IWPlayer = interface(IInterface)
    ['{59b6c4be-134c-472e-a835-8f60526df3ee}']
    procedure Log(tabName, msg: WideString); safecall;
    procedure SayHello(a: WideString); safecall;
    procedure ShowPanel(state: Boolean); safecall;
    procedure LoadFile(options: OWPlayer); stdcall;
    procedure UnloadAll(); safecall;
    procedure FullScreen(state: Boolean); safecall;
    function OptionsToString(options: OWPlayer): string; safecall;
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
