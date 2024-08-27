using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;
using System;

[XmlRoot("FeatureCollection")]
public class FeatureContainer
{
    [XmlArray("Features")]
    [XmlArrayItem("Feature")]
    public List<Feature> items = new List<Feature>();

    public static FeatureContainer Load(string path)
    {

        TextAsset _xml = Resources.Load<TextAsset>(path);

        XmlSerializer serializer = new XmlSerializer(typeof(FeatureContainer));

        StringReader reader = new StringReader(_xml.text);

        FeatureContainer items = serializer.Deserialize(reader) as FeatureContainer;

        reader.Close();

        return items;

    }

}
