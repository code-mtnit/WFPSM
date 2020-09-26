using System;
using System.Windows.Forms;

namespace SearchableControls
{
	public class Utility
	{
		public static ISearchable FindSearchable(Control.ControlCollection controlCollection)
		{
			ISearchable searchable = null;
			ISearchable result;
			foreach (Control control in controlCollection)
			{
				ISearchable searchable2 = control as ISearchable;
				if (searchable2 != null)
				{
					if (control.Focused)
					{
						result = searchable2;
						return result;
					}
					if (searchable == null || control.TabIndex < ((Control)searchable).TabIndex)
					{
						searchable = searchable2;
					}
				}
			}
			result = searchable;
			return result;
		}

		public static bool OpenFindDialog(Control.ControlCollection controls)
		{
			ISearchable searchable = Utility.FindSearchable(controls);
			bool result;
			if (searchable != null)
			{
				searchable.FindDialog.Show();
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		public static bool FindNext(Control.ControlCollection controls)
		{
			ISearchable searchable = Utility.FindSearchable(controls);
			bool result;
			if (searchable != null)
			{
				searchable.FindDialog.FindNext();
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		public static bool FindNextIsAvailable(Control.ControlCollection controls)
		{
			ISearchable searchable = Utility.FindSearchable(controls);
			return searchable != null && searchable.FindDialog.FindNextIsAvailable();
		}
	}
}
