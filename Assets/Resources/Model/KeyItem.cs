using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : Item
{
    

    public KeyItem() {}

    public KeyItem(string tag, string name, string description, string imagePath)
    {
        this.tag = tag;
        this.name = name;
        this.descrizione = description;
        this.imagePath = imagePath;
    }

}

