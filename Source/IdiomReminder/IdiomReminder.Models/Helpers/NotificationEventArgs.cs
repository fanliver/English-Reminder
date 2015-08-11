using System;

namespace IdiomReminder.Models.Helpers {
	public class NotificationEventArgs : EventArgs {
		public NotificationEventArgs() : this ("Notification Event") {}

		public NotificationEventArgs(string msg) {
			Message = msg;
		}

		public string Message { get; protected set; }
	}

	public class NotificationEventArgs<TOutgoing> : NotificationEventArgs {
		public NotificationEventArgs() {}

		public NotificationEventArgs(string msg) {
			Message = msg;
		}

		public NotificationEventArgs(string msg, TOutgoing outData) : this(msg) {
			OutData = outData;
		}

		public TOutgoing OutData { get; protected set; }
	}

	public class NotificationEventArgs<TOutgoing, TIncoming> : NotificationEventArgs<TOutgoing> {
		public NotificationEventArgs() { }

		public NotificationEventArgs(string msg, TOutgoing outData, Action<TIncoming> onCompleted) : base(msg, outData) {
			OnCompleted = onCompleted;
		}

		public Action<TIncoming> OnCompleted { get; protected set; }
	}
}
