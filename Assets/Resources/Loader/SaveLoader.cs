using System;
using System.Collections.Generic;
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
    public const string pathDefault = "Assets/Resources/Saves";
    public Cat cat;
    public Player player;
    public List<Mission> missions;
    public List<Video> videos;
    public SavedStats savedStats;


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

        savedStats = new SavedStats(){
            day = 1, day_timer= 0, interaction_cat_timer = 0, interactions_cat = 1, is_video_available = false, update_cat_timer = 0
        };
        videos = new List<Video>();
        missions = new List<Mission>();

        SaveData("profile", "save");
        
    
    }


    public void SaveData(String profile, String save){

        String path = "Saves/" + profile + "/" + save + "/";
        XMLHelper.SaveToXml<Cat>(cat, path + fileCat);
        XMLHelper.SaveToXml<Player>(player, path + filePlayer);
        XMLHelper.SaveToXml<List<Mission>>(missions, path + fileMissions);
        XMLHelper.SaveToXml<List<Video>>(videos, path + fileVideo);
        XMLHelper.SaveToXml<SavedStats>(savedStats, path + fileStats);

    }

}