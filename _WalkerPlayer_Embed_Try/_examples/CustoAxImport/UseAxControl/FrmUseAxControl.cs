using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace CustoAxImport
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private CustoAxImport.MyCalendar myCalendar1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.myCalendar1 = new CustoAxImport.MyCalendar();
			((System.ComponentModel.ISupportInitialize)(this.myCalendar1)).BeginInit();
			this.SuspendLayout();
			// 
			// myCalendar1
			// 
			this.myCalendar1.Enabled = true;
			this.myCalendar1.IsShowNotes = false;
			this.myCalendar1.Location = new System.Drawing.Point(16, 8);
			this.myCalendar1.Name = "myCalendar1";
			this.myCalendar1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("myCalendar1.OcxState")));
			this.myCalendar1.Size = new System.Drawing.Size(416, 368);
			this.myCalendar1.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(456, 397);
			this.Controls.Add(this.myCalendar1);
			this.Name = "Form1";
			this.Text = "Test Imported AxControl";
			((System.ComponentModel.ISupportInitialize)(this.myCalendar1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
	}
}
