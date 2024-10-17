using System.Xml.Serialization;


public class ShopItem
{
    
    public string Tag { get; set; }

    [XmlIgnore] public Item item {get; set; }

    public long Price { get; set; }

    public int MinLevelRequired { get; set; }

    public ShopItem(){}

    public ShopItem(string Tag, long price, int minLevel){
        this.Tag = Tag;
        this.Price = price;
        this.MinLevelRequired = minLevel;
    }

    

}
