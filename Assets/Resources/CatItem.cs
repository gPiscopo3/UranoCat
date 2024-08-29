using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatItem : Item
{
    
    public int durability;
    public List<CatModifier> catModifiers;
    public ItemType itemType;

    public CatItem(string tag, string name, int durability, List<CatModifier> catModifiers, ItemType itemType)
    {
        this.tag = tag;
        this.name = name;
        this.durability = durability; 
        this.catModifiers = catModifiers;
        this.itemType = itemType;
    }

    public CatItem(string tag, string name, int durability, List<CatModifier> catModifiers, string itemType)
    {
        this.tag = tag;
        this.name = name;
        this.durability = durability; 
        this.catModifiers = catModifiers;
        this.itemType = (ItemType) Enum.Parse(typeof(ItemType), itemType, true);
    }

}

public enum ItemType
{
    CIBO, 
    DIVERTIMENTO, 
    POSIZIONABILE

}