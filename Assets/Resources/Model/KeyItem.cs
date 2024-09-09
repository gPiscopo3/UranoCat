using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : Item
{
    
    public KeyItemType keyItemType;

    public KeyItem() {}

    public KeyItem(string tag, string name, string description, KeyItemType keyItemType, string imagePath)
    {
        this.tag = tag;
        this.name = name;
        this.descrizione = description;
        this.keyItemType = keyItemType;
        this.imagePath = imagePath;
    }

}

public enum KeyItemType
{
    UTENSILE, 
    CONSUMABILE
}
