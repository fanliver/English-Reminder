using System.Windows.Input;
using IdiomReminder.Models;
using IdiomReminder.ViewModels.Utils;

namespace IdiomReminder.ViewModels {
	class AddIdiomViewModel : ObservableObject {

		private IdiomManager _idiomMgr;

		public AddIdiomViewModel() {
			NewIdiom = new Idiom();
			_idiomMgr = IdiomManager.Instance;
		}

		private Idiom _newIdiom;

		public Idiom NewIdiom {
			get { return _newIdiom; }
			set {
				_newIdiom = value;
				RaisePropertyChangedEvent("NewIdiom");
			}
		}

		public ICommand ButtonAddPressedCommand {
			get { return new DelegateCommand(ButtonAddPressedHandler); }
		}

		private void ButtonAddPressedHandler() {
			_idiomMgr.AddIdiom(NewIdiom);
			_idiomMgr.SerializeIdiomSource();
			NewIdiom = new Idiom();
		}

		public ICommand ButtonClearPressedCommand {
			get { return new DelegateCommand(ButtonClearPressedHandler); }
		}

		private void ButtonClearPressedHandler() {
			_newIdiom.English = "";
			_newIdiom.Explanation = "";
			_newIdiom.Vietnamese = "";
			RaisePropertyChangedEvent("NewIdiom");
		}
	}
}
