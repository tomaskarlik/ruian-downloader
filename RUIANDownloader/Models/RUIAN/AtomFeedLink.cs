using System.Xml.Serialization;

namespace RUIANDownloader.Models.RUIAN
{

    [XmlRoot(ElementName = "link", Namespace = "http://www.w3.org/2005/Atom")]
    public class AtomFeedLink
    {

        [XmlAttribute(AttributeName = "href")]
        public required string Href { get; set; }


        [XmlAttribute(AttributeName = "rel")]
        public string? Rel { get; set; }


        [XmlAttribute(AttributeName = "title")]
        public string? Title { get; set; }


        [XmlAttribute(AttributeName = "type")]
        public required string Type { get; set; }


        [XmlAttribute(AttributeName = "hreflang")]
        public string? HrefLang { get; set; }

    }

}
