using System.Collections.Generic;
using System.Xml.Serialization;

public class PlacedObjectRequirement{

    public string name;

    [XmlIgnore]
    public Item item;

    public List<ItemRequirement> requirements;

    public PlacedObjectRequirement(){}

    
}