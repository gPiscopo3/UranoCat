using System.Collections.Generic;
using System.Linq;
using UnityEditor.PackageManager;
using UnityEngine;

public class DayManager: MonoBehaviour{


    public Rules rules;
    public Cat cat;
    Player player;
    private SavedStats savedStats;
    List<Video> videos;
    private ClockManager clockManager;

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

        if(savedStats.day_timer == 0){
            savedStats.interactions = rules.interactionsTimes;
            foreach(Interaction interaction in savedStats.interactions){
                interaction.interactionStatus = InteractionStatus.NOT_AVAILABLE;
            }
        }

        savedStats.day_timer+=Time.deltaTime;

        foreach(Interaction interaction in savedStats.interactions){
            if(savedStats.day_timer >= interaction.dayTime && interaction.interactionStatus.Equals(InteractionStatus.NOT_AVAILABLE))
                interaction.interactionStatus = InteractionStatus.AVAILABLE;
        }

        if(CheckDayComplete()){
            NuovaGiornata();
            
        }

    }

    private bool CheckDayComplete(){

        bool isCompletable = true;

        foreach(InteractionType interactionType in rules.interactionsToComplete){
            if(!(savedStats.interactions.FindAll(x => x.interactionType.Equals(interactionType) && x.interactionStatus.Equals(InteractionStatus.DONE)).Count >=
                rules.interactionsToComplete.FindAll(x => x.Equals(interactionType)).Count)){
                    isCompletable = false;
                    break;
                }
        
        }
        return isCompletable;


    }



    public bool isInteractionAvailable(InteractionType interactionType){
        if(savedStats.interactions.FirstOrDefault(x => x.interactionStatus.Equals(InteractionStatus.AVAILABLE) && x.interactionType.Equals(interactionType)) == null)
            return false;
        return true;
    }

    public bool areInteractionsDone(InteractionType interactionType){
        return savedStats.interactions.FindAll(x => x.interactionStatus.Equals(InteractionStatus.DONE) && x.interactionType.Equals(interactionType)).Count ==
            savedStats.interactions.FindAll(x => x.interactionType.Equals(interactionType)).Count;
        
    }

    public void consumeInteraction(InteractionType interactionType){

        Interaction interaction = savedStats.interactions.FirstOrDefault(x => x.interactionStatus.Equals(InteractionStatus.AVAILABLE) && x.interactionType.Equals(interactionType));
        if(interaction!=null)
            interaction.interactionStatus = InteractionStatus.DONE;

    }

    public void NuovaGiornata(){
        ProfitOfDay();

        clockManager.currentTime = new ClockManager.Time(clockManager.startHour,0);
        clockManager.scaleFactor = 1;

        player.money += moneyGain;
        player.experience += experienceGain;
        player.followers += followersGain;

        savedStats.day_timer = 0;
        savedStats.day ++;

        newDay = true;
    }


    private void ProfitOfDay(){
        Video video = videos.Find(video => video.day == savedStats.day);
        views_yesterday = video.views;
        moneyGain = views_yesterday * rules.money_for_view;
        moneyGain += player.pension;
        experienceGain = (long)(views_yesterday * rules.xp_for_view);
        followersGain = VideoUtilis.calculateNewFollowers(player.followers, video, rules.social_rules);

    }

}