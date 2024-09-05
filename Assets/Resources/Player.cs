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
    
}
