using System;
using System.Windows;
using System.Windows.Forms;
using System.Collections;
using System.Text;

namespace CustoAxImport
{
	/// <summary>
	/// MyDailyNotes represents notes that will be displayed when a day cell is clicked.
	/// The text notes are stored in a hash table. The key is mm/day/year created by caller.
	/// </summary>
	public class MyDailyNotes : TextBox
	{
		static Hashtable m_noteCollection = new Hashtable();
		
		public MyDailyNotes()
		{
		}
		public void SetNotes(object key, string notes)
		{
			if(m_noteCollection.Contains(key))
				m_noteCollection[key] = notes;
			else
				m_noteCollection.Add(key, notes);
		}
		public string GetNotes(object key)
		{
			if(m_noteCollection.Contains(key))
				return (string)m_noteCollection[key];
			return "";
		}
	}
}
