using System;
using System.Xml.Serialization;

namespace IdiomReminder.Models {
	public class IdiomCategory {
		public IdiomCategory() {
			Id = Guid.NewGuid();
			Name = "Unknown";
		}

		public IdiomCategory(string name) {
			Id = Guid.NewGuid();
			Name = name;
		}

		[XmlAttribute]
		public Guid Id { get; set; }

		[XmlAttribute]
		public string Name { get; set; }
	}
}
