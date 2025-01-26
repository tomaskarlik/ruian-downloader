using System.Xml.Serialization;

namespace RUIANDownloader.Models.RUIAN
{

    [XmlRoot(ElementName = "feed", Namespace = "http://www.w3.org/2005/Atom")]
    public class AtomFeed
    {

        [XmlElement(ElementName = "id")]
        public required string Id { get; set; }


        [XmlElement(ElementName = "title")]
        public string? Title { get; set; }


        [XmlElement(ElementName = "subtitle")]
        public string? Subtitle { get; set; }


        [XmlElement(ElementName = "updated")]
        public required DateTime Updated { get; set; }


        [XmlElement(ElementName = "author")]
        public AtomFeedAuthor? Author { get; set; }


        [XmlElement(ElementName = "rights")]
        public string? Rights { get; set; }


        [XmlElement(ElementName = "link")]
        public required List<AtomFeedLink> Link { get; set; }


        [XmlElement(ElementName = "entry")]
        public required List<AtomFeedEntry> Entry { get; set; }


        [XmlAttribute(AttributeName = "georss", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string? GeoRss;


        [XmlAttribute(AttributeName = "inspire_dls", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string? InspireDls;


        [XmlAttribute(AttributeName = "opensearch", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string? Opensearch;


        [XmlAttribute(AttributeName = "lang", Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string? Lang;

        [XmlText]
        public string? Text;

    }

}
