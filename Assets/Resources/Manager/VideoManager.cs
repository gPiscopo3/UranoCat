using UnityEngine;

public class VideoManager: MonoBehaviour{


    public Rules rules;

    private float timer_day;
    public bool is_video_available;

    public void Start(){
        rules = FindObjectOfType<AssetsLoader>().rules;

    }





}