using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class CatItem : Item
{
    
    public int numUses;

    [XmlElement("CatModifier")]
    public List<CatModifier> catModifiers;

    public CatItem(string v) {}

    public CatItem(string tag, string name, int numUses, List<CatModifier> catModifiers)
    {
        this.tag = tag;
        this.name = name;
        this.numUses = numUses; 
        this.catModifiers = catModifiers;
    }

    public CatItem() {}

    public void useItem(){
        numUses --;
    }

    public bool isUsable(){
        return (numUses > 0);
    }

}

