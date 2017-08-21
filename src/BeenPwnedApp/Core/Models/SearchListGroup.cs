using System.Collections.Generic;
using MvvmHelpers;

namespace BeenPwned.App.Core.Models
{
	public class SearchListGroup : ObservableRangeCollection<object>
	{
		public string Name { get; private set; }

		public SearchListGroup(string name)
			: base()
		{
			Name = name;
		}

		public SearchListGroup(string name, IEnumerable<object> source)
			: base(source)
		{
			Name = name;
		}
	}
}