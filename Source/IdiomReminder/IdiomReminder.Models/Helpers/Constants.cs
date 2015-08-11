namespace IdiomReminder.Models.Helpers {
	public class Constants {
		public const string MsgShowRandomIdiom = "Show idiom";
		public const string MsgAddNewIdiom = "Add new idiom";
		public const string IdiomSourceFilePathPattern = @"{0}\Idioms\IdiomSource.xml";
		public const string NotificationContentPattern = "{0}\n---\n{1}";
		public const string NotificationHeaderNullIdiom = "No idiom";
		public const string NotificationContentNullIdiom = "Please add new idioms to use this application";

		public const int NotificationIntervalInDay = 0;
		public const int NotificationIntervalInHour = 0;
		public const int NotificationIntervalInMinute = 0;
		public const int NotificationIntervalInSecond = 5;
	}
}
