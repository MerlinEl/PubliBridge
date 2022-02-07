using System;
using AxMSACAL;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;

namespace CustoAxImport
{ 
	/// <summary>
	/// MyCalendar class extends AxCalendar class, it supports a daily note 
	/// associated with each day of month. When a day is clicked, a tooltip like 
	/// popup will allow you to type a daily note into it, when the same day
	/// is clicked again, the daily note will be displayed. For demo purpose,
	/// the daily notes are not saved when application terminates, and there are sure 
	/// better ways to implement this feature.
	/// </summary>
	public class MyCalendar : AxCalendar
	{	

		/// <summary>
		/// daily notes
		/// </summary>
		MyDailyNotes m_notes;
		
		/// <summary>
		/// Show or hide daily notes
		/// </summary>
		bool m_isShowNotes = false;

		short m_day, m_year, m_month;
	
		/// <summary>
		/// gets or sets to IsShowNotes
		/// </summary>
		public bool IsShowNotes
		{
			get
			{
				return this.m_isShowNotes;
			}
			set
			{
				this.m_isShowNotes = value;
				if(this.m_isShowNotes)
				{
					// retrive the daily note
					this.m_notes.Text = this.m_notes.GetNotes(GetKey(this.m_month, 
						this.m_day, this.m_year));
					this.m_notes.Show();
				}
			}
		}		

		public MyCalendar()
		{
			Trace.WriteLine("MyCalendar");
			this.m_notes = new MyDailyNotes();
			this.m_notes.BorderStyle = BorderStyle.None;
			this.m_notes.Multiline = true;
			this.m_notes.Height = 48;

			this.m_notes.TextChanged +=new EventHandler(m_notes_TextChanged);
			this.Controls.Add(this.m_notes);
      			
			this.m_notes.Hide();
			
			Debug.WriteLine(string.Format("ctor:(w, h) = ({0}, {1})", this.Width, this.Height));
		}
		
		protected override void CreateSink() 
		{
			try 
			{
				this.eventMulticaster = new MyCalendarEventMulticast(this);//new AxCalendarEventMulticaster(this);
	
				this.cookie = new System.Windows.Forms.AxHost.ConnectionPointCookie(this.ocx, this.eventMulticaster, typeof(MSACAL.DCalendarEvents));
			}
			catch (System.Exception ) 
			{
			}
		}		
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove (e);
			//Trace.WriteLine(string.Format("({0}, {1})", e.X, e.Y));
			MyCalendarEventMulticast mcem = this.eventMulticaster as MyCalendarEventMulticast;

			if(this.m_isShowNotes )
			{
				this.DisplayNote(e.X, e.Y);
			}
		}
		private void DisplayNote(int x, int y)
		{
			Debug.WriteLine(string.Format("w{0},h{1},cw{2},ch{3}", this.Width, this.Height, 
				this.ClientSize.Width, this.ClientSize.Height ));//, e.X, e.Y));
			this.m_notes.Location = new Point(x, y);
			this.m_isShowNotes = false;
				
			this.m_day = this.Day;
			this.m_year = this.Year;
			this.m_month = this.Month;

			string key = GetKey(this.m_month, this.m_day, this.m_year);
			string note = this.m_notes.GetNotes(key);
			if(note.Trim().Length == 0)
				this.m_notes.Text = key + ": " + this.m_notes.GetNotes(key);
			else
				this.m_notes.Text = this.m_notes.GetNotes(key);
		}
		string GetKey(short month, short day, short year)
		{
			return month + "/" + day + "/" + year;
		}
		
		// Note: OnMouseDown and OnMouseUp have alread been hajacked by Click
		protected override void OnMouseUp(MouseEventArgs e)
		{
			Trace.WriteLine("OnMouseUp");
			base.OnMouseUp (e);
		}
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown (e);
			Debug.WriteLine("OnMouseDown");
		}

		private void m_notes_TextChanged(object sender, EventArgs e)
		{
			string key = GetKey(this.m_month, this.m_day, this.m_year);
			this.m_notes.SetNotes(key, this.m_notes.Text);
		}
	}
}
