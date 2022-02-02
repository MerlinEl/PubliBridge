
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
            this.LbxFiles = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CbxBookDir = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnLoadAudio = new System.Windows.Forms.Button();
            this.ChkResizable = new System.Windows.Forms.CheckBox();
            this.BtnLoadLesson = new System.Windows.Forms.Button();
            this.TbxUserName = new System.Windows.Forms.TextBox();
            this.CbxMediaDir = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnLoadImages = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LbxFiles
            // 
            this.LbxFiles.FormattingEnabled = true;
            this.LbxFiles.Location = new System.Drawing.Point(9, 166);
            this.LbxFiles.Name = "LbxFiles";
            this.LbxFiles.Size = new System.Drawing.Size(508, 186);
            this.LbxFiles.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "User Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Files:";
            // 
            // CbxBookDir
            // 
            this.CbxBookDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxBookDir.FormattingEnabled = true;
            this.CbxBookDir.Items.AddRange(new object[] {
            "Dropbox\\PubliBridge\\Interactive\\Dějepis 6"});
            this.CbxBookDir.Location = new System.Drawing.Point(8, 71);
            this.CbxBookDir.Name = "CbxBookDir";
            this.CbxBookDir.Size = new System.Drawing.Size(508, 21);
            this.CbxBookDir.TabIndex = 9;
            this.CbxBookDir.SelectedIndexChanged += new System.EventHandler(this.OnBookDirChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "DropBox > BookDir:";
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
            // TbxUserName
            // 
            this.TbxUserName.Enabled = false;
            this.TbxUserName.Location = new System.Drawing.Point(12, 26);
            this.TbxUserName.Name = "TbxUserName";
            this.TbxUserName.Size = new System.Drawing.Size(505, 20);
            this.TbxUserName.TabIndex = 15;
            // 
            // CbxMediaDir
            // 
            this.CbxMediaDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxMediaDir.FormattingEnabled = true;
            this.CbxMediaDir.Items.AddRange(new object[] {
            "lessons",
            "3d",
            "audio",
            "video",
            "photos"});
            this.CbxMediaDir.Location = new System.Drawing.Point(8, 119);
            this.CbxMediaDir.Name = "CbxMediaDir";
            this.CbxMediaDir.Size = new System.Drawing.Size(508, 21);
            this.CbxMediaDir.TabIndex = 17;
            this.CbxMediaDir.SelectedIndexChanged += new System.EventHandler(this.OnMediaDirChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "DropBox > MediaDir:";
            // 
            // BtnLoadImages
            // 
            this.BtnLoadImages.Location = new System.Drawing.Point(215, 358);
            this.BtnLoadImages.Name = "BtnLoadImages";
            this.BtnLoadImages.Size = new System.Drawing.Size(97, 23);
            this.BtnLoadImages.TabIndex = 18;
            this.BtnLoadImages.Text = "LOAD IMAGES";
            this.BtnLoadImages.UseVisualStyleBackColor = true;
            this.BtnLoadImages.Click += new System.EventHandler(this.BtnLoadImages_Click);
            // 
            // WPTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 578);
            this.Controls.Add(this.BtnLoadImages);
            this.Controls.Add(this.CbxMediaDir);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TbxUserName);
            this.Controls.Add(this.BtnLoadLesson);
            this.Controls.Add(this.ChkResizable);
            this.Controls.Add(this.BtnLoadAudio);
            this.Controls.Add(this.CbxBookDir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LbxFiles);
            this.Name = "WPTestForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.OnFormLoaded);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox LbxFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CbxBookDir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnLoadAudio;
        private System.Windows.Forms.CheckBox ChkResizable;
        private System.Windows.Forms.Button BtnLoadLesson;
        private System.Windows.Forms.TextBox TbxUserName;
        private System.Windows.Forms.ComboBox CbxMediaDir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnLoadImages;
    }
}

