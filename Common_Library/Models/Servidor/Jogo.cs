using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Common_Library.Models.Servidor
{
	[XmlRoot(ElementName = "posicao")]
	public class Posicao
	{
		[XmlAttribute(AttributeName = "linha")]
		public string Linha { get; set; }
		[XmlAttribute(AttributeName = "coluna")]
		public string Coluna { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "campo")]
	public class Campo
	{
		[XmlElement(ElementName = "posicao")]
		public List<Posicao> Posicao { get; set; }
		[XmlAttribute(AttributeName = "nivel")]
		public string Nivel { get; set; }
	}
}
