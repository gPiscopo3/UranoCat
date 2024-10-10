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

    public bool IsItemRequired(Item itemToCheck)
    {
        if (RequiredItems == null || itemToCheck == null)
            return false;

        foreach (var requirement in RequiredItems)
        {
            if (requirement.item != null && requirement.item.tag == itemToCheck.tag)
            {
                return true; // L'oggetto è stato trovato nella lista
            }
        }
        return false; // L'oggetto non è stato trovato nella lista
    }

}



public enum MissionState
{
    ATTIVO,
    NON_ATTIVO,
    COMPLETATO
}
