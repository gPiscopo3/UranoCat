using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionLoader : MonoBehaviour
{
    public const string path = "Assets/Resources/missionsData.xml"; 

    List<Mission> missions;

    void Awake()
    {
        
        this.missions = XMLHelper.LoadFromXml<List<Mission>>(path);
        Debug.Log($"Lista di missioni deserializzata. Numero di missioni: {this.missions.Count}");

    }
}
