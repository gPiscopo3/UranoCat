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

        if(savedStats.dayTime.Equals(DayTime.MORNING))
            Morning_Cycle();
        else
            Afternoon_Cycle();

        

       

        
        
    }


    public void Morning_Cycle(){

        savedStats.day_timer ++;

        if(savedStats.day_timer >= rules.time_to_video){
            if(savedStats.videoStatus == EventStatus.NOT_AVAILABLE)
                savedStats.videoStatus = EventStatus.AVAILABLE;
        }

        if(savedStats.videoStatus == EventStatus.DONE){
            savedStats.dayTime = DayTime.AFTERNOON;
            savedStats.day_timer = 0;
        }

    }

    public void Afternoon_Cycle(){

        savedStats.day_timer ++;

        if(savedStats.day_timer >= rules.time_to_sleep){
            if(savedStats.sleepStatus == EventStatus.NOT_AVAILABLE)
                savedStats.sleepStatus = EventStatus.AVAILABLE;
        }

        if(savedStats.sleepStatus == EventStatus.DONE){
            savedStats.dayTime = DayTime.AFTERNOON;
            NuovaGiornata();
        }

    }

    public void VideoRegistrato(){
        savedStats.videoStatus = EventStatus.DONE;
    }
    public void Dormi(){
        savedStats.sleepStatus = EventStatus.DONE;
    }

    public void NuovaGiornata(){}


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