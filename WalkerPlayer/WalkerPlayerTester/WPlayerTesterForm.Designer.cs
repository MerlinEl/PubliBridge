
namespace WalkerPlayerTester {
    partial class WPlayerTesterForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.BtnLoadSwfFile = new System.Windows.Forms.Button();
            this.LbxPaths = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // BtnLoadSwfFile
            // 
            this.BtnLoadSwfFile.Location = new System.Drawing.Point(12, 100);
            this.BtnLoadSwfFile.Name = "BtnLoadSwfFile";
            this.BtnLoadSwfFile.Size = new System.Drawing.Size(776, 55);
            this.BtnLoadSwfFile.TabIndex = 0;
            this.BtnLoadSwfFile.Text = "Load SWF File";
            this.BtnLoadSwfFile.UseVisualStyleBackColor = true;
            this.BtnLoadSwfFile.Click += new System.EventHandler(this.BtnLoadSwfFile_Click);
            // 
            // LbxPaths
            // 
            this.LbxPaths.FormattingEnabled = true;
            this.LbxPaths.Items.AddRange(new object[] {
            "C:\\Users\\Orien Star\\Dropbox\\PubliBridge\\Interactive\\Dějepis 6\\lessons\\07.swf",
            "C:\\Users\\Orien Star\\Dropbox\\PubliBridge\\Interactive\\Dějepis 6\\lessons\\42.swf",
            "C:\\Users\\Orien Star\\Dropbox\\PubliBridge\\Interactive\\Dějepis 6\\3d\\20_Scene.swf",
            "C:\\Users\\Orien Star\\Dropbox\\PubliBridge\\Interactive\\Dějepis 6\\3d\\stonehenge_01.sw" +
                "f",
            "C:\\Users\\Orien Star\\Dropbox\\PubliBridge\\Interactive\\Dějepis 6\\3d\\sphinx_01.swf"});
            this.LbxPaths.Location = new System.Drawing.Point(12, 12);
            this.LbxPaths.Name = "LbxPaths";
            this.LbxPaths.Size = new System.Drawing.Size(776, 82);
            this.LbxPaths.TabIndex = 1;
            // 
            // WPlayerTesterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 161);
            this.Controls.Add(this.LbxPaths);
            this.Controls.Add(this.BtnLoadSwfFile);
            this.Name = "WPlayerTesterForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnLoadSwfFile;
        private System.Windows.Forms.ListBox LbxPaths;
    }
}

