using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatLoader : MonoBehaviour
{
    public const string path = "Assets/Resources/catStats.xml";
    //public const string path = "Saves/catStats.xml";
    public Cat cat;

    void Awake(){

        this.cat = XMLHelper.LoadFromXml<Cat>(path);
        Debug.Log($"Oggetto Cat deserializzato. Numero di Stat: {this.cat.stats.Count}");
    
    }

}