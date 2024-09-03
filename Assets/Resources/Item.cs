using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

[XmlInclude(typeof(CatItem))]
public abstract class Item
{

    public string tag;
    public string name; 
    
}
