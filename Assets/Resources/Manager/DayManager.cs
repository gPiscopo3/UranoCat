using System.Collections.Generic;
using UnityEngine;

public class DayManager: MonoBehaviour{


    public Rules rules;
    public Cat cat;
    Player player;
    private SavedStats savedStats;
    List<Video> videos;
    private ClockManager clockManager;

    private float timer_update_video = 0f;
    public bool is_video_available;
    public double moneyGain=0;

    public long experienceGain = 0;
    public long views_yesterday = 0;
    public long followersGain;

    public bool newDay = false;
    
    


    public void Start(){
        rules = FindObjectOfType<GameLoader>().rules;
        savedStats = FindObjectOfType<GameLoader>().savedStats;
        cat = FindObjectOfType<GameLoader>().cat;
        player = FindObjectOfType<GameLoader>().player;
        videos = FindObjectOfType<GameLoader>().videos;
        clockManager = FindObjectOfType<ClockManager>();


    }

    public void Update(){

        if(savedStats.dayTime.Equals(DayTime.MORNING))
            Morning_Cycle();
        else if(savedStats.dayTime.Equals(DayTime.AFTERNOON) || savedStats.dayTime.Equals(DayTime.EVENING))
            Afternoon_Cycle();
    }


    public void Morning_Cycle(){
        newDay = false;
        //Debug.Log("Giorno:"+savedStats.day);
        savedStats.day_timer ++;

        if(savedStats.day_timer >= rules.time_to_video){
            if(savedStats.videoStatus == EventStatus.NOT_AVAILABLE){
                savedStats.videoStatus = EventStatus.AVAILABLE;
                Debug.Log("Video disponibile");
                savedStats.dayTime = DayTime.AFTERNOON;
                savedStats.day_timer = 0;
            }
        }

        // per prova 
        //VideoRegistrato();
        if(savedStats.videoStatus == EventStatus.DONE){
            
        }

    }

    public void Afternoon_Cycle(){

        savedStats.day_timer ++;
        
        if(savedStats.day_timer >= rules.time_to_sleep){
            if(savedStats.sleepStatus == EventStatus.NOT_AVAILABLE){
                savedStats.sleepStatus = EventStatus.AVAILABLE;
               
            }
            savedStats.dayTime = DayTime.EVENING;
        }

        if(savedStats.sleepStatus == EventStatus.DONE){
            NuovaGiornata();
        }
        
        

    }

    public void VideoRegistrato(){
        
        savedStats.videoStatus = EventStatus.DONE;
        Debug.Log("Video registrato");
    }
    public void Dormi(){
        if(savedStats.sleepStatus== EventStatus.AVAILABLE){
            savedStats.sleepStatus = EventStatus.DONE;
            Debug.Log("Sleeping");
        }
    }

    public void NuovaGiornata(){
        Debug.Log("Nuova giornata");
        ProfitOfDay();
        savedStats.sleepStatus = EventStatus.NOT_AVAILABLE;
        savedStats.videoStatus = EventStatus.NOT_AVAILABLE;
        savedStats.dayTime = DayTime.MORNING;
        savedStats.day_timer = 0;
        clockManager.currentTime = new ClockManager.Time(clockManager.startHour,0);
        clockManager.scaleFactor = 1;

        player.money += moneyGain;
        player.experience += experienceGain;
        player.followers += followersGain;

        savedStats.day ++;
        newDay = true;
    }


    private void ProfitOfDay(){
        Video video = videos.Find(video => video.day == savedStats.day);
        views_yesterday = video.views ;
        moneyGain = views_yesterday * rules.money_for_view;
        moneyGain += player.pension;
        experienceGain = (long)(views_yesterday * rules.xp_for_view);
        followersGain = VideoUtilis.calculateNewFollowers(player.followers, video, rules.social_rules);

    }
/*
    public void CreateVideo(){

        double quality = 0;
        foreach(SocialRules.QualityRule qualityRule in rules.social_rules.quality_rules){

            quality += qualityRule.factor * cat.getStat(qualityRule.stat).currentValue / 100;
        }

        Video video = new Video{
            day = savedStats.day, 
            quality = quality,
            views = (long)(rules.social_rules.a_factor*player.followers*quality),
            today_views = 0,
            timestamp_seconds = savedStats.timestamp_seconds
        };



    }
*/





}