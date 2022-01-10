
namespace cshpdll {
    partial class ImageGalleryForm {
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
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnDel = new System.Windows.Forms.Button();
            this.CbxImageList = new System.Windows.Forms.ComboBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.PicBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(12, 12);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(75, 23);
            this.BtnAdd.TabIndex = 0;
            this.BtnAdd.Text = "Add";
            this.BtnAdd.UseVisualStyleBackColor = true;
            // 
            // BtnDel
            // 
            this.BtnDel.Location = new System.Drawing.Point(360, 12);
            this.BtnDel.Name = "BtnDel";
            this.BtnDel.Size = new System.Drawing.Size(75, 23);
            this.BtnDel.TabIndex = 1;
            this.BtnDel.Text = "Del";
            this.BtnDel.UseVisualStyleBackColor = true;
            // 
            // CbxImageList
            // 
            this.CbxImageList.AccessibleRole = System.Windows.Forms.AccessibleRole.List;
            this.CbxImageList.FormattingEnabled = true;
            this.CbxImageList.Items.AddRange(new object[] {
            "icons_01",
            "icons_02",
            "icons_03"});
            this.CbxImageList.Location = new System.Drawing.Point(12, 41);
            this.CbxImageList.Name = "CbxImageList";
            this.CbxImageList.Size = new System.Drawing.Size(423, 21);
            this.CbxImageList.TabIndex = 2;
            this.CbxImageList.SelectedIndexChanged += new System.EventHandler(this.CbxImageList_SelectedIndexChanged);
            // 
            // PicBox
            // 
            this.PicBox.Location = new System.Drawing.Point(12, 68);
            this.PicBox.Name = "PicBox";
            this.PicBox.Size = new System.Drawing.Size(423, 199);
            this.PicBox.TabIndex = 3;
            this.PicBox.TabStop = false;
            // 
            // ImageGalleryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 277);
            this.Controls.Add(this.PicBox);
            this.Controls.Add(this.CbxImageList);
            this.Controls.Add(this.BtnDel);
            this.Controls.Add(this.BtnAdd);
            this.Name = "ImageGalleryForm";
            this.Text = "CSharp Image Gallery:";
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnDel;
        private System.Windows.Forms.ComboBox CbxImageList;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.PictureBox PicBox;
    }
}