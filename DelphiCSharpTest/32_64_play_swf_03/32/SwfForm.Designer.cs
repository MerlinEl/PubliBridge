
namespace WalkerPlayer {
    partial class SwfForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SwfForm));
            this.axShockwaveFlash1 = new AxShockwaveFlashObjects.AxShockwaveFlash();
            this.BtnLoadSwf = new System.Windows.Forms.Button();
            this.TbxSwfPath = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlash1)).BeginInit();
            this.SuspendLayout();
            // 
            // axShockwaveFlash1
            // 
            this.axShockwaveFlash1.Enabled = true;
            this.axShockwaveFlash1.Location = new System.Drawing.Point(12, 12);
            this.axShockwaveFlash1.Name = "axShockwaveFlash1";
            this.axShockwaveFlash1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axShockwaveFlash1.OcxState")));
            this.axShockwaveFlash1.Size = new System.Drawing.Size(776, 236);
            this.axShockwaveFlash1.TabIndex = 0;
            // 
            // BtnLoadSwf
            // 
            this.BtnLoadSwf.Location = new System.Drawing.Point(12, 252);
            this.BtnLoadSwf.Name = "BtnLoadSwf";
            this.BtnLoadSwf.Size = new System.Drawing.Size(75, 23);
            this.BtnLoadSwf.TabIndex = 1;
            this.BtnLoadSwf.Text = "Load Swf";
            this.BtnLoadSwf.UseVisualStyleBackColor = true;
            this.BtnLoadSwf.Click += new System.EventHandler(this.BtnLoadSwf_Click);
            // 
            // TbxSwfPath
            // 
            this.TbxSwfPath.Location = new System.Drawing.Point(93, 254);
            this.TbxSwfPath.Name = "TbxSwfPath";
            this.TbxSwfPath.Size = new System.Drawing.Size(695, 20);
            this.TbxSwfPath.TabIndex = 2;
            this.TbxSwfPath.Text = "Dice3D.swf";
            // 
            // SwfForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 283);
            this.Controls.Add(this.TbxSwfPath);
            this.Controls.Add(this.BtnLoadSwf);
            this.Controls.Add(this.axShockwaveFlash1);
            this.Name = "SwfForm";
            this.Text = "SwfForm";
            ((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlash1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxShockwaveFlashObjects.AxShockwaveFlash axShockwaveFlash1;
        private System.Windows.Forms.Button BtnLoadSwf;
        private System.Windows.Forms.TextBox TbxSwfPath;
    }
}