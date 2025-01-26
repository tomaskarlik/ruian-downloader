using System.Xml.Serialization;

namespace RUIANDownloader.Models.RUIAN
{

    [XmlRoot(ElementName = "entry", Namespace = "http://www.w3.org/2005/Atom")]
    public class AtomFeedEntry
    {

        [XmlElement(ElementName = "id")]
        public required string Id { get; set; }


        [XmlElement(ElementName = "title")]
        public string? Title { get; set; }


        [XmlElement(ElementName = "updated")]
        public required DateTime Updated { get; set; }


        [XmlElement(ElementName = "author")]
        public AtomFeedAuthor? Author { get; set; }


        [XmlElement(ElementName = "rights")]
        public string? Rights { get; set; }


        [XmlElement(ElementName = "link")]
        public required List<AtomFeedLink> Link { get; set; }


        [XmlElement(ElementName = "category")]
        public required AtomFeedCategory Category { get; set; }


        [XmlElement(ElementName = "spatial_dataset_identifier_code", Namespace = "http://inspire.ec.europa.eu/schemas/inspire_dls/1.0")]
        public string? SpatialDatasetIdentifierCode { get; set; }


        [XmlElement(ElementName = "spatial_dataset_identifier_namespace", Namespace = "http://inspire.ec.europa.eu/schemas/inspire_dls/1.0")]
        public string? SpatialDatasetIdentifierNamespace { get; set; }


        [XmlElement(ElementName = "polygon", Namespace = "http://www.georss.org/georss")]
        public string? Polygon { get; set; }

    }

}
