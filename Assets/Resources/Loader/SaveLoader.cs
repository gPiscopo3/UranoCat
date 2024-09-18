using System;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoader : MonoBehaviour
{
    
    public static string loaded_profile_id = "profile";
    public static string loaded_save = "save";

    public const string fileCat = "catStats.xml";
    public const string filePlayer = "playerData.xml";
    public const string fileMissions = "missionsData.xml";
    public const string fileVideo = "videos.xml";
    public const string fileStats = "stats.xml";
    public const string profiles_path = "Saves/profiles.xml";
    public const string pathDefault = "Assets/Resources/Saves/";
    public Cat cat;
    public Player player;
    public List<Mission> missions;
    public List<Video> videos;
    public SavedStats savedStats;
    public Profiles profiles;


    void Awake(){

        string profile = loaded_profile_id;
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

        this.profiles = XMLHelper.LoadFromXml<Profiles>(profiles_path);

        savedStats = new SavedStats(){
            day = 1, day_timer= 0, interaction_cat_timer = 0, interactions_cat = 1, is_video_available = false, update_cat_timer = 0
        };
        videos = new List<Video>();
        missions = new List<Mission>();

     
        
    
    }


    public void SaveData(String save){

        String path = "Saves/" + loaded_profile_id + "/" + save + "/";
        XMLHelper.SaveToXml<Cat>(cat, path + fileCat);
        XMLHelper.SaveToXml<Player>(player, path + filePlayer);
        XMLHelper.SaveToXml<List<Mission>>(missions, path + fileMissions);
        XMLHelper.SaveToXml<List<Video>>(videos, path + fileVideo);
        XMLHelper.SaveToXml<SavedStats>(savedStats, path + fileStats);

        Profiles.Profile profile = profiles.profiles.Find(x => x.id.Equals(loaded_profile_id));

        profile.last_save = save;
        profiles.last_profile = profile;

        XMLHelper.SaveToXml<Profiles>(profiles, profiles_path);



        

    }

}