using System;
using System.Text.RegularExpressions;

namespace SearchableControls
{
	public class SearchEventArgs : EventArgs
	{
		private bool successful = false;

		private bool restartedFromDocumentTop = false;

		private bool firstSearch;

		private Regex searchRegularExpression;

		public bool Successful
		{
			get
			{
				return this.successful;
			}
			set
			{
				this.successful = value;
			}
		}

		public bool RestartedFromDocumentTop
		{
			get
			{
				return this.restartedFromDocumentTop;
			}
			set
			{
				this.restartedFromDocumentTop = value;
			}
		}

		public bool FirstSearch
		{
			get
			{
				return this.firstSearch;
			}
		}

		public Regex SearchRegularExpression
		{
			get
			{
				return this.searchRegularExpression;
			}
		}

		public SearchEventArgs(Regex _searchRegularExpression, bool _firstSearch)
		{
			this.searchRegularExpression = _searchRegularExpression;
			this.firstSearch = _firstSearch;
		}
	}
}
