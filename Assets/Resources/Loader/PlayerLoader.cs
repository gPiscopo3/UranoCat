using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
    
    public const string filePlayer = "playerData.xml";
    public const string fileCatItems = "cat_items.xml";
    public const string fileKeyItems = "key_items.xml";
    public const string pathDefault = "Assets/Resources/" + filePlayer;
    public Player player;

    void Awake(){

        String profile = SaveInfo.profile;
        String save = SaveInfo.save;
        String path;

        if(save == null){
             this.player = XMLHelper.LoadFromXml<Player>(pathDefault);
             player.inventory = new Inventory{
                items = new List<InventoryItem>()
            };

        }
        else{
            path = "Saves/" + SaveInfo.profile + "/" + SaveInfo.save + "/";
            this.player = XMLHelper.LoadFromXml<Player>(path  + filePlayer);
        }
            



        Debug.Log($"Oggetto Player deserializzato. Livello: {this.player.level}, Followers: {this.player.followers}, Money: {this.player.money}");
        
    }

    public void SaveData(String profile, String save){

        String path = "Saves/" + profile + "/" + save + "/" + filePlayer;
        XMLHelper.SaveToXml<Player>(player, path);
    }
}
