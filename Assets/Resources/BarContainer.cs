using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;
using System;

[XmlRoot("BarCollection")]
public class BarContainer
{
    [XmlArray("Bars")]
    [XmlArrayItem("Bar")]
    public List<Bar> items = new List<Bar>();

    public static BarContainer Load(string path)
    {

        TextAsset _xml = Resources.Load<TextAsset>(path);

        XmlSerializer serializer = new XmlSerializer(typeof(BarContainer));

        StringReader reader = new StringReader(_xml.text);

        BarContainer items = serializer.Deserialize(reader) as BarContainer;

        reader.Close();

        return items;

    }

}
