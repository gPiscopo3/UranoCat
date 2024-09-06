using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

[XmlInclude(typeof(CatItem))]
[XmlInclude(typeof(KeyItem))]
public abstract class Item
{

    public string tag;
    public string name; 
    public int durability;

    public Type type;

    public enum Type{
        CAT,
        SHIP

    }

    
    
}
