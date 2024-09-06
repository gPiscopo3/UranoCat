using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
    
    //public const string path = "Assets/Resources/playerData.xml";
    public const string path = "Saves/playerData.xml";
    public Player player;

    void Awake(){

        this.player = XMLHelper.LoadFromXml<Player>(path);
        if(player.inventory == null)
            player.inventory = new Inventory();
            

        Debug.Log($"Oggetto Player deserializzato. Livello: {this.player.level}, Followers: {this.player.followers}, Money: {this.player.money}");
        
    }

    public void SaveData(){

        XMLHelper.SaveToXml<Player>(player, path);
    }
}
