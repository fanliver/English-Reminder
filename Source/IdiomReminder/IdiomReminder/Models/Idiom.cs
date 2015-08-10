using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace IdiomReminder.Models {
	public class Idiom {
		[XmlAttribute]
		public string English { get; set; }

		[XmlAttribute]
		public string Vietnamese { get; set; }

		[XmlAttribute]
		public string Explanation { get; set; }

		[XmlAttribute]
		public bool IsFavorite { get; set; }

		[XmlAttribute]
		public Guid Category { get; set; }

		public List<Example> Examples { get; set; }
	}
}
