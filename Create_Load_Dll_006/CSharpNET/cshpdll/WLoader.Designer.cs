﻿
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.CbxFiles = new System.Windows.Forms.ComboBox();
            this.BtnStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnPlay = new System.Windows.Forms.Button();
            this.CbxFpath = new System.Windows.Forms.ComboBox();
            this.BtnLoad = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.FLComponent = new AxShockwaveFlashObjects.AxShockwaveFlash();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FLComponent)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.FLComponent, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.40079F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.599212F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1042, 727);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.73494F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.26506F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 233F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel2.Controls.Add(this.CbxFiles, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnStop, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnPlay, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.CbxFpath, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnLoad, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 696);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1036, 28);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // CbxFiles
            // 
            this.CbxFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CbxFiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxFiles.FormattingEnabled = true;
            this.CbxFiles.Items.AddRange(new object[] {
            "bluebirdie00.swf",
            "Basic_Fire.swf",
            "Basic_Particles.swf",
            "Ellipse.swf",
            "Fibo.swf",
            "Grass.swf",
            "68b.swf",
            "73b.swf",
            "test_05.swf"});
            this.CbxFiles.Location = new System.Drawing.Point(476, 3);
            this.CbxFiles.Name = "CbxFiles";
            this.CbxFiles.Size = new System.Drawing.Size(227, 21);
            this.CbxFiles.TabIndex = 15;
            // 
            // BtnStop
            // 
            this.BtnStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnStop.Location = new System.Drawing.Point(928, 3);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(105, 22);
            this.BtnStop.TabIndex = 4;
            this.BtnStop.Text = "Stop";
            this.BtnStop.UseVisualStyleBackColor = true;
            this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 28);
            this.label1.TabIndex = 10;
            this.label1.Text = "SWF Dir:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnPlay
            // 
            this.BtnPlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnPlay.Location = new System.Drawing.Point(820, 3);
            this.BtnPlay.Name = "BtnPlay";
            this.BtnPlay.Size = new System.Drawing.Size(102, 22);
            this.BtnPlay.TabIndex = 3;
            this.BtnPlay.Text = "Play";
            this.BtnPlay.UseVisualStyleBackColor = true;
            this.BtnPlay.Click += new System.EventHandler(this.BtnPlay_Click);
            // 
            // CbxFpath
            // 
            this.CbxFpath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CbxFpath.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxFpath.FormattingEnabled = true;
            this.CbxFpath.Items.AddRange(new object[] {
            "E:\\Aprog\\Orien\\FlashC#\\PubliBridge\\Create_Load_Dll_005\\CSharpNET\\cshpdll\\resource" +
                "s\\",
            "C:\\Aprog\\Orien\\FlashC#\\PubliBridge\\Create_Load_Dll_005\\CSharpNET\\cshpdll\\resource" +
                "s\\"});
            this.CbxFpath.Location = new System.Drawing.Point(59, 3);
            this.CbxFpath.Name = "CbxFpath";
            this.CbxFpath.Size = new System.Drawing.Size(346, 21);
            this.CbxFpath.TabIndex = 12;
            // 
            // BtnLoad
            // 
            this.BtnLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnLoad.Location = new System.Drawing.Point(709, 3);
            this.BtnLoad.Name = "BtnLoad";
            this.BtnLoad.Size = new System.Drawing.Size(105, 22);
            this.BtnLoad.TabIndex = 1;
            this.BtnLoad.Text = "Load";
            this.BtnLoad.UseVisualStyleBackColor = true;
            this.BtnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(411, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 28);
            this.label2.TabIndex = 13;
            this.label2.Text = "SWF Files:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FLComponent
            // 
            this.FLComponent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FLComponent.Enabled = true;
            this.FLComponent.Location = new System.Drawing.Point(3, 3);
            this.FLComponent.Name = "FLComponent";
            this.FLComponent.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("FLComponent.OcxState")));
            this.FLComponent.Size = new System.Drawing.Size(1036, 687);
            this.FLComponent.TabIndex = 1;
            // 
            // WLoader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 727);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "WLoader";
            this.Text = "WLoader";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FLComponent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ComboBox CbxFiles;
        private System.Windows.Forms.Button BtnStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnPlay;
        private System.Windows.Forms.ComboBox CbxFpath;
        private System.Windows.Forms.Button BtnLoad;
        private System.Windows.Forms.Label label2;
        private AxShockwaveFlashObjects.AxShockwaveFlash FLComponent;
    }
}