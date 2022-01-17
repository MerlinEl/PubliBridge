using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Extentions
{
	public class WatermarkTextBox : System.Windows.Forms.TextBox
	{
		public WatermarkTextBox()
		{
			this.empty = true;
			this._WatermarkText = string.Empty;
			this._WatermarkColor = Color.DarkGray;
			this._ForegroundColor = this.ForeColor;
		}

		/// <summary>本来のテキストが空かどうか</summary>
		private bool empty;
		/// <summary>透かし文字の表示・非表示の設定中に ModifiedChanged プロパティを変更しているかどうか</summary>
		private bool modifiedChanging;

		private void SetBaseText(string text)
		{
			bool m = this.Modified;
			base.Text = text;
			this.modifiedChanging = true;
			this.Modified = m;
			this.modifiedChanging = false;
		}

		protected override void OnModifiedChanged(EventArgs e)
		{
			if (this.modifiedChanging == true)
			{
				return;
			}

			base.OnModifiedChanged(e);
		}

		protected override void OnEnter(EventArgs e)
		{
			if (this.empty == true)
			{
				this.empty = false;
				base.PasswordChar = this._PasswordChar;
				base.ForeColor = this.ForegroundColor;
				this.SetBaseText(string.Empty);
			}

			base.OnEnter(e);
		}

		protected override void OnLeave(EventArgs e)
		{
			base.OnLeave(e);

			if (base.Text == string.Empty && this.WatermarkText != string.Empty)
			{
				this.empty = true;
				base.PasswordChar = '\0';
				base.ForeColor = this.WatermarkColor;
				this.SetBaseText(this.WatermarkText);
			}
			else
			{
				this.empty = false;
			}
		}

		[RefreshProperties(RefreshProperties.Repaint)]
		public override string Text
		{
			get
			{
				if (this.empty == true)
				{
					return string.Empty;
				}

				return base.Text;
			}
			set
			{
				if (value == string.Empty && this.WatermarkText != string.Empty)
				{
					this.empty = true;
					base.PasswordChar = '\0';
					base.ForeColor = this.WatermarkColor;
					base.Text = this.WatermarkText;
				}
				else
				{
					this.empty = false;
					base.PasswordChar = this._PasswordChar;
					if (base.ForeColor != this._ForegroundColor)
					{
						base.ForeColor = this._ForegroundColor;
					}
					base.Text = value;
				}
			}
		}

		public override Color ForeColor
		{
			get { return base.ForeColor; }
			set
			{
				if (this.empty == true)
				{
					this._WatermarkColor = value;
				}
				else
				{
					this._ForegroundColor = value;
				}

				base.ForeColor = value;
			}
		}

		private Color _ForegroundColor;
		[Category("Express")]
		[DefaultValue(typeof(Color), "WindowText")]
		[Description("Gets or sets the foreground color of the control set in the ForeColor property.")]
		public Color ForegroundColor
		{
			get { return this._ForegroundColor; }
			set
			{
				this._ForegroundColor = value;

				if (this.empty == false && base.ForeColor != this._ForegroundColor)
				{
					base.ForeColor = value;
				}
			}
		}

		private Char _PasswordChar;
		public new Char PasswordChar
		{
			get
			{
				if (this.empty == true)
				{
					return '\0';
				}

				return base.PasswordChar;
			}
			set
			{
				this._PasswordChar = value;

				if (this.empty == false)
				{
					base.PasswordChar = value;
				}
			}
		}

		private string _WatermarkText;
		[Category("Express")]
		[DefaultValue("")]
		[Description("Sets or gets the string to display when the text is empty.")]
		[RefreshProperties(RefreshProperties.Repaint)]
		public string WatermarkText
		{
			get { return this._WatermarkText; }
			set
			{
				this._WatermarkText = value;

				// If you are typing, do not set
				if (!this.empty)
				{
					return;
				}

				if (this.Text == string.Empty && value != string.Empty)
				{
					this.empty = true;
					base.PasswordChar = '\0';
					base.ForeColor = this.WatermarkColor;
					this.SetBaseText(value);
				}
				else if (this.Text == string.Empty && value == string.Empty)
				{
					this.Text = string.Empty;
				}
			}
		}

		private Color _WatermarkColor;
		[Category("Express")]
		[DefaultValue(typeof(Color), "DarkGray")]
		[Description("Sets or gets the color of the string to display when the text is empty.")]
		public Color WatermarkColor
		{
			get { return this._WatermarkColor; }
			set
			{
				this._WatermarkColor = value;

				if (this.empty == true)
				{
					base.ForeColor = value;
				}
			}
		}
	}
}