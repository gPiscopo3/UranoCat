using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Player
{

    public int level; 
    public int followers;
    public long money; 
    
    [XmlElement("Item")]
    public List<Item> inventory; 
    public Player() {}   

    public Player(int level, int followers, int money) { 
        this.level = level;
        this.followers = followers;
        this.money = money; 
        this.inventory = new List<Item>();

        CatModifier catModifier1 = new CatModifier(CatTag.DIVERTIMENTO, 5);
        CatModifier catModifier2 = new CatModifier(CatTag.FELICITA, 10);

        List<CatModifier> modifiers = new List<CatModifier>();
        modifiers.Add(catModifier2);
        
        this.inventory.Add(new CatItem("TAG001", "Topo Giocattolo", 3, modifiers, ItemType.CIBO));
    }
    
}
