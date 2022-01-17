
namespace Walker {
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
            this.FLComponent = new AxShockwaveFlashObjects.AxShockwaveFlash();
            ((System.ComponentModel.ISupportInitialize)(this.FLComponent)).BeginInit();
            this.SuspendLayout();
            // 
            // FLComponent
            // 
            this.FLComponent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FLComponent.Enabled = true;
            this.FLComponent.Location = new System.Drawing.Point(0, 0);
            this.FLComponent.Name = "FLComponent";
            this.FLComponent.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("FLComponent.OcxState")));
            this.FLComponent.Size = new System.Drawing.Size(1032, 775);
            this.FLComponent.TabIndex = 0;
            // 
            // WPlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 775);
            this.Controls.Add(this.FLComponent);
            this.Name = "WPlayerForm";
            this.Text = "WPlayerForm";
            ((System.ComponentModel.ISupportInitialize)(this.FLComponent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxShockwaveFlashObjects.AxShockwaveFlash FLComponent;
    }
}