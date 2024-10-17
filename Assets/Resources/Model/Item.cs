using System.Xml.Serialization;

[XmlInclude(typeof(CatItem))]
[XmlInclude(typeof(KeyItem))]
public abstract class Item
{

    public string tag;
    public string name; 
    public string descrizione;
    public int durability;
    public string imagePath;
        
}
