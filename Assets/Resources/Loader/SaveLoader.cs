using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SaveLoader : MonoBehaviour
{
    
    public static string loaded_profile = "profile";
    public static string loaded_save = "save";

    public const string fileCat = "catStats.xml";
    public const string filePlayer = "playerData.xml";
    public const string fileMissions = "missionsData.xml";
    public const string fileVideo = "videos.xml";
    public const string fileStats = "stats.xml";
    public const string profiles_path = "Saves/profiles.xml";
    public const string infos_file_name = "saves.xml";
    public const string pathDefault = "Assets/Resources/Saves/";
    public Cat cat;
    public Player player;
    public List<Mission> missions;
    public List<Video> videos;
    public SavedStats savedStats;
    public List<Profile> profiles;
    public List<SaveInfo> infos;


    void Awake(){

        string profile = loaded_profile;
        string save = loaded_save;
        string path;

        if(save == null)
            path = pathDefault;
        else
            path = "Saves/" + profile + "/" + save + "/";
    

        this.cat = XMLHelper.LoadFromXml<Cat>(path + fileCat);
        this.player = XMLHelper.LoadFromXml<Player>(path + filePlayer);
        this.missions = XMLHelper.LoadFromXml<List<Mission>>(path + fileMissions);
        this.videos = XMLHelper.LoadFromXml<List<Video>>(path + fileVideo);
        this.savedStats = XMLHelper.LoadFromXml<SavedStats>(path + fileStats);
        this.profiles = XMLHelper.LoadFromXml<List<Profile>>(profiles_path);
        this.infos = XMLHelper.LoadFromXml<List<SaveInfo>>("Saves/" + profile + "/" + infos_file_name);


    
    }


    public void SaveData(String save){

        String path = "Saves/" + loaded_profile + "/" + save;
        if(!System.IO.Directory.Exists(path))
            System.IO.Directory.CreateDirectory(path);

        path = path + "/";

        XMLHelper.SaveToXml<Cat>(cat, path + fileCat);
        XMLHelper.SaveToXml<Player>(player, path + filePlayer);
        XMLHelper.SaveToXml<List<Mission>>(missions, path + fileMissions);
        XMLHelper.SaveToXml<List<Video>>(videos, path + fileVideo);
        XMLHelper.SaveToXml<SavedStats>(savedStats, path + fileStats);

   
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

        XMLHelper.SaveToXml<List<SaveInfo>>(infos, "Saves/" + loaded_profile + "/" + infos_file_name);




        

    }

}