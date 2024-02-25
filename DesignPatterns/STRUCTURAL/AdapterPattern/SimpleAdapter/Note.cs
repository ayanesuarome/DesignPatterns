using System.Xml.Serialization;

namespace AdapterPattern.SimpleAdapter;

[Serializable, XmlRoot("note")]
public class Note
{
    [XmlElement("to")]
    public string To { get; set; }

    [XmlElement("from")]
    public string From { get; set; }

    [XmlElement("heading")]
    public string Heading { get; set; }
    
    [XmlElement("body")]
    public string Body { get; set; }
}
