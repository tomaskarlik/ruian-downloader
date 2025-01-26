using System.Xml.Serialization;

namespace RUIANDownloader.Models.RUIAN
{

    [XmlRoot(ElementName = "category", Namespace = "http://www.w3.org/2005/Atom")]
    public class AtomFeedCategory
    {

        [XmlAttribute(AttributeName = "label")]
        public required string Label { get; set; }


        [XmlAttribute(AttributeName = "term")]
        public string? Term { get; set; }

    }

}
