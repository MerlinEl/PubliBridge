
namespace cshpdll {
    partial class SWFLoader {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SWFLoader));
            this.TbxSwfPath = new System.Windows.Forms.TextBox();
            this.BtnPauseSWF = new System.Windows.Forms.Button();
            this.BtnLoadSWF = new System.Windows.Forms.Button();
            this.BtnPlaySWF = new System.Windows.Forms.Button();
            this.axShockwaveFlash1 = new AxShockwaveFlashObjects.AxShockwaveFlash();
            ((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlash1)).BeginInit();
            this.SuspendLayout();
            // 
            // TbxSwfPath
            // 
            this.TbxSwfPath.Location = new System.Drawing.Point(12, 250);
            this.TbxSwfPath.Name = "TbxSwfPath";
            this.TbxSwfPath.Size = new System.Drawing.Size(538, 20);
            this.TbxSwfPath.TabIndex = 7;
            this.TbxSwfPath.Text = "E:\\Aprog\\Orien\\FlashC#\\PubliBridge\\Create_Load_Dll_003\\CSharpNET\\cshpdll\\resource" +
    "s\\bluebirdie00.swf";
            // 
            // BtnPauseSWF
            // 
            this.BtnPauseSWF.Location = new System.Drawing.Point(157, 212);
            this.BtnPauseSWF.Name = "BtnPauseSWF";
            this.BtnPauseSWF.Size = new System.Drawing.Size(48, 26);
            this.BtnPauseSWF.TabIndex = 4;
            this.BtnPauseSWF.Text = "Pause";
            this.BtnPauseSWF.UseVisualStyleBackColor = true;
            this.BtnPauseSWF.Click += new System.EventHandler(this.BtnPauseSWF_Click);
            // 
            // BtnLoadSWF
            // 
            this.BtnLoadSWF.Location = new System.Drawing.Point(12, 212);
            this.BtnLoadSWF.Name = "BtnLoadSWF";
            this.BtnLoadSWF.Size = new System.Drawing.Size(92, 26);
            this.BtnLoadSWF.TabIndex = 5;
            this.BtnLoadSWF.Text = "Load SWF";
            this.BtnLoadSWF.UseVisualStyleBackColor = true;
            this.BtnLoadSWF.Click += new System.EventHandler(this.BtnLoadSWF_Click);
            // 
            // BtnPlaySWF
            // 
            this.BtnPlaySWF.Location = new System.Drawing.Point(110, 212);
            this.BtnPlaySWF.Name = "BtnPlaySWF";
            this.BtnPlaySWF.Size = new System.Drawing.Size(41, 26);
            this.BtnPlaySWF.TabIndex = 6;
            this.BtnPlaySWF.Text = "Play";
            this.BtnPlaySWF.UseVisualStyleBackColor = true;
            this.BtnPlaySWF.Click += new System.EventHandler(this.BtnPlaySWF_Click);
            // 
            // axShockwaveFlash1
            // 
            this.axShockwaveFlash1.Enabled = true;
            this.axShockwaveFlash1.Location = new System.Drawing.Point(12, 12);
            this.axShockwaveFlash1.Name = "axShockwaveFlash1";
            this.axShockwaveFlash1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axShockwaveFlash1.OcxState")));
            this.axShockwaveFlash1.Size = new System.Drawing.Size(192, 192);
            this.axShockwaveFlash1.TabIndex = 8;
            // 
            // SWFLoader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 279);
            this.Controls.Add(this.axShockwaveFlash1);
            this.Controls.Add(this.TbxSwfPath);
            this.Controls.Add(this.BtnPauseSWF);
            this.Controls.Add(this.BtnLoadSWF);
            this.Controls.Add(this.BtnPlaySWF);
            this.Name = "SWFLoader";
            this.Text = "CSharp SWF Loader:";
            ((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlash1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbxSwfPath;
        private System.Windows.Forms.Button BtnPauseSWF;
        private System.Windows.Forms.Button BtnLoadSWF;
        private System.Windows.Forms.Button BtnPlaySWF;
        private AxShockwaveFlashObjects.AxShockwaveFlash axShockwaveFlash1;
    }
}