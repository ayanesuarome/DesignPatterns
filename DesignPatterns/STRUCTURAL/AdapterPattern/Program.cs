// See https://aka.ms/new-console-template for more information

// Converts an interface into another interface client that clients expect.
// Allow classes to work together that could not because of theri imcopatibilities.

using AdapterPattern.SimpleAdapter;

Console.WriteLine("Simple Adapter");
string xml = @"<?xml version='1.0' encoding='UTF-8' standalone='yes'?>
                    <note>
                        <to>John</to>
                        <from>Jane</from>
                        <heading>Reminder</heading>
                        <body>Remember to pick me up at work!</body>
                    </note>";

// Before adapter
IXmlParser<Note> parser = new XmlParser<Note>();
Note note = parser.Parse(xml);
WriteLine("XML Format:");
WriteLine(parser.ConvertToXml(note));
WriteLine();

// Needs: clients only accepts IJsonParser and needs to parse the XML to JSON
// Solution: Create a new interface "XmlToJsonAdapter" which implements "IJsonParser" so that it can be accepted as type "IJsonParser"
// Client accept "IJsonParser"
// Adaptee: "IXmlParser"
// Adapter: "XmlToJsonAdapter"

// After adapter
IJsonParser<Note> jsonParser = new XmlToJsonAdapter<Note>();
note = jsonParser.Parse(xml);
WriteLine("JSON Format:");
WriteLine(jsonParser.ConvertToJson(note));