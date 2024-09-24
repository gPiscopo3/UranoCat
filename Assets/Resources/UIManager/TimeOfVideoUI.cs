using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class TimeOfVideoUI : MonoBehaviour
{

    [SerializeField] private GameObject timeOfVideoUI;
    [SerializeField] private GameObject message;
    [SerializeField] private GameObject icon; 

    float timer = 5;

    SavedStats savedStats;

    bool is_video_available;
    void Start()
    {
        savedStats = FindObjectOfType<SaveLoader>().savedStats;
        is_video_available = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (savedStats.videoStatus == EventStatus.AVAILABLE && !is_video_available){
            is_video_available = true; 
            timer = 0;
            timeOfVideoUI.SetActive(true);
            this.icon.SetActive(false);
            this.message.SetActive(false);
        }

        if (savedStats.videoStatus == EventStatus.DONE){
            is_video_available = false;
            this.icon.SetActive(false);
        }

        if (is_video_available){
            if (timer < 4){
                timer += Time.deltaTime;
                message.SetActive(true);
            }
            else{
                message.SetActive(false);
                this.icon.SetActive(true);
            }

        }
    }
}
