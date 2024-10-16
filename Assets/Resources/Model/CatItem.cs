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

    public CatItem(string tag,string name,  string descrizione,  int durability, string imagePath, List<CatModifier> catModifiers)
    {
        this.tag = tag;
        this.name = name;
        this.descrizione = descrizione;
        this.durability = durability;
        this.imagePath = imagePath; 
        this.catModifiers = catModifiers;
    }

    public CatItem() {}

}

