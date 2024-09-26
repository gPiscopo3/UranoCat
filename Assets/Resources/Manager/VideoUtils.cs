using System;
using System.Collections.Generic;
using System.Linq;
using static SocialRules;



public class VideoUtilis{

    public static FollowersRule GetFollowersRules(long followers, List<FollowersRule> list){

        long upperFollowers;
        long lowerFollowers;

        try{
         upperFollowers = list.FindAll(x => x.followers >= followers).Min(x => x.followers);
        }catch(ArgumentNullException){
            upperFollowers = 0;
        }

        try{
        lowerFollowers = list.FindAll(x => x.followers < followers).Max(x => x.followers);
        }catch(ArgumentNullException){
            lowerFollowers = 0;
        }

        if(upperFollowers == 0){
            upperFollowers = list.Max(x => x.followers);
            lowerFollowers = list.FindAll(x => x.followers < upperFollowers).Max(x => x.followers);
        }

        if(lowerFollowers == 0){
            lowerFollowers = list.Min(x => x.followers);
            upperFollowers = list.FindAll(x => x.followers > lowerFollowers).Min(x => x.followers);
        }

        FollowersRule upper = list.Find(x => x.followers == upperFollowers);
        FollowersRule lower = list.Find(x => x.followers == lowerFollowers);

        double ratio = Math.Log10((followers - lowerFollowers)/(upperFollowers - lowerFollowers)) + Math.Log10(lowerFollowers);

        return new FollowersRule{
            followers = followers,
            max_quality_followers = lower.max_quality_followers + ratio * (upper.max_quality_followers - lower.max_quality_followers),
            min_quality_followers = lower.min_quality_followers + ratio * (upper.min_quality_followers - lower.min_quality_followers),
            rif_quality_views = lower.rif_quality_views + ratio * (upper.rif_quality_views - lower.rif_quality_views),
        };

    }

    public static double getQuality(Cat cat, SocialRules socialRules){

        double quality = 0;
        foreach(SocialRules.QualityRule qualityRule in socialRules.quality_rules){

            quality += qualityRule.factor * cat.getStat(qualityRule.stat).currentValue / 100;
        }

        return quality;
    }

    public static long Calculate_views(long followers, double quality, SocialRules socialRules){

        FollowersRule followersRule = GetFollowersRules(followers, socialRules.followers_rules);
        double Q = Math.Pow(quality/followersRule.rif_quality_views, socialRules.views_quality_power_factor);
        if(Q > 1)
            Q = 1;
        return (int)(socialRules.views_factor * followers * Q);
    }

    public static Video createVideo(long followers, Cat cat, SocialRules socialRules, SavedStats savedStats){


        return new Video{
            day = savedStats.day, 
            quality = getQuality(cat, socialRules),
            views = Calculate_views(followers, getQuality(cat, socialRules), socialRules),
            today_views = 0,
            timestamp_seconds = savedStats.timestamp_seconds
        };
    }

    public static long calculateNewFollowers(long followers, Video video, SocialRules socialRules){
        
        FollowersRule followersRule = GetFollowersRules(followers, socialRules.followers_rules);
        double Q = (video.quality - followersRule.min_quality_followers)/(followersRule.max_quality_followers - followersRule.min_quality_followers);
        if(Q > 1)
            Q = 1;
        else if (Q < 0)
            Q = 0;
        else
            Q = Math.Pow(Q, socialRules.followers_quality_power_factor);
        
        return (long)(socialRules.followers_factor * video.views * Q);

    }





}