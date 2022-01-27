
namespace WalkerPlayer {
    partial class WPlayerForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WPlayerForm));
            this.FLWindow2D = new AxShockwaveFlashObjects.AxShockwaveFlash();
            this.FLWindow3D = new AxShockwaveFlashObjects.AxShockwaveFlash();
            ((System.ComponentModel.ISupportInitialize)(this.FLWindow2D)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FLWindow3D)).BeginInit();
            this.SuspendLayout();
            // 
            // FLWindow2D
            // 
            this.FLWindow2D.Enabled = true;
            this.FLWindow2D.Location = new System.Drawing.Point(147, 59);
            this.FLWindow2D.Name = "FLWindow2D";
            this.FLWindow2D.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("FLWindow2D.OcxState")));
            this.FLWindow2D.Size = new System.Drawing.Size(415, 400);
            this.FLWindow2D.TabIndex = 2;
            this.FLWindow2D.FlashCall += new AxShockwaveFlashObjects._IShockwaveFlashEvents_FlashCallEventHandler(this.OnFlashWalkerCall);
            // 
            // FLWindow3D
            // 
            this.FLWindow3D.Enabled = true;
            this.FLWindow3D.Location = new System.Drawing.Point(622, 59);
            this.FLWindow3D.Name = "FLWindow3D";
            this.FLWindow3D.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("FLWindow3D.OcxState")));
            this.FLWindow3D.Size = new System.Drawing.Size(400, 400);
            this.FLWindow3D.TabIndex = 3;
            this.FLWindow3D.FlashCall += new AxShockwaveFlashObjects._IShockwaveFlashEvents_FlashCallEventHandler(this.OnFlashProjectorCall);
            // 
            // WPlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(1167, 873);
            this.Controls.Add(this.FLWindow3D);
            this.Controls.Add(this.FLWindow2D);
            this.KeyPreview = true;
            this.Name = "WPlayerForm";
            this.Text = "WLoader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.Load += new System.EventHandler(this.OnFormLoad);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnFormKeyDown);
            this.Resize += new System.EventHandler(this.OnFormResize);
            ((System.ComponentModel.ISupportInitialize)(this.FLWindow2D)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FLWindow3D)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public AxShockwaveFlashObjects.AxShockwaveFlash FLWindow2D;
        public AxShockwaveFlashObjects.AxShockwaveFlash FLWindow3D;
    }
}