using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace IdiomReminder.Models {
	[XmlRoot]
	public class IdiomSource {

		public IdiomSource() {
			Author = "Fanliver Pham";
			Idioms = new List<Idiom>();
			Categories = new List<IdiomCategory>();
		}

		[XmlAttribute]
		public string Author { get; set; }

		public List<IdiomCategory> Categories { get; set; }

		public List<Idiom> Idioms { get; protected set; }

		public void AddIdiom(Idiom idiom) {
			Idioms.Add(idiom);
		}

		public void AddCategory(IdiomCategory category) {
			Categories.Add(category);
		}

		public Idiom GetRandomIdiom(bool isFavoriteOnly = false) {
			ICollection<Idiom> idioms = isFavoriteOnly ? Idioms.Where(i => i.IsFavorite).ToList() : Idioms;

			if (idioms.Count == 0) return null;

			var random = new Random((int)DateTime.Now.Ticks);
			var randomIndex = random.Next(idioms.Count);

			return idioms.ElementAt(randomIndex);
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
