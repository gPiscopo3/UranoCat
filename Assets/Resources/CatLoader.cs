using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatLoader : MonoBehaviour
{
    public const string path = "Assets/Resources/catStats.xml";
    Cat cat;

    void Awake(){
        Cat deserializedCat = XMLHelper.LoadCatFromXml(path);
        Debug.Log($"Oggetto Cat deserializzato. Numero di Stat: {deserializedCat.stats.Count}");

        // Stampa dei dettagli degli oggetti Stat deserializzati
        foreach (var stat in deserializedCat.stats)
        {
            Debug.Log($"CatTag = {stat.catTag}, CurrentValue = {stat.currentValue}, MaxValue = {stat.maxValue}");
        }
    }

}