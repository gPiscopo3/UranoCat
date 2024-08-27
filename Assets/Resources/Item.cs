using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

public class Item
{
    
    [XmlAttribute("name")]
    public string name;

    [XmlElement("Description")]
    public string description;
    
    public Dictionary<string, Feature> features = new Dictionary<string, Feature>();
    public List<Modifier> modifiers = new List<Modifier>();
    
}
