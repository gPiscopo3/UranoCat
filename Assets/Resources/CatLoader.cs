using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatLoader : MonoBehaviour
{
    public const string path = "Assets/Resources/catStats.xml";
    Cat cat;

    void Awake(){

        this.cat = XMLHelper.LoadCatFromXml(path);
        Debug.Log($"Oggetto Cat deserializzato. Numero di Stat: {this.cat.stats.Count}");
    
    }

}