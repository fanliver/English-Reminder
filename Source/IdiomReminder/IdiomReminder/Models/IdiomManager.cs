using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using IdiomReminder.Helpers;

namespace IdiomReminder.Models {
	class IdiomManager {
		private static readonly object LockObject = new object();
		private static IdiomManager _instance;
		private IdiomSource _idiomSrc;
		private readonly string _idiomSourceFilePath;

		private IdiomManager() {
			_idiomSourceFilePath = string.Format(Constants.IdiomSourceFilePathPattern,
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
			InitializeIdiomSource();
		}

		public static IdiomManager Instance {
			get {
				if (_instance != null) return _instance;

				lock (LockObject) {
					_instance = new IdiomManager();
				}

				return _instance;
			}
		}

		public bool IsFavoriteOnly { get; set; }

		public void AddIdiom(Idiom idiom) {
			if (idiom == null) return;
			_idiomSrc.AddIdiom(idiom);
		}

		public Idiom GetRandomIdiom() {
			return _idiomSrc.GetRandomIdiom(IsFavoriteOnly);
		}

		public ICollection<Idiom> GetAllIdioms() {
			return _idiomSrc.GetAllIdioms(IsFavoriteOnly);
		}

		public ICollection<Idiom> GetIdiomsByCategory(Guid categoryId) {
			return _idiomSrc.GetIdiomsByCategory(categoryId);
		}

		public ICollection<Idiom> SearchIdioms(string keyword) {
			return _idiomSrc.SearchIdioms(keyword, IsFavoriteOnly);
		}

		public void InitializeIdiomSource() {
			var idiomSrcFile = new FileInfo(_idiomSourceFilePath);
			if (idiomSrcFile.Exists) {
				DeserializeIdiomSource();
			}
			else {
				_idiomSrc = new IdiomSource();
			}
		}

		public void SerializeIdiomSource() {
			var xmlSerializer = new XmlSerializer(typeof(IdiomSource));
			using (var writer = new StreamWriter(_idiomSourceFilePath)) {
				xmlSerializer.Serialize(writer, _idiomSrc);
			}
		}

		public void DeserializeIdiomSource() {
			var xmlSerializer = new XmlSerializer(typeof(IdiomSource));
			using (var reader = new StreamReader(_idiomSourceFilePath)) {
				_idiomSrc = (IdiomSource) xmlSerializer.Deserialize(reader);
			}
		}
	}
}
