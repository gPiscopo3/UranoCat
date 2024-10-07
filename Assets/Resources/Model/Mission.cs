using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Mission
{

    public string tag { get; set; }

    public List<ItemRequirement> RequiredItems { get; set; }
    public int experience;
    public string name;
    public string description;
    public MissionState MissionState;
    public bool enableSpaceshipModification;
    public string spaceshipPart;

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
