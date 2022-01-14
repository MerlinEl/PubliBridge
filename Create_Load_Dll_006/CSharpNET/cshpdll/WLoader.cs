using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace cshpdll {
    public partial class WLoader : Form {
        
        private bool Form_Was_Loaded = false;
        private readonly string Fixed_Item_Name = "Add...";

        public WLoader() {
            InitializeComponent();
        }

        private void BtnLoad_Click(object sender, EventArgs e) => LoadFileFromEditBox();

        private void BtnPlay_Click(object sender, EventArgs e) {
            if (FLComponent.Movie != null) FLComponent.Playing = true;
        }

        private void BtnStop_Click(object sender, EventArgs e) {
            if (FLComponent.Movie != null) FLComponent.Playing = false;
        }

        public void LoadFileFromEditBox() {

            if (CbxSWFDirs.Items.Count == 0 || CbxSWFFnames.Items.Count == 0) return;
            LoadFile(CbxSWFDirs.Text + @"\" + CbxSWFFnames.Text);
        }

        public void LoadFile(string fpath) {

            if (!File.Exists(fpath)) throw new FileNotFoundException("This file was not found.\n" + fpath);
            //MessageBox.Show("LoadFile.\n" + fpath, "CSharp MessageBox:");
            //FLComponent.Dispose();
            //FLComponent.LoadMovie(0, fpath);
            //FLComponent.Loop = false;
            //FLComponent.Controls.Clear();
            //Console.WriteLine("UnloadSWF > haschildren:{0}", );
            if (FLComponent.Movie != null) UnloadSWF();
            FLComponent.Movie = fpath;
            FLComponent.Playing = false;
        }

        private void UnloadSWF() {
            //FLComponent.Dock = System.Windows.Forms.DockStyle.Fill;
            //FLComponent.Enabled = true;
            //FLComponent.Location = new System.Drawing.Point(0, 0);
            //FLComponent.Name = "flashMovie";
            //FLComponent.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("flashMovie.OcxState")));
            //FLComponent.Size = new System.Drawing.Size(571, 367);
            //FLComponent.TabIndex = 0;
            //var loader:Loader = new Loader();
            //loader.unloadAndStop(); //unload all content, do some garbage cleanup
            //mov_contentLoader.removeChildAt(0); //just to be safe, a second layer of reassurance ??
            //loader.contentLoaderInfo.addEventListener(Event.UNLOAD, cleanUp);

            //function cleanUp(e:Event):void{
            //    SoundMixer.stopAll(); //stop all sounds...
            //}
            Console.WriteLine("UnloadSWF > fpath:{0} components:{1}", FLComponent.Movie, FLComponent.EmbedMovie);
        }

        private void FillDirs(List<string> swfDirs) {
            // Add Folders and fixedItemName item or add only fixedItemName item
            swfDirs.ForEach(dir => {

                CbxSWFDirs.Items.Add(dir);
            });
            CbxSWFDirs.Items.Add(Fixed_Item_Name); // interactive item fixedItemName should be last
            CbxSWFDirs.SelectedIndex = 0;
        }

        private void FillFnames() {

            CbxSWFFnames.Items.Clear();
            if (CbxSWFDirs.Items.Count < 2) return; // wee not count fixedItemName
            var swfDir = CbxSWFDirs.Text;
            if (swfDir == Fixed_Item_Name) return; // skip this choice
            if (!Directory.Exists(swfDir)) return;
            List<string> swfFiles = new List<string>(Directory.GetFiles(swfDir, "*.swf")); //, SearchOption.AllDirectories
            if (swfFiles.Count == 0) return;
            swfFiles.ForEach(fpath => {

                CbxSWFFnames.Items.Add(Path.GetFileName(fpath));
            });
            CbxSWFFnames.SelectedIndex = 0;
        }

        private void OnFormShown(object sender, EventArgs e) {

            ReadSettings();
            Form_Was_Loaded = true;
        }

        private void ReadSettings() {

            // Read settings and fill dirs ( select first dir )
            FillDirs(Properties.Settings.Default.SWFPaths.Cast<string>().ToList());
            // Fill fnames from selected dir
            FillFnames();
        }

        private void OnSWFDirListSelection(object sender, EventArgs e) {

            if (!Form_Was_Loaded) return;
            Console.WriteLine("OnSWFDirListSelection > dir:{0}", CbxSWFDirs.Text);
            if (CbxSWFDirs.Text == Fixed_Item_Name) {
                AddNewDir();
            } else {
                FillFnames();
            }
        }
        private void OnSWFDirListKeyUp(object sender, KeyEventArgs e) {

            // Not allowed to delete on single item in list or "Add.." is selected.
            string selItemName = CbxSWFDirs.Text;
            if (CbxSWFDirs.Items.Count < 2 || selItemName == Fixed_Item_Name) return; // one item fixedItemName can't be removed
            // Ask for remove
            DialogResult dialogResult = MessageBox.Show("Remove path:" + selItemName + "?", "Remove path from list:", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No) return;
            // Remove selected item in CbxSWFDirs
            if (e.KeyCode == Keys.Delete) {
                if (CbxSWFDirs.SelectedIndex != -1) {

                    CbxSWFDirs.Items.Remove(CbxSWFDirs.SelectedItem);
                    Properties.Settings.Default.SWFPaths.Remove(selItemName);
                    Properties.Settings.Default.Save();
                }
                CbxSWFDirs.SelectedIndex = 0; // select first item in list
            }
        }

        private void AddNewDir() {
            using (var fbd = new FolderBrowserDialog()) {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath)) {
                    // insetr item before fixedItemName
                    CbxSWFDirs.Items.Insert(CbxSWFDirs.Items.Count - 1, fbd.SelectedPath);
                    CbxSWFDirs.SelectedIndex = CbxSWFDirs.Items.Count - 2;
                    Properties.Settings.Default.SWFPaths.Add(fbd.SelectedPath);
                    Properties.Settings.Default.Save();
                    FillFnames();
                }
            }
        }


    }
}
//String path = Application.StartupPath +@"\"+ Tbx_Swf_Path.Text;
//string swfPath = System.Environment.CurrentDirectory;
/*
 * // Loading a Flash movie from a memory stream or a byte array
System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YourForm));
System.Byte[] data = (System.Byte[])(resources.GetObject("FileName"));
*/
/*
public partial class Form1 : Form
{
    private AxShockwaveFlashObjects.AxShockwaveFlash axFlash;

    public Form1()
    {
        InitializeComponent();

        axFlash = new AxShockwaveFlashObjects.AxShockwaveFlash();  
        axFlash.BeginInit();  
        axFlash.Location = new Point(50, 50);  
        axFlash.Name = "Load/unload test";  
        axFlash.TabIndex = 0; 
        axFlash.EndInit(); 
    }

    private void startButton_Click(object sender, EventArgs e)
    {
        axFlash = new AxShockwaveFlashObjects.AxShockwaveFlash();
        axFlash.BeginInit();
        axFlash.Location = new Point(50, 80);
        axFlash.Name = "Test Movie";
        axFlash.TabIndex = 0;

        axFlash.Size = new Size(640, 480);
        axFlash.EndInit();
        this.Controls.Add(axFlash);
        axFlash.LoadMovie(0, @"C:\Movies\MyMovie.swf");
    }

    private void unloadButton_Click(object sender, EventArgs e)
    {
        this.Controls.Remove(axFlash);
    }
}
 */