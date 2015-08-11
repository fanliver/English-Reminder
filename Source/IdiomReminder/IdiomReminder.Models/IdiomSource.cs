using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace IdiomReminder.Models {
	[XmlRoot]
	public class IdiomSource {
		private List<Idiom> _unpickedIdioms;

		public IdiomSource() {
			Author = "Fanliver Pham";
			Idioms = new List<Idiom>();
			_unpickedIdioms = new List<Idiom>();
			Categories = new List<IdiomCategory>();
		}

		[XmlAttribute]
		public string Author { get; set; }

		public List<IdiomCategory> Categories { get; set; }

		public List<Idiom> Idioms { get; protected set; }

		public void ResetIdiomSource() {
			_unpickedIdioms.AddRange(Idioms);
		}

		public void AddIdiom(Idiom idiom) {
			Idioms.Add(idiom);
			_unpickedIdioms.Add(idiom);
		}

		public void AddCategory(IdiomCategory category) {
			Categories.Add(category);
		}

		public Idiom GetRandomIdiom(bool isFavoriteOnly = false) {
			if (_unpickedIdioms.Count == 0) {
				ResetIdiomSource();
			}

			ICollection<Idiom> idioms = isFavoriteOnly ? _unpickedIdioms.Where(i => i.IsFavorite).ToList() : _unpickedIdioms;

			if (idioms.Count == 0) return null;

			var random = new Random((int)DateTime.Now.Ticks);
			var randomIndex = random.Next(idioms.Count);

			var result = idioms.ElementAt(randomIndex);
			idioms.Remove(result);

			return result;
		}

		public ICollection<Idiom> GetAllIdioms(bool isFavoriteOnly = false) {
			return Idioms.Where(i => !isFavoriteOnly || i.IsFavorite).ToList();
		}

		public ICollection<Idiom> GetIdiomsByCategory(Guid categoryId, bool isFavoriteOnly = false) {
			return Idioms.Where(i => (!isFavoriteOnly || i.IsFavorite) && i.Category.Equals(categoryId)).ToList();
		}

		public ICollection<Idiom> SearchIdioms(string keyword, bool isFavoriteOnly = false) {
			return Idioms
				.Where(i => (!isFavoriteOnly || i.IsFavorite) && i.English.ToLower().Contains(keyword.ToLower()))
				.ToList();
		} 

	}
}
