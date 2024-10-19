using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    
    public static string loaded_profile = "profile";
    public static string loaded_save = "save";

    public const string fileCat = "catStats.xml";
    public const string filePlayer = "playerData.xml";
    public const string fileMissions = "missionsData.xml";
    public const string fileVideo = "videos.xml";
    public const string fileStats = "stats.xml";
    public const string placedObjectsFile = "placedObjects.xml";


    public string profiles_path = Environment.ExpandEnvironmentVariables("%USERPROFILE%/Saved Games/UranoCat/profiles.xml");
    public const string infos_file_name = "saves.xml";
    public string savePath = Environment.ExpandEnvironmentVariables("%USERPROFILE%/Saved Games/UranoCat/");
    public const string pathDefault = "Assets/Resources/Saves/";



    public const string catPath = "Assets/Resources/cat_items.xml";
    public const string shopPath = "Assets/Resources/shop_items.xml";
    public const string keyPath = "Assets/Resources/key_items.xml";
    public const string RulesPath = "Assets/Resources/rules.xml";
    public const string songsPath = "Assets/Resources/songs.xml";


    public Cat cat;
    public Player player;
    public List<Mission> missions;
    public List<Video> videos;
    public SavedStats savedStats;
    public List<PlacedObjectStatus> placedObjectsStatus;
    public List<Profile> profiles;
    public List<SaveInfo> infos;
    public List<Song> songs;
    public List<Item> items;
    public List<ShopItem> shopItems;
    public List<PlacedObject> placedObjects;
    public Rules rules;

    private PlayerController playerController;




    void Awake(){

        playerController = FindObjectOfType<PlayerController>();

        LoadAssets();
        LoadSave();
        
    }

    void LoadAssets(){

         items = new List<Item>();
        List<CatItem> catItemList = XMLHelper.LoadFromXml<List<CatItem>>(catPath);
        

        items.AddRange(catItemList);

        List<KeyItem> keyItems = XMLHelper.LoadFromXml<List<KeyItem>>(keyPath);
        items.AddRange(keyItems);
        

        this.shopItems =  XMLHelper.LoadFromXml<List<ShopItem>>(shopPath);
        foreach(ShopItem shopItem in shopItems){
            shopItem.item = GetItem(shopItem.Tag);
        }
        
        this.rules = XMLHelper.LoadFromXml<Rules>(RulesPath);

        this.songs = XMLHelper.LoadFromXml<List<Song>>(songsPath);
    }

    void LoadSave(){

        string profile = loaded_profile;
        string save = loaded_save;
        string path;

        if(save == null)
            path = pathDefault;
        else
            path = savePath + profile + "/" + save + "/";
    

        this.cat = XMLHelper.LoadFromXml<Cat>(path + fileCat);
        this.player = XMLHelper.LoadFromXml<Player>(path + filePlayer);

        playerController.setInitialPosition(player.x, player.y, player.z);
        
        this.missions = XMLHelper.LoadFromXml<List<Mission>>(path + fileMissions);
        this.videos = XMLHelper.LoadFromXml<List<Video>>(path + fileVideo);
        this.savedStats = XMLHelper.LoadFromXml<SavedStats>(path + fileStats);
        this.placedObjectsStatus = XMLHelper.LoadFromXml<List<PlacedObjectStatus>>(path + placedObjectsFile);

        this.profiles = XMLHelper.LoadFromXml<List<Profile>>(profiles_path);
        this.infos = XMLHelper.LoadFromXml<List<SaveInfo>>(savePath + profile + "/" + infos_file_name);


       
        foreach(InventoryItem inventoryItem in player.inventory.items)
            inventoryItem.item = GetItem(inventoryItem.tag);

         foreach(Mission mission in missions)
                foreach(ItemRequirement itemRequirement in mission.RequiredItems){
                    itemRequirement.item = GetItem(itemRequirement.tag);
                    if(itemRequirement.quantity == 0)
                        itemRequirement.quantity = 1;
                }
        
    }

    public Item GetItem(string tag){
        foreach(Item item in items){
            if(item.tag.Equals(tag))
                return item;
        }
        return null;
    }
    


    public void SaveData(String save){

        String path = savePath + loaded_profile + "/" + save;
        if(!System.IO.Directory.Exists(path))
            System.IO.Directory.CreateDirectory(path);

        path = path + "/";

        XMLHelper.SaveToXml<Cat>(cat, path + fileCat);
        XMLHelper.SaveToXml<Player>(player, path + filePlayer);
        XMLHelper.SaveToXml<List<Mission>>(missions, path + fileMissions);
        XMLHelper.SaveToXml<List<Video>>(videos, path + fileVideo);
        
        XMLHelper.SaveToXml<SavedStats>(savedStats, path + fileStats);
        XMLHelper.SaveToXml(placedObjectsStatus, path + placedObjectsFile);

   
        Profile profile = profiles.Find(x => x.name.Equals(loaded_profile));
        profile.last_save = save;
        profile.dateTime = DateTime.Now;
        XMLHelper.SaveToXml<List<Profile>>(profiles, profiles_path);
        

        SaveInfo info = infos.FirstOrDefault(x => x.name.Equals(save));

        if(info == null){
            info = new SaveInfo{
                level = player.level,
                money = (int)player.money,
                seconds = savedStats.timestamp_seconds,
                name = save,
                time = DateTime.Now
            };
            infos.Add(info);
        }
        else{
            info.level = player.level;
            info.money = (int)player.money;
            info.seconds = savedStats.timestamp_seconds;
            info.time = DateTime.Now;
        }

        XMLHelper.SaveToXml<List<SaveInfo>>(infos, savePath + loaded_profile + "/" + infos_file_name);




        

    }

     

}

