
namespace _32Test {
    partial class Form1 {
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
            this.BtnSayHello = new System.Windows.Forms.Button();
            this.BtnOpenPanel = new System.Windows.Forms.Button();
            this.TbxUserName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtnSayHello
            // 
            this.BtnSayHello.Location = new System.Drawing.Point(12, 12);
            this.BtnSayHello.Name = "BtnSayHello";
            this.BtnSayHello.Size = new System.Drawing.Size(89, 23);
            this.BtnSayHello.TabIndex = 0;
            this.BtnSayHello.Text = "SayHello( str )";
            this.BtnSayHello.UseVisualStyleBackColor = true;
            this.BtnSayHello.Click += new System.EventHandler(this.BtnSayHello_Click);
            // 
            // BtnOpenPanel
            // 
            this.BtnOpenPanel.Location = new System.Drawing.Point(642, 12);
            this.BtnOpenPanel.Name = "BtnOpenPanel";
            this.BtnOpenPanel.Size = new System.Drawing.Size(101, 23);
            this.BtnOpenPanel.TabIndex = 1;
            this.BtnOpenPanel.Text = " Open CSharp Panel";
            this.BtnOpenPanel.UseVisualStyleBackColor = true;
            this.BtnOpenPanel.Click += new System.EventHandler(this.BtnOpenPanel_Click);
            // 
            // TbxUserName
            // 
            this.TbxUserName.Location = new System.Drawing.Point(108, 14);
            this.TbxUserName.Name = "TbxUserName";
            this.TbxUserName.Size = new System.Drawing.Size(85, 20);
            this.TbxUserName.TabIndex = 2;
            this.TbxUserName.Text = "MerlinEl";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 49);
            this.Controls.Add(this.TbxUserName);
            this.Controls.Add(this.BtnOpenPanel);
            this.Controls.Add(this.BtnSayHello);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnSayHello;
        private System.Windows.Forms.Button BtnOpenPanel;
        private System.Windows.Forms.TextBox TbxUserName;
    }
}

