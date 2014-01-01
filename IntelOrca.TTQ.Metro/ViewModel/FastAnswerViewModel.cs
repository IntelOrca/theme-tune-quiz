using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelOrca.TTQ.Metro.ViewModel
{
	public class FastAnswerViewModel : ViewModel
	{
		public class CategorySelectionItem
		{
			public bool Checked { get; set; }
			public string Text { get; set; }

			public CategorySelectionItem(bool @checked, string text)
			{
				Checked = @checked;
				Text = text;
			}
		}

		public IReadOnlyList<CategorySelectionItem> SelectedCategories { get; set; }
	}
}
