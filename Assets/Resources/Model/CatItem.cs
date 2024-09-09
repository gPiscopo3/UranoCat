using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class CatItem : Item
{
    
   

    [XmlElement("CatModifier")]
    public List<CatModifier> catModifiers;

    public CatItem(string v) {}

    public CatItem(string tag, string name, int durability, List<CatModifier> catModifiers)
    {
        this.tag = tag;
        this.name = name;
        this.durability = durability; 
        this.catModifiers = catModifiers;
    }

    public CatItem() {}

}

