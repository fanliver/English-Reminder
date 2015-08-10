using System.Xml.Serialization;

namespace IdiomReminder.Models {
	public class Example {
		[XmlAttribute]
		public string Content { get; set; }

		[XmlAttribute]
		public string Explanation { get; set; }

		public Example() { }

		public Example(string content, string explanation) {
			Content = content;
			Explanation = explanation;
		}
	}
}
