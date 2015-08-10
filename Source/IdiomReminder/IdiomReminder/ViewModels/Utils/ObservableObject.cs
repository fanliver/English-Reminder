using System.ComponentModel;

namespace IdiomReminder.ViewModels.Utils {
	public class ObservableObject : INotifyPropertyChanged {
		public event PropertyChangedEventHandler PropertyChanged;

		protected void RaisePropertyChangedEvent(string propertyName) {
			var handler = PropertyChanged;
			if (handler != null)
				handler(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
