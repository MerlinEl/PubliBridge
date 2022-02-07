using System;
using System.Diagnostics;
namespace CustoAxImport
{
		/// <summary>
		/// MyCalendarEventMulticast extends AcCalendarEventMulticaster, the purpose of
		/// this subclassing is to override Click() method to show a daily note when a
		/// day is selected by user
		/// </summary>
		public class MyCalendarEventMulticast : AxCalendarEventMulticaster
		{
			public MyCalendarEventMulticast(MyCalendar mycalendar) : base(mycalendar)
			{	
		
			}
		
			
			// we overide the Click() method to show a daily notes when a day is selected
			public override void Click() 
			{
				base.Click();

				Trace.WriteLine("Click");			
				MyCalendar mc = this.parent	as MyCalendar;

				if(!mc.IsShowNotes)
				{
					mc.IsShowNotes = true;
				}
				else
					mc.IsShowNotes = false;
			}
		}
}

