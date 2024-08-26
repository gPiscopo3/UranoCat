using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

public class Item
{
    
    [XmlAttribute("name")]
    public string name;

    [XmlElement("Description")]
    public string description;

    [XmlElement("Price")]
    public float price;
    
}
