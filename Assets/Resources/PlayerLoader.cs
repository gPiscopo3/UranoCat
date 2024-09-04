using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
    
    public const string path = "Assets/Resources/playerData.xml";
    Player player;

    void Awake(){

        this.player = XMLHelper.LoadPlayerFromXml(path);
        Debug.Log($"Oggetto Player deserializzato. Livello: {this.player.level}, Followers: {this.player.followers}, Money: {this.player.money}, Inventory: {this.player.inventory.Count}");
        
    }
}
