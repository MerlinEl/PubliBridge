using PeerstPlayer.Controls.PecaPlayer;

namespace PeerstPlayer.Shortcut.Command {
    /// <summary>
    /// LoadSWF command
    /// </summary>
    class LoadSWFCommand : IShortcutCommand {
        private PecaPlayerControl pecaPlayer;

        public LoadSWFCommand(PecaPlayerControl pecaPlayer) {
            this.pecaPlayer = pecaPlayer;
        }

        void IShortcutCommand.Execute(CommandArgs commandArgs) {

            pecaPlayer.OpenTest(@"C:\Aprog\Orien\FlashC#\Test\_promise\PeerstPlayer-master\src\TestPeertPlayer\TestData\movie.wmv");
        }

        string IShortcutCommand.GetDetail(CommandArgs commandArgs) {
            return "LoadSWF";
        }
    }
}
