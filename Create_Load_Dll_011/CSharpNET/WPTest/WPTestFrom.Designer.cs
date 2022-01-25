
namespace WPTest {
    partial class WPTestForm {
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
            this.BtnLoadSWF = new System.Windows.Forms.Button();
            this.LbxFiles = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CbxBookDir = new System.Windows.Forms.ComboBox();
            this.CbxSWFDir = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ChkSkipWalkerLogo = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // BtnLoadSWF
            // 
            this.BtnLoadSWF.Location = new System.Drawing.Point(9, 358);
            this.BtnLoadSWF.Name = "BtnLoadSWF";
            this.BtnLoadSWF.Size = new System.Drawing.Size(508, 23);
            this.BtnLoadSWF.TabIndex = 0;
            this.BtnLoadSWF.Text = "LOAD";
            this.BtnLoadSWF.UseVisualStyleBackColor = true;
            this.BtnLoadSWF.Click += new System.EventHandler(this.BtnLoadSWF_Click);
            // 
            // LbxFiles
            // 
            this.LbxFiles.FormattingEnabled = true;
            this.LbxFiles.Location = new System.Drawing.Point(9, 127);
            this.LbxFiles.Name = "LbxFiles";
            this.LbxFiles.Size = new System.Drawing.Size(508, 225);
            this.LbxFiles.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Book Dir:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "SWF Files:";
            // 
            // CbxBookDir
            // 
            this.CbxBookDir.FormattingEnabled = true;
            this.CbxBookDir.Items.AddRange(new object[] {
            "E:\\Aprog\\Orien\\FlashC#\\PubliBridge\\Interactive\\Dějepis 6",
            "E:\\Aprog\\Orien\\FlashC#\\PubliBridge\\Resources\\swf"});
            this.CbxBookDir.Location = new System.Drawing.Point(9, 25);
            this.CbxBookDir.Name = "CbxBookDir";
            this.CbxBookDir.Size = new System.Drawing.Size(508, 21);
            this.CbxBookDir.TabIndex = 7;
            // 
            // CbxSWFDir
            // 
            this.CbxSWFDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxSWFDir.FormattingEnabled = true;
            this.CbxSWFDir.Items.AddRange(new object[] {
            "root",
            "lessons",
            "3d",
            "audio",
            "video",
            "photos"});
            this.CbxSWFDir.Location = new System.Drawing.Point(9, 69);
            this.CbxSWFDir.Name = "CbxSWFDir";
            this.CbxSWFDir.Size = new System.Drawing.Size(508, 21);
            this.CbxSWFDir.TabIndex = 9;
            this.CbxSWFDir.SelectedIndexChanged += new System.EventHandler(this.OnSwfDirChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "SWF Dir:";
            // 
            // ChkSkipWalkerLogo
            // 
            this.ChkSkipWalkerLogo.AutoSize = true;
            this.ChkSkipWalkerLogo.Checked = true;
            this.ChkSkipWalkerLogo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkSkipWalkerLogo.Location = new System.Drawing.Point(12, 397);
            this.ChkSkipWalkerLogo.Name = "ChkSkipWalkerLogo";
            this.ChkSkipWalkerLogo.Size = new System.Drawing.Size(111, 17);
            this.ChkSkipWalkerLogo.TabIndex = 10;
            this.ChkSkipWalkerLogo.Text = "Skip Walker Logo";
            this.ChkSkipWalkerLogo.UseVisualStyleBackColor = true;
            // 
            // WPTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 427);
            this.Controls.Add(this.ChkSkipWalkerLogo);
            this.Controls.Add(this.CbxSWFDir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CbxBookDir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LbxFiles);
            this.Controls.Add(this.BtnLoadSWF);
            this.Name = "WPTestForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.OnFormLoaded);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnLoadSWF;
        private System.Windows.Forms.ListBox LbxFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CbxBookDir;
        private System.Windows.Forms.ComboBox CbxSWFDir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ChkSkipWalkerLogo;
    }
}

