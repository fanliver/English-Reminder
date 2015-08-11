using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdiomReminder.Models;

namespace IdiomReminderConsole {
	class Program {
		static void Main(string[] args) {
			IdiomManager mgr = IdiomManager.Instance;
			Console.WriteLine("Count: " + mgr.GetAllIdioms().Count);
			for (var index = 0; index < mgr.GetAllIdioms().Count; index++) {
				Console.WriteLine(mgr.GetRandomIdiom().English);
				if (index==6) mgr.AddIdiom(new Idiom() {
					English = "Recently added",
					Vietnamese = "Vua them vao",
					Explanation = "Vua moi duoc them vao co so du lieu"
				});
			}
		}
	}
}
