using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : Item
{
    
    public KeyItemType keyItemType;

    public KeyItem() {}

    public KeyItem(string tag, string name, KeyItemType keyItemType)
    {
        this.tag = tag;
        this.name = name;
        this.keyItemType = keyItemType;
    }

}

public enum KeyItemType
{
    UTENSILE, 
    CONSUMABILE
}
