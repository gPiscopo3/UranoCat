using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class ShopItem
{
    [XmlAttribute("tag")]
    public string Tag { get; set; }

    [XmlElement("Name")]
    public string Name { get; set; }

    [XmlElement("Description")]
    public string Description { get; set; }

    [XmlElement("Price")]
    public long Price { get; set; }

    [XmlElement("MinLevelRequired")]
    public int MinLevelRequired { get; set; }

    public ShopItem(){}

    public ShopItem(string tag, string name, string description, long price, int minLevelRequired)
    {
        this.Tag = tag;
        this.Name = name;
        this.Description = description;
        this.Price = price;
        this. MinLevelRequired = minLevelRequired;
    }

}
