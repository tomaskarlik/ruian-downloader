using System.Xml.Serialization;

namespace RUIANDownloader.Models.RUIAN
{

    [XmlRoot(ElementName = "author", Namespace = "http://www.w3.org/2005/Atom")]
    public class AtomFeedAuthor
    {

        [XmlElement(ElementName = "name")]
        public string? Name { get; set; }


        [XmlElement(ElementName = "uri")]
        public string? Uri { get; set; }


        [XmlElement(ElementName = "email")]
        public string? Email { get; set; }

    }

}
