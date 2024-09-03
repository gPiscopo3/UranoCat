using System.IO;
using System.Xml.Serialization;

public static class XMLHelper
{
    public static Cat LoadCatFromXml(string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Cat));

        using (StreamReader reader = new StreamReader(filePath))
        {
            return (Cat)serializer.Deserialize(reader);
        }
    }

    public static void SaveCatToXml(Cat cat, string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Cat));

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            serializer.Serialize(writer, cat);
        }
    }

}