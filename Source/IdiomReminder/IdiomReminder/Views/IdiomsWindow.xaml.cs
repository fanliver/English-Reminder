using System.Windows;
using Hardcodet.Wpf.TaskbarNotification;
using IdiomReminder.Models;
using IdiomReminder.Models.Helpers;
using IdiomReminder.ViewModels;

namespace IdiomReminder.Views {
	/// <summary>
	/// Interaction logic for IdiomsWindow.xaml
	/// </summary>
	public partial class IdiomsWindow : Window {
		private TaskbarIcon _taskbarIcon;

		public IdiomsWindow() {
			InitializeComponent();
			var viewModel = new IdiomsViewModel();
			viewModel.AddNewIdiomEvent += ShowAddIdiomWindow;
			viewModel.ShowRandomIdiomEvent += ShowRandomIdiom;
			DataContext = viewModel;
			_taskbarIcon = (TaskbarIcon) FindResource("MyNotifyIcon");
		}

		public void ShowAddIdiomWindow(object sender, NotificationEventArgs<bool, bool> e) {
			var addIdiomWindow = new AddIdiomWindow();
			if (e.OnCompleted != null) {
				e.OnCompleted(addIdiomWindow.ShowDialog() == true);
			}
		}

		private void ShowRandomIdiom(object sender, NotificationEventArgs<Idiom> e) {
			var idiom = e.OutData;
			var notificationHeader = Constants.NotificationHeaderNullIdiom;
			var notificationContent = Constants.NotificationContentNullIdiom;

			if (idiom != null) {
				notificationHeader = idiom.English;
				notificationContent = string.Format(Constants.NotificationContentPattern, e.OutData.Explanation,
					e.OutData.Vietnamese);
			}
			_taskbarIcon.ShowBalloonTip(notificationHeader, notificationContent, BalloonIcon.Info);
		}
	}
}
