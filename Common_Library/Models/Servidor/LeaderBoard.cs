using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Common_Library.Models.Servidor
{
	[XmlRoot(ElementName = "jogador")]
	public class Jogador
	{
		[XmlAttribute(AttributeName = "username")]
		public string Username { get; set; }
		[XmlAttribute(AttributeName = "tempo")]
		public string Tempo { get; set; }
		[XmlAttribute(AttributeName = "quando")]
		public string Quando { get; set; }
	}

	[XmlRoot(ElementName = "nivel")]
	public class Nivel
	{
		[XmlElement(ElementName = "jogador")]
		public List<Jogador> Jogador { get; set; }
		[XmlAttribute(AttributeName = "dificuldade")]
		public string Dificuldade { get; set; }
	}

	[XmlRoot(ElementName = "top")]
	public class Top
	{
		[XmlElement(ElementName = "nivel")]
		public List<Nivel> Nivel { get; set; }
	}
}
