using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Common_Library.Models.Servidor
{
	[XmlRoot(ElementName = "perfil")]
	public class Profile
	{
		[XmlElement(ElementName = "nomeabreviado")]
		public string Nomeabreviado { get; set; }
		[XmlElement(ElementName = "email")]
		public string Email { get; set; }
		[XmlElement(ElementName = "fotografia")]
		public string Fotografia { get; set; }
		[XmlElement(ElementName = "pais")]
		public string Pais { get; set; }
		[XmlElement(ElementName = "jogos")]
		public Jogos Jogos { get; set; }
		[XmlElement(ElementName = "tempos")]
		public Tempos Tempos { get; set; }
	}
	[XmlRoot(ElementName = "jogos")]
	public class Jogos
	{
		[XmlElement(ElementName = "ganhos")]
		public string Ganhos { get; set; }
		[XmlElement(ElementName = "perdidos")]
		public string Perdidos { get; set; }
	}
	[XmlRoot(ElementName = "tempos")]
	public class Tempos
	{
		[XmlElement(ElementName = "Facil")]
		public string Facil { get; set; }
		[XmlElement(ElementName = "Medio")]
		public string Medio { get; set; }
	}
}
