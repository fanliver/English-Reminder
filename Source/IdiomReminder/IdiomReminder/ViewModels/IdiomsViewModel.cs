using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Threading;
using IdiomReminder.Helpers;
using IdiomReminder.Models;
using IdiomReminder.ViewModels.Utils;

namespace IdiomReminder.ViewModels {
	class IdiomsViewModel : ObservableObject {

		private IdiomManager _idiomMgr;
		private DispatcherTimer _timer;

		public event EventHandler<NotificationEventArgs<bool, bool>> AddNewIdiomEvent;

		public event EventHandler<NotificationEventArgs<Idiom>> ShowRandomIdiomEvent;

		public IdiomsViewModel() {
			_idiomMgr = IdiomManager.Instance;
			Idioms = new ObservableCollection<Idiom>(_idiomMgr.GetAllIdioms());
			Interval = 15;
		}

		private void InitTimer() {
			if (_timer != null && _timer.IsEnabled) {
				_timer.Stop();
			}

			_timer = new DispatcherTimer {
				Interval = ConvertMinuteToTimeSpan()
			};

			_timer.Tick += OnShowRandomIdiom;
			_timer.Start();
		}

		private TimeSpan ConvertMinuteToTimeSpan() {
			int minutes = _interval;
			var days = minutes / 1440;
			minutes %= 1440;
			var hours = minutes / 60;
			minutes %= 60;

			return new TimeSpan(days, hours, minutes, 0);
		}

		private void OnShowRandomIdiom(object sender, EventArgs e) {
			if (ShowRandomIdiomEvent == null) return;

			var idiom = _idiomMgr.GetRandomIdiom();

			ShowRandomIdiomEvent(this, new NotificationEventArgs<Idiom>(Constants.MsgShowRandomIdiom, idiom));

			if (idiom == null) {
				_timer.Stop();
			}
		}

		private int _interval;

		public int Interval {
			get { return _interval; }
			set {
				if (value < 1) {
					value = 1;
				}

				_interval = value;
				RaisePropertyChangedEvent("Interval");
				InitTimer();
			}
		}

		private ObservableCollection<Idiom> _idioms;

		public ObservableCollection<Idiom> Idioms {
			get { return _idioms; }
			set {
				_idioms = value;
				RaisePropertyChangedEvent("Idioms");
			}
		}

		private Idiom _selectedIdiom;

		public Idiom SelectedIdiom {
			get { return _selectedIdiom; }
			set {
				_selectedIdiom = value;
				RaisePropertyChangedEvent("SelectedIdiom");
			}
		}

		public ICommand ButtonAddPressedCommand {
			get { return new DelegateCommand(ButtonAddPressedHandler); }
		}

		private void ButtonAddPressedHandler() {
			if (AddNewIdiomEvent != null) {
				AddNewIdiomEvent(this, new NotificationEventArgs<bool, bool>(Constants.MsgAddNewIdiom, true, AddNewIdiomCompleted));
			}
		}

		private void AddNewIdiomCompleted(bool obj) {
			Idioms = new ObservableCollection<Idiom>(_idiomMgr.GetAllIdioms());
		}
	}
}
