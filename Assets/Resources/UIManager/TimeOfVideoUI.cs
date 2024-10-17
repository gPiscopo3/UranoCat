using UnityEngine;

public class TimeOfVideoUI : MonoBehaviour
{

    [SerializeField] private GameObject timeOfVideoUI;
    [SerializeField] private GameObject message;
    [SerializeField] private GameObject icon; 

    [SerializeField] private GameObject videoOK; 

    float timer = 5;
    float timerok = 5;

    SavedStats savedStats;

    DayManager dayManager;

    bool is_video_available;
    bool was_video_available;
    void Start()
    {
        savedStats = FindObjectOfType<GameLoader>().savedStats;
        dayManager = FindObjectOfType<DayManager>();
        is_video_available = false;
    }

    void Update()
    {
        if (dayManager.isInteractionAvailable(InteractionType.VIDEO) && !is_video_available){
            is_video_available = true; 
            was_video_available = true;
            timer = 0;
            timeOfVideoUI.SetActive(true);
            this.icon.SetActive(false);
            this.message.SetActive(false);
            this.videoOK.SetActive(false);
            timerok = 0;
        }
        else if(dayManager.areInteractionsDone(InteractionType.VIDEO) && was_video_available){
            is_video_available = false;
            this.icon.SetActive(false);
            if(timerok<4){
                timerok += Time.deltaTime;
                this.message.SetActive(false);
                this.videoOK.SetActive(true);
            }
            else{
                this.videoOK.SetActive(false);
                timeOfVideoUI.SetActive(false);
                was_video_available = false;
            }
            
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
