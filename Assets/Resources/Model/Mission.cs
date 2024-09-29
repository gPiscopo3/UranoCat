using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Mission
{

    public string tag { get; set; }

    public List<ItemRequirement> RequiredItems { get; set; }
    public MissionState MissionState;

    public Mission()
    {
    }

}



public enum MissionState
{
    ATTIVO,
    NON_ATTIVO,
    COMPLETATO
}
