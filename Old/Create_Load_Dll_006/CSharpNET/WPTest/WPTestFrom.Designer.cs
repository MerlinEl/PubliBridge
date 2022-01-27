
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
            this.CbxFpath = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // BtnLoadSWF
            // 
            this.BtnLoadSWF.Location = new System.Drawing.Point(9, 306);
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
            this.LbxFiles.Items.AddRange(new object[] {
            "bluebirdie00.swf",
            "Basic_Fire.swf",
            "Basic_Particles.swf",
            "Ellipse.swf",
            "Fibo.swf",
            "Grass.swf",
            "68b.swf",
            "73b.swf",
            "test_05.swf"});
            this.LbxFiles.Location = new System.Drawing.Point(9, 75);
            this.LbxFiles.Name = "LbxFiles";
            this.LbxFiles.Size = new System.Drawing.Size(508, 225);
            this.LbxFiles.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "SWF Dir:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "SWF Files:";
            // 
            // CbxFpath
            // 
            this.CbxFpath.FormattingEnabled = true;
            this.CbxFpath.Items.AddRange(new object[] {
            "E:\\Aprog\\Orien\\FlashC#\\PubliBridge\\Create_Load_Dll_005\\CSharpNET\\cshpdll\\resource" +
                "s\\",
            "C:\\Aprog\\Orien\\FlashC#\\PubliBridge\\Create_Load_Dll_005\\CSharpNET\\cshpdll\\resource" +
                "s\\"});
            this.CbxFpath.Location = new System.Drawing.Point(9, 25);
            this.CbxFpath.Name = "CbxFpath";
            this.CbxFpath.Size = new System.Drawing.Size(508, 21);
            this.CbxFpath.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 338);
            this.Controls.Add(this.CbxFpath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LbxFiles);
            this.Controls.Add(this.BtnLoadSWF);
            this.Name = "Form1";
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
        private System.Windows.Forms.ComboBox CbxFpath;
    }
}

