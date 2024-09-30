using System.Collections.Generic;
using System.Xml.Serialization;

public class PlacedObject{

    public string objectName;
    public string itemTag;

    [XmlIgnore]
    public Item item;

    public List<ItemRequirement> requirements;

    public PlacedObject(){}

    
}