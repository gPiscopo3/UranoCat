using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public static class XMLHelper
{


    public static T LoadFromXml<T>(string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));

        using (StreamReader reader = new StreamReader(filePath))
        {
            return (T)serializer.Deserialize(reader);
        }
    }

    public static void SaveToXml<T>(T obj, string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            serializer.Serialize(writer, obj);
        }
    }

}