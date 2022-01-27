namespace cshpdll
{
    partial class SWF_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SWF_Form));
            this.axShockwaveFlash1 = new AxShockwaveFlashObjects.AxShockwaveFlash();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Tbx_Swf_Path = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlash1)).BeginInit();
            this.SuspendLayout();
            // 
            // axShockwaveFlash1
            // 
            this.axShockwaveFlash1.Enabled = true;
            this.axShockwaveFlash1.Location = new System.Drawing.Point(0, -2);
            this.axShockwaveFlash1.Name = "axShockwaveFlash1";
            this.axShockwaveFlash1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axShockwaveFlash1.OcxState")));
            this.axShockwaveFlash1.Size = new System.Drawing.Size(192, 192);
            this.axShockwaveFlash1.TabIndex = 0;
            this.axShockwaveFlash1.Enter += new System.EventHandler(this.AxShockwaveFlash1_Enter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(112, 173);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 26);
            this.button1.TabIndex = 1;
            this.button1.Text = "Play";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Btn_Play_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(159, 173);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(48, 26);
            this.button2.TabIndex = 1;
            this.button2.Text = "Pause";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Btn_Pause_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(14, 173);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(92, 26);
            this.button3.TabIndex = 1;
            this.button3.Text = "Load SWF";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Btn_Load_Click);
            // 
            // Tbx_Swf_Path
            // 
            this.Tbx_Swf_Path.Location = new System.Drawing.Point(14, 211);
            this.Tbx_Swf_Path.Name = "Tbx_Swf_Path";
            this.Tbx_Swf_Path.Size = new System.Drawing.Size(591, 20);
            this.Tbx_Swf_Path.TabIndex = 3;
            this.Tbx_Swf_Path.Text = "E:\\Aprog\\Orien\\FlashC#\\WalkerPlayer\\Windows\\WalkerPlayer\\WPlayer\\resources\\bluebi" +
    "rdie00.swf";
            // 
            // SWF_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(621, 243);
            this.Controls.Add(this.Tbx_Swf_Path);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.axShockwaveFlash1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SWF_Form";
            this.Text = "Playing flash files (SWF) in C# form";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlash1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxShockwaveFlashObjects.AxShockwaveFlash axShockwaveFlash1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox Tbx_Swf_Path;
    }
}

