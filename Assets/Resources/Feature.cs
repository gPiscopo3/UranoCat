using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

public class Feature
{
    
    [XmlAttribute("name")]
    public string name;
    
    [XmlElement("CurrentValue")]
    public float currentValue;

    [XmlElement("MaxValue")]
    public float maxValue;

}
