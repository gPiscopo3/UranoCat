using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : Item
{

    public KeyItem() {}

    public KeyItem(string tag, string name, string descrizione, int durability)
    {
        this.tag = tag;
        this.name = name;
        this.descrizione = descrizione;
        this.durability = durability;
    }

}

