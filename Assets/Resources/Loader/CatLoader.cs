using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class CatLoader : MonoBehaviour
{

    public const string saveFileName = "catStats.xml";
    public const string pathDefault = "Assets/Resources/" + saveFileName;
    public Cat cat;

    void Awake(){

        string profile = SaveInfo.profile;
        string save = SaveInfo.save;
        string path;

        if(save == null){
            this.cat = XMLHelper.LoadFromXml<Cat>(pathDefault);
            /*this.cat = new Cat();
            List<CatStat> stats = new List<CatStat>();
            stats.Add(new CatStat(50, 100, CatTag.SAZIETA));
            stats.Add(new CatStat(50, 100, CatTag.DIVERTIMENTO));
            stats.Add(new CatStat(50, 100, CatTag.FELICITA));
            this.cat.stats = stats;*/
        }
        else{
            path = "Saves/" + profile + "/" + save + "/" + saveFileName;
            this.cat = XMLHelper.LoadFromXml<Cat>(path);
        }
        
        Debug.Log($"Oggetto Cat deserializzato. Numero di Stat: {this.cat.stats.Count}");
    
    }


    public void SaveData(String profile, String save){

        String path = "Saves/" + profile + "/" + save + "/" + saveFileName;
        XMLHelper.SaveToXml<Cat>(cat, path);
    }

}