using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Common_Library.Models.GameModels
{
    [XmlRoot(ElementName = "top")]
    public class Top
    {
        [XmlElement(ElementName = "TopFacil")]
        public int TopFacil { get; set; }
        [XmlElement(ElementName = "TopMedio")]
        public int TopMedio { get; set; }
        [XmlElement(ElementName = "NomeFacil")]
        public string NomeFacil { get; set; }
        [XmlElement(ElementName = "NomeMedio")]
        public string NomeMedio { get; set; }
    }
}
