using System.Collections.Generic;
using UnityEngine;

public class VideoManager: MonoBehaviour{


    public Rules rules;
    public Cat cat;
    Player player;
    private SavedStats savedStats;
    List<Video> videos;

    private float timer_update_video = 0f;
    public bool is_video_available;


    public void Start(){
        rules = FindObjectOfType<AssetsLoader>().rules;
        savedStats = FindObjectOfType<SaveLoader>().savedStats;
        cat = FindObjectOfType<SaveLoader>().cat;
        player = FindObjectOfType<SaveLoader>().player;
        videos = FindObjectOfType<SaveLoader>().videos;



    }

    public void Update(){

        savedStats.day_timer += Time.deltaTime;
        
        timer_update_video += Time.deltaTime;

        if(savedStats.day_timer >= rules.day_duration){
            savedStats.day_timer = 0f;
            savedStats.day++;
            savedStats.is_video_available = true;
        }

        if(timer_update_video > 1){
            timer_update_video = 0;
            foreach(Video video in videos){
                long seconds_elapsed = savedStats.timestamp_seconds - video.timestamp_seconds;
                video.views = video.target_views;
            }
        }

        
        
    }


     public void CreateVideo(){

        double quality = 0;
        foreach(SocialRules.QualityRule qualityRule in rules.social_rules.quality_rules){

            quality += qualityRule.factor * cat.getStat(qualityRule.stat).currentValue / 100;
        }

        Video video = new Video{
            day = savedStats.day, 
            quality = quality,
            target_views = (long)(rules.social_rules.a_factor*player.followers*quality),
            views = 0,
            today_views = 0,
            timestamp_seconds = savedStats.timestamp_seconds
        };



    }






}