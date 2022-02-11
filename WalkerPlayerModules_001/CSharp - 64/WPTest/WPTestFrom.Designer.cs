
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CbxBookDir = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnLoadAudio = new System.Windows.Forms.Button();
            this.ChkResizable = new System.Windows.Forms.CheckBox();
            this.BtnLoadLesson = new System.Windows.Forms.Button();
            this.TbxUserName = new System.Windows.Forms.TextBox();
            this.CbxLessonList = new System.Windows.Forms.ComboBox();
            this.BtnLoadImages = new System.Windows.Forms.Button();
            this.BtnPlay3D = new System.Windows.Forms.Button();
            this.BtnPlayVideo = new System.Windows.Forms.Button();
            this.Cbx3DList = new System.Windows.Forms.ComboBox();
            this.CbxVideoList = new System.Windows.Forms.ComboBox();
            this.CbxAudioList = new System.Windows.Forms.ComboBox();
            this.CbxImageList = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CkbAutoplay = new System.Windows.Forms.CheckBox();
            this.CbxWindowSize = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TbxConsole = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "User Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 300);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Console:";
            // 
            // CbxBookDir
            // 
            this.CbxBookDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxBookDir.FormattingEnabled = true;
            this.CbxBookDir.Items.AddRange(new object[] {
            "Dropbox\\PubliBridge\\Interactive\\Dějepis 6"});
            this.CbxBookDir.Location = new System.Drawing.Point(110, 40);
            this.CbxBookDir.Name = "CbxBookDir";
            this.CbxBookDir.Size = new System.Drawing.Size(282, 21);
            this.CbxBookDir.TabIndex = 9;
            this.CbxBookDir.SelectedIndexChanged += new System.EventHandler(this.OnBookDirChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "DropBox > BookDir:";
            // 
            // BtnLoadAudio
            // 
            this.BtnLoadAudio.Location = new System.Drawing.Point(7, 106);
            this.BtnLoadAudio.Name = "BtnLoadAudio";
            this.BtnLoadAudio.Size = new System.Drawing.Size(97, 23);
            this.BtnLoadAudio.TabIndex = 12;
            this.BtnLoadAudio.Text = "Play Audio";
            this.BtnLoadAudio.UseVisualStyleBackColor = true;
            this.BtnLoadAudio.Click += new System.EventHandler(this.BtnLoadAudio_Click);
            // 
            // ChkResizable
            // 
            this.ChkResizable.AutoSize = true;
            this.ChkResizable.Location = new System.Drawing.Point(401, 41);
            this.ChkResizable.Name = "ChkResizable";
            this.ChkResizable.Size = new System.Drawing.Size(72, 17);
            this.ChkResizable.TabIndex = 13;
            this.ChkResizable.Text = "Resizable";
            this.ChkResizable.UseVisualStyleBackColor = true;
            // 
            // BtnLoadLesson
            // 
            this.BtnLoadLesson.Location = new System.Drawing.Point(7, 19);
            this.BtnLoadLesson.Name = "BtnLoadLesson";
            this.BtnLoadLesson.Size = new System.Drawing.Size(97, 23);
            this.BtnLoadLesson.TabIndex = 14;
            this.BtnLoadLesson.Text = "Play Lesson";
            this.BtnLoadLesson.UseVisualStyleBackColor = true;
            this.BtnLoadLesson.Click += new System.EventHandler(this.BtnLoadLesson_Click);
            // 
            // TbxUserName
            // 
            this.TbxUserName.Enabled = false;
            this.TbxUserName.Location = new System.Drawing.Point(110, 14);
            this.TbxUserName.Name = "TbxUserName";
            this.TbxUserName.Size = new System.Drawing.Size(282, 20);
            this.TbxUserName.TabIndex = 15;
            // 
            // CbxLessonList
            // 
            this.CbxLessonList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxLessonList.FormattingEnabled = true;
            this.CbxLessonList.Location = new System.Drawing.Point(110, 19);
            this.CbxLessonList.Name = "CbxLessonList";
            this.CbxLessonList.Size = new System.Drawing.Size(487, 21);
            this.CbxLessonList.TabIndex = 17;
            // 
            // BtnLoadImages
            // 
            this.BtnLoadImages.Location = new System.Drawing.Point(7, 135);
            this.BtnLoadImages.Name = "BtnLoadImages";
            this.BtnLoadImages.Size = new System.Drawing.Size(97, 23);
            this.BtnLoadImages.TabIndex = 18;
            this.BtnLoadImages.Text = "Play Images";
            this.BtnLoadImages.UseVisualStyleBackColor = true;
            this.BtnLoadImages.Click += new System.EventHandler(this.BtnLoadImages_Click);
            // 
            // BtnPlay3D
            // 
            this.BtnPlay3D.Location = new System.Drawing.Point(7, 48);
            this.BtnPlay3D.Name = "BtnPlay3D";
            this.BtnPlay3D.Size = new System.Drawing.Size(97, 23);
            this.BtnPlay3D.TabIndex = 19;
            this.BtnPlay3D.Text = "Play3D";
            this.BtnPlay3D.UseVisualStyleBackColor = true;
            this.BtnPlay3D.Click += new System.EventHandler(this.BtnPlay3D_Click);
            // 
            // BtnPlayVideo
            // 
            this.BtnPlayVideo.Location = new System.Drawing.Point(7, 77);
            this.BtnPlayVideo.Name = "BtnPlayVideo";
            this.BtnPlayVideo.Size = new System.Drawing.Size(97, 23);
            this.BtnPlayVideo.TabIndex = 20;
            this.BtnPlayVideo.Text = "Play Video";
            this.BtnPlayVideo.UseVisualStyleBackColor = true;
            this.BtnPlayVideo.Click += new System.EventHandler(this.BtnPlayVideo_Click);
            // 
            // Cbx3DList
            // 
            this.Cbx3DList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbx3DList.FormattingEnabled = true;
            this.Cbx3DList.Location = new System.Drawing.Point(110, 50);
            this.Cbx3DList.Name = "Cbx3DList";
            this.Cbx3DList.Size = new System.Drawing.Size(487, 21);
            this.Cbx3DList.TabIndex = 21;
            // 
            // CbxVideoList
            // 
            this.CbxVideoList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxVideoList.FormattingEnabled = true;
            this.CbxVideoList.Location = new System.Drawing.Point(110, 79);
            this.CbxVideoList.Name = "CbxVideoList";
            this.CbxVideoList.Size = new System.Drawing.Size(487, 21);
            this.CbxVideoList.TabIndex = 22;
            // 
            // CbxAudioList
            // 
            this.CbxAudioList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxAudioList.FormattingEnabled = true;
            this.CbxAudioList.Location = new System.Drawing.Point(110, 106);
            this.CbxAudioList.Name = "CbxAudioList";
            this.CbxAudioList.Size = new System.Drawing.Size(487, 21);
            this.CbxAudioList.TabIndex = 23;
            // 
            // CbxImageList
            // 
            this.CbxImageList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxImageList.FormattingEnabled = true;
            this.CbxImageList.Location = new System.Drawing.Point(110, 137);
            this.CbxImageList.Name = "CbxImageList";
            this.CbxImageList.Size = new System.Drawing.Size(487, 21);
            this.CbxImageList.TabIndex = 24;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CkbAutoplay);
            this.groupBox1.Controls.Add(this.CbxWindowSize);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TbxUserName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ChkResizable);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.CbxBookDir);
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(603, 111);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options:";
            // 
            // CkbAutoplay
            // 
            this.CkbAutoplay.AutoSize = true;
            this.CkbAutoplay.Location = new System.Drawing.Point(401, 64);
            this.CkbAutoplay.Name = "CkbAutoplay";
            this.CkbAutoplay.Size = new System.Drawing.Size(68, 17);
            this.CkbAutoplay.TabIndex = 18;
            this.CkbAutoplay.Text = "Auo Play";
            this.CkbAutoplay.UseVisualStyleBackColor = true;
            // 
            // CbxWindowSize
            // 
            this.CbxWindowSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxWindowSize.FormattingEnabled = true;
            this.CbxWindowSize.Items.AddRange(new object[] {
            "PLAYERSIZE",
            "FULLSCREEN",
            "1024,768",
            "800,600"});
            this.CbxWindowSize.Location = new System.Drawing.Point(467, 14);
            this.CbxWindowSize.Name = "CbxWindowSize";
            this.CbxWindowSize.Size = new System.Drawing.Size(127, 21);
            this.CbxWindowSize.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(398, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Window Size:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnLoadLesson);
            this.groupBox2.Controls.Add(this.BtnLoadAudio);
            this.groupBox2.Controls.Add(this.CbxImageList);
            this.groupBox2.Controls.Add(this.CbxLessonList);
            this.groupBox2.Controls.Add(this.CbxAudioList);
            this.groupBox2.Controls.Add(this.BtnLoadImages);
            this.groupBox2.Controls.Add(this.CbxVideoList);
            this.groupBox2.Controls.Add(this.BtnPlay3D);
            this.groupBox2.Controls.Add(this.Cbx3DList);
            this.groupBox2.Controls.Add(this.BtnPlayVideo);
            this.groupBox2.Location = new System.Drawing.Point(6, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(603, 174);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Methods:";
            // 
            // TbxConsole
            // 
            this.TbxConsole.Location = new System.Drawing.Point(6, 316);
            this.TbxConsole.Name = "TbxConsole";
            this.TbxConsole.Size = new System.Drawing.Size(597, 272);
            this.TbxConsole.TabIndex = 27;
            this.TbxConsole.Text = "";
            // 
            // WPTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 595);
            this.Controls.Add(this.TbxConsole);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Name = "WPTestForm";
            this.Text = "WalkerPlayer.dll > CSharp Methods Call:";
            this.Load += new System.EventHandler(this.OnFormLoaded);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CbxBookDir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnLoadAudio;
        private System.Windows.Forms.CheckBox ChkResizable;
        private System.Windows.Forms.Button BtnLoadLesson;
        private System.Windows.Forms.TextBox TbxUserName;
        private System.Windows.Forms.ComboBox CbxLessonList;
        private System.Windows.Forms.Button BtnLoadImages;
        private System.Windows.Forms.Button BtnPlay3D;
        private System.Windows.Forms.Button BtnPlayVideo;
        private System.Windows.Forms.ComboBox Cbx3DList;
        private System.Windows.Forms.ComboBox CbxVideoList;
        private System.Windows.Forms.ComboBox CbxAudioList;
        private System.Windows.Forms.ComboBox CbxImageList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox CkbAutoplay;
        private System.Windows.Forms.ComboBox CbxWindowSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox TbxConsole;
    }
}

