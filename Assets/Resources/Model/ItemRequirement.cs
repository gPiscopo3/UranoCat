using System.Xml.Serialization;

public class ItemRequirement
{

    public string tag { get; set; }

    [XmlIgnore] public Item item;
    public int quantity { get; set; }

    public ItemRequirement() {}

}