
namespace cshpdll
{
    partial class WLoader
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WLoader));
            this.BtnLoad = new System.Windows.Forms.Button();
            this.TbxFpath = new System.Windows.Forms.TextBox();
            this.BtnPlay = new System.Windows.Forms.Button();
            this.BtnStop = new System.Windows.Forms.Button();
            this.FLComponent = new AxShockwaveFlashObjects.AxShockwaveFlash();
            ((System.ComponentModel.ISupportInitialize)(this.FLComponent)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnLoad
            // 
            this.BtnLoad.Location = new System.Drawing.Point(13, 317);
            this.BtnLoad.Name = "BtnLoad";
            this.BtnLoad.Size = new System.Drawing.Size(103, 23);
            this.BtnLoad.TabIndex = 1;
            this.BtnLoad.Text = "Load";
            this.BtnLoad.UseVisualStyleBackColor = true;
            this.BtnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // TbxFpath
            // 
            this.TbxFpath.Location = new System.Drawing.Point(12, 291);
            this.TbxFpath.Name = "TbxFpath";
            this.TbxFpath.Size = new System.Drawing.Size(776, 20);
            this.TbxFpath.TabIndex = 2;
            this.TbxFpath.Text = "E:\\Aprog\\Orien\\FlashC#\\PubliBridge\\Create_Load_Dll_005\\CSharpNET\\cshpdll\\resource" +
    "s\\bluebirdie00.swf";
            // 
            // BtnPlay
            // 
            this.BtnPlay.Location = new System.Drawing.Point(122, 317);
            this.BtnPlay.Name = "BtnPlay";
            this.BtnPlay.Size = new System.Drawing.Size(103, 23);
            this.BtnPlay.TabIndex = 3;
            this.BtnPlay.Text = "Play";
            this.BtnPlay.UseVisualStyleBackColor = true;
            this.BtnPlay.Click += new System.EventHandler(this.BtnPlay_Click);
            // 
            // BtnStop
            // 
            this.BtnStop.Location = new System.Drawing.Point(231, 317);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(103, 23);
            this.BtnStop.TabIndex = 4;
            this.BtnStop.Text = "Stop";
            this.BtnStop.UseVisualStyleBackColor = true;
            this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // FLComponent
            // 
            this.FLComponent.Enabled = true;
            this.FLComponent.Location = new System.Drawing.Point(13, 12);
            this.FLComponent.Name = "FLComponent";
            this.FLComponent.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("FLComponent.OcxState")));
            this.FLComponent.Size = new System.Drawing.Size(279, 273);
            this.FLComponent.TabIndex = 0;
            // 
            // WLoader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 350);
            this.Controls.Add(this.BtnStop);
            this.Controls.Add(this.BtnPlay);
            this.Controls.Add(this.TbxFpath);
            this.Controls.Add(this.BtnLoad);
            this.Controls.Add(this.FLComponent);
            this.Name = "WLoader";
            this.Text = "WLoader";
            ((System.ComponentModel.ISupportInitialize)(this.FLComponent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxShockwaveFlashObjects.AxShockwaveFlash FLComponent;
        private System.Windows.Forms.Button BtnLoad;
        private System.Windows.Forms.TextBox TbxFpath;
        private System.Windows.Forms.Button BtnPlay;
        private System.Windows.Forms.Button BtnStop;
    }
}