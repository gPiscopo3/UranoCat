using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionLoader : MonoBehaviour
{

    public const string saveFileName = "missionsData.xml";
    public const string pathDefault = "Assets/Resources/" + saveFileName;
    //public const string path = "Assets/Resources/missionsData.xml"; 

    public List<Mission> missions;

    void Awake()
    {
        string profile = SaveInfo.profile;
        string save = SaveInfo.save;
        string path;

        if (save == null)
        {
            this.missions = XMLHelper.LoadFromXml<List<Mission>>(pathDefault);
        }
        else
        {
            path = "Assets/Saves/" + profile + "/" + save + "/" + saveFileName;
            this.missions = XMLHelper.LoadFromXml<List<Mission>>(path);
        }

        Debug.Log($"Oggetto MIssioni deserializzato. Numero di missioni: {this.missions.Count}");
        /*
        Debug.Log($"Lista di missioni deserializzata. Numero di missioni: {this.missions.Count}");
        foreach (Mission mission in missions)
        {
            Debug.Log($"{mission.tag}, {mission.MissionState}");
            foreach(ItemRequirement requirement in mission.RequiredItems)
            {
                Debug.Log($"\t{requirement.tagKeyItem}, {requirement.Quantity}");
            }
            foreach(string missionRequired in mission.RequiredMissions)
            {
                Debug.Log($"\t {missionRequired}");
            }
        }
        */
    }

    public void SaveData(String profile, String save)
    {

        String path = "Saves/" + profile + "/" + save + "/" + saveFileName;
        XMLHelper.SaveToXml<List<Mission>>(this.missions, path);
    }
}
