using System.ComponentModel;

namespace IntelOrca.TTQ.Metro.ViewModel
{
	/// <summary>
	/// Represents a model for a view with property change event behaviour.
	/// </summary>
	public class ViewModel : INotifyPropertyChanged
	{
		/// <summary>
		/// Occurs when a property value changes.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// Raises the property changed event.
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		protected void RaisePropertyChangedEvent(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
