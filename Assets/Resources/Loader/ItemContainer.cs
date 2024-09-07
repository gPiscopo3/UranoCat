using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;
using System;
using UnityEditorInternal.Profiling.Memory.Experimental;

[XmlRoot("CatItemList")]
public class ItemContainer
{
    
    [XmlElement("CatItem")]
    public List<CatItem> items { get; set; }

    public Item GetItem(String tag){
        foreach(Item item in items){
            if(item.tag.Equals(tag))
                return item;
        }
        return null;
    }

    public static ItemContainer Load(string path)
    {

        TextAsset _xml = Resources.Load<TextAsset>(path);

        XmlSerializer serializer = new XmlSerializer(typeof(ItemContainer));

        StringReader reader = new StringReader(_xml.text);

        ItemContainer items = serializer.Deserialize(reader) as ItemContainer;

        reader.Close();
        
        return items;

    }

    public static ItemContainer LoadFromXml(string filePath)
    {   
        XmlSerializer serializer = new XmlSerializer(typeof(ItemContainer));

        using (StreamReader reader = new StreamReader(filePath))
        {
            return (ItemContainer)serializer.Deserialize(reader);
        }
    }   

    public static void SaveToXml(ItemContainer catItemList, string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(ItemContainer));

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            serializer.Serialize(writer, catItemList);
        }
    }

}
