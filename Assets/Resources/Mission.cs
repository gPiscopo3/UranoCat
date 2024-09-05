using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Mission
{

    [XmlAttribute("tag")]
    public string tag { get; set; }

    [XmlArray("RequiredMissions")]
    [XmlArrayItem("RequiredMission")]
    public List<string> RequiredMissions { get; set;}

    [XmlArray("RequiredItems")]
    [XmlArrayItem("RequiredItem")]
    public List<ItemRequirement> RequiredItems { get; set; }
    public MissionState MissionState;

    public Mission()
    {
        this.RequiredMissions = new List<string>();
        this.RequiredItems = new List<ItemRequirement>();
    }

}

public class ItemRequirement
{

    public KeyItem Item { get; set; }
    public int Quantity { get; set; }

    public ItemRequirement() {}

    public ItemRequirement(KeyItem item, int quantity)
    {
        this.Item = item;
        this.Quantity = quantity;
    }
}

public enum MissionState
{
    ATTIVO,
    NON_ATTIVO,
    COMPLETATO
}
