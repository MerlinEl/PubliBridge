﻿namespace PeerstViewer.ThreadViewer
{
	partial class ViewerSettingView
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewerSettingView));
			this.initGroupBox = new System.Windows.Forms.GroupBox();
			this.returnSizeOnStartCheckBox = new System.Windows.Forms.CheckBox();
			this.returnPositionOnStartCheckBox = new System.Windows.Forms.CheckBox();
			this.closeGroupBox = new System.Windows.Forms.GroupBox();
			this.saveReturnSizeCheckBox = new System.Windows.Forms.CheckBox();
			this.saveReturnPositionCheckBox = new System.Windows.Forms.CheckBox();
			this.settingTabControl = new System.Windows.Forms.TabControl();
			this.settingTabPage = new System.Windows.Forms.TabPage();
			this.threadViewerGroupBox = new System.Windows.Forms.GroupBox();
			this.openLinkBrowserCheckBox = new System.Windows.Forms.CheckBox();
			this.saveButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.initGroupBox.SuspendLayout();
			this.closeGroupBox.SuspendLayout();
			this.settingTabControl.SuspendLayout();
			this.settingTabPage.SuspendLayout();
			this.threadViewerGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// initGroupBox
			// 
			this.initGroupBox.Controls.Add(this.returnSizeOnStartCheckBox);
			this.initGroupBox.Controls.Add(this.returnPositionOnStartCheckBox);
			this.initGroupBox.Location = new System.Drawing.Point(232, 6);
			this.initGroupBox.Name = "initGroupBox";
			this.initGroupBox.Size = new System.Drawing.Size(210, 70);
			this.initGroupBox.TabIndex = 0;
			this.initGroupBox.TabStop = false;
			this.initGroupBox.Text = "初期表示";
			// 
			// returnSizeOnStartCheckBox
			// 
			this.returnSizeOnStartCheckBox.AutoSize = true;
			this.returnSizeOnStartCheckBox.Location = new System.Drawing.Point(18, 40);
			this.returnSizeOnStartCheckBox.Name = "returnSizeOnStartCheckBox";
			this.returnSizeOnStartCheckBox.Size = new System.Drawing.Size(148, 16);
			this.returnSizeOnStartCheckBox.TabIndex = 2;
			this.returnSizeOnStartCheckBox.Text = "ウィンドウサイズを復帰する";
			this.returnSizeOnStartCheckBox.UseVisualStyleBackColor = true;
			// 
			// returnPositionOnStartCheckBox
			// 
			this.returnPositionOnStartCheckBox.AutoSize = true;
			this.returnPositionOnStartCheckBox.Location = new System.Drawing.Point(18, 18);
			this.returnPositionOnStartCheckBox.Name = "returnPositionOnStartCheckBox";
			this.returnPositionOnStartCheckBox.Size = new System.Drawing.Size(143, 16);
			this.returnPositionOnStartCheckBox.TabIndex = 3;
			this.returnPositionOnStartCheckBox.Text = "ウィンドウ位置を復帰する";
			this.returnPositionOnStartCheckBox.UseVisualStyleBackColor = true;
			// 
			// closeGroupBox
			// 
			this.closeGroupBox.Controls.Add(this.saveReturnSizeCheckBox);
			this.closeGroupBox.Controls.Add(this.saveReturnPositionCheckBox);
			this.closeGroupBox.Location = new System.Drawing.Point(232, 82);
			this.closeGroupBox.Name = "closeGroupBox";
			this.closeGroupBox.Size = new System.Drawing.Size(210, 70);
			this.closeGroupBox.TabIndex = 1;
			this.closeGroupBox.TabStop = false;
			this.closeGroupBox.Text = "終了時";
			// 
			// saveReturnSizeCheckBox
			// 
			this.saveReturnSizeCheckBox.AutoSize = true;
			this.saveReturnSizeCheckBox.Location = new System.Drawing.Point(18, 40);
			this.saveReturnSizeCheckBox.Name = "saveReturnSizeCheckBox";
			this.saveReturnSizeCheckBox.Size = new System.Drawing.Size(148, 16);
			this.saveReturnSizeCheckBox.TabIndex = 2;
			this.saveReturnSizeCheckBox.Text = "ウィンドウサイズを保存する";
			this.saveReturnSizeCheckBox.UseVisualStyleBackColor = true;
			// 
			// saveReturnPositionCheckBox
			// 
			this.saveReturnPositionCheckBox.AutoSize = true;
			this.saveReturnPositionCheckBox.Location = new System.Drawing.Point(18, 18);
			this.saveReturnPositionCheckBox.Name = "saveReturnPositionCheckBox";
			this.saveReturnPositionCheckBox.Size = new System.Drawing.Size(143, 16);
			this.saveReturnPositionCheckBox.TabIndex = 3;
			this.saveReturnPositionCheckBox.Text = "ウィンドウ位置を保存する";
			this.saveReturnPositionCheckBox.UseVisualStyleBackColor = true;
			// 
			// settingTabControl
			// 
			this.settingTabControl.Controls.Add(this.settingTabPage);
			this.settingTabControl.Dock = System.Windows.Forms.DockStyle.Top;
			this.settingTabControl.Location = new System.Drawing.Point(0, 0);
			this.settingTabControl.Name = "settingTabControl";
			this.settingTabControl.SelectedIndex = 0;
			this.settingTabControl.Size = new System.Drawing.Size(461, 362);
			this.settingTabControl.TabIndex = 2;
			// 
			// settingTabPage
			// 
			this.settingTabPage.Controls.Add(this.threadViewerGroupBox);
			this.settingTabPage.Controls.Add(this.closeGroupBox);
			this.settingTabPage.Controls.Add(this.initGroupBox);
			this.settingTabPage.Location = new System.Drawing.Point(4, 22);
			this.settingTabPage.Name = "settingTabPage";
			this.settingTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.settingTabPage.Size = new System.Drawing.Size(453, 336);
			this.settingTabPage.TabIndex = 0;
			this.settingTabPage.Text = "各種設定";
			this.settingTabPage.UseVisualStyleBackColor = true;
			// 
			// threadViewerGroupBox
			// 
			this.threadViewerGroupBox.Controls.Add(this.openLinkBrowserCheckBox);
			this.threadViewerGroupBox.Location = new System.Drawing.Point(8, 6);
			this.threadViewerGroupBox.Name = "threadViewerGroupBox";
			this.threadViewerGroupBox.Size = new System.Drawing.Size(210, 70);
			this.threadViewerGroupBox.TabIndex = 2;
			this.threadViewerGroupBox.TabStop = false;
			this.threadViewerGroupBox.Text = "スレッドビューア";
			// 
			// openLinkBrowserCheckBox
			// 
			this.openLinkBrowserCheckBox.AutoSize = true;
			this.openLinkBrowserCheckBox.Location = new System.Drawing.Point(18, 18);
			this.openLinkBrowserCheckBox.Name = "openLinkBrowserCheckBox";
			this.openLinkBrowserCheckBox.Size = new System.Drawing.Size(121, 16);
			this.openLinkBrowserCheckBox.TabIndex = 1;
			this.openLinkBrowserCheckBox.Text = "リンクをブラウザで開く";
			this.openLinkBrowserCheckBox.UseVisualStyleBackColor = true;
			// 
			// saveButton
			// 
			this.saveButton.Location = new System.Drawing.Point(290, 368);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(75, 23);
			this.saveButton.TabIndex = 3;
			this.saveButton.Text = "保存";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(371, 368);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 4;
			this.cancelButton.Text = "キャンセル";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// toolTip
			// 
			this.toolTip.ShowAlways = true;
			// 
			// ViewerSettingView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(461, 397);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.settingTabControl);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ViewerSettingView";
			this.Text = "設定";
			this.initGroupBox.ResumeLayout(false);
			this.initGroupBox.PerformLayout();
			this.closeGroupBox.ResumeLayout(false);
			this.closeGroupBox.PerformLayout();
			this.settingTabControl.ResumeLayout(false);
			this.settingTabPage.ResumeLayout(false);
			this.threadViewerGroupBox.ResumeLayout(false);
			this.threadViewerGroupBox.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox initGroupBox;
		private System.Windows.Forms.GroupBox closeGroupBox;
		private System.Windows.Forms.TabControl settingTabControl;
		private System.Windows.Forms.TabPage settingTabPage;
		private System.Windows.Forms.CheckBox returnSizeOnStartCheckBox;
		private System.Windows.Forms.CheckBox returnPositionOnStartCheckBox;
		private System.Windows.Forms.CheckBox saveReturnSizeCheckBox;
		private System.Windows.Forms.CheckBox saveReturnPositionCheckBox;
		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.GroupBox threadViewerGroupBox;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.CheckBox openLinkBrowserCheckBox;
	}
}