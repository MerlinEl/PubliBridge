
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
            this.label1 = new System.Windows.Forms.Label();
            this.CbxDirectories = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // BtnLoadSwfFile
            // 
            this.BtnLoadSwfFile.Location = new System.Drawing.Point(12, 252);
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
            this.LbxPaths.Location = new System.Drawing.Point(12, 47);
            this.LbxPaths.Name = "LbxPaths";
            this.LbxPaths.Size = new System.Drawing.Size(776, 199);
            this.LbxPaths.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Boik Dir:";
            // 
            // CbxDirectories
            // 
            this.CbxDirectories.FormattingEnabled = true;
            this.CbxDirectories.Items.AddRange(new object[] {
            "C:\\Users\\Orien Star\\Dropbox\\PubliBridge\\Interactive\\Dějepis 6\\3d",
            "C:\\Users\\Orien Star\\Dropbox\\PubliBridge\\Interactive\\Dějepis 6\\lessons"});
            this.CbxDirectories.Location = new System.Drawing.Point(66, 14);
            this.CbxDirectories.Name = "CbxDirectories";
            this.CbxDirectories.Size = new System.Drawing.Size(722, 21);
            this.CbxDirectories.TabIndex = 4;
            this.CbxDirectories.SelectedIndexChanged += new System.EventHandler(this.OnDirSelectionChanged);
            this.CbxDirectories.TextChanged += new System.EventHandler(this.OnDirTextChanged);
            // 
            // WPlayerTesterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 319);
            this.Controls.Add(this.CbxDirectories);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LbxPaths);
            this.Controls.Add(this.BtnLoadSwfFile);
            this.Name = "WPlayerTesterForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnLoadSwfFile;
        private System.Windows.Forms.ListBox LbxPaths;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CbxDirectories;
    }
}

