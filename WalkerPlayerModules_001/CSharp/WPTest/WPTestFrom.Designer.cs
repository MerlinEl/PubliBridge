
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
            this.BtnLoadSwf2D = new System.Windows.Forms.Button();
            this.LbxFiles = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CbxBookDir = new System.Windows.Forms.ComboBox();
            this.CbxSWFDir = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnLoadSwf3D = new System.Windows.Forms.Button();
            this.BtnLoadAudio = new System.Windows.Forms.Button();
            this.ChkResizable = new System.Windows.Forms.CheckBox();
            this.BtnLoadLesson = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnLoadSwf2D
            // 
            this.BtnLoadSwf2D.Location = new System.Drawing.Point(9, 495);
            this.BtnLoadSwf2D.Name = "BtnLoadSwf2D";
            this.BtnLoadSwf2D.Size = new System.Drawing.Size(97, 23);
            this.BtnLoadSwf2D.TabIndex = 0;
            this.BtnLoadSwf2D.Text = "LOAD 2D";
            this.BtnLoadSwf2D.UseVisualStyleBackColor = true;
            this.BtnLoadSwf2D.Click += new System.EventHandler(this.BtnLoadSWF_Click);
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
            "C:\\Users\\Orien Star\\Dropbox\\PubliBridge\\Interactive\\Dějepis 6",
            "E:\\Aprog\\Orien\\FlashC#\\PubliBridge\\Resources\\swf",
            "C:\\Users\\merli\\Dropbox\\PubliBridge\\Interactive\\Dějepis 6"});
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
            // BtnLoadSwf3D
            // 
            this.BtnLoadSwf3D.Location = new System.Drawing.Point(125, 507);
            this.BtnLoadSwf3D.Name = "BtnLoadSwf3D";
            this.BtnLoadSwf3D.Size = new System.Drawing.Size(97, 23);
            this.BtnLoadSwf3D.TabIndex = 11;
            this.BtnLoadSwf3D.Text = "LOAD 3D";
            this.BtnLoadSwf3D.UseVisualStyleBackColor = true;
            this.BtnLoadSwf3D.Click += new System.EventHandler(this.BtnLoadSwf3D_Click);
            // 
            // BtnLoadAudio
            // 
            this.BtnLoadAudio.Location = new System.Drawing.Point(9, 358);
            this.BtnLoadAudio.Name = "BtnLoadAudio";
            this.BtnLoadAudio.Size = new System.Drawing.Size(97, 23);
            this.BtnLoadAudio.TabIndex = 12;
            this.BtnLoadAudio.Text = "LOAD AUDIO";
            this.BtnLoadAudio.UseVisualStyleBackColor = true;
            this.BtnLoadAudio.Click += new System.EventHandler(this.BtnLoadAudio_Click);
            // 
            // ChkResizable
            // 
            this.ChkResizable.AutoSize = true;
            this.ChkResizable.Location = new System.Drawing.Point(12, 427);
            this.ChkResizable.Name = "ChkResizable";
            this.ChkResizable.Size = new System.Drawing.Size(72, 17);
            this.ChkResizable.TabIndex = 13;
            this.ChkResizable.Text = "Resizable";
            this.ChkResizable.UseVisualStyleBackColor = true;
            // 
            // BtnLoadLesson
            // 
            this.BtnLoadLesson.Location = new System.Drawing.Point(112, 358);
            this.BtnLoadLesson.Name = "BtnLoadLesson";
            this.BtnLoadLesson.Size = new System.Drawing.Size(97, 23);
            this.BtnLoadLesson.TabIndex = 14;
            this.BtnLoadLesson.Text = "LOAD LESSON";
            this.BtnLoadLesson.UseVisualStyleBackColor = true;
            this.BtnLoadLesson.Click += new System.EventHandler(this.BtnLoadLesson_Click);
            // 
            // WPTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 578);
            this.Controls.Add(this.BtnLoadLesson);
            this.Controls.Add(this.ChkResizable);
            this.Controls.Add(this.BtnLoadAudio);
            this.Controls.Add(this.BtnLoadSwf3D);
            this.Controls.Add(this.CbxSWFDir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CbxBookDir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LbxFiles);
            this.Controls.Add(this.BtnLoadSwf2D);
            this.Name = "WPTestForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.OnFormLoaded);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnLoadSwf2D;
        private System.Windows.Forms.ListBox LbxFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CbxBookDir;
        private System.Windows.Forms.ComboBox CbxSWFDir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnLoadSwf3D;
        private System.Windows.Forms.Button BtnLoadAudio;
        private System.Windows.Forms.CheckBox ChkResizable;
        private System.Windows.Forms.Button BtnLoadLesson;
    }
}

