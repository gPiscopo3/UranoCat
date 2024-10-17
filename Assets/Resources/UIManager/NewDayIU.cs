using TMPro;
using UnityEngine;

public class NewDayIU : MonoBehaviour
{
    [SerializeField] private GameObject newDayPanel;
    [SerializeField] private TMP_Text dayText;

    [SerializeField] private TMP_Text recapText;

    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private TMP_Text viewsText;
    [SerializeField] private TMP_Text experienceText;
    [SerializeField] private TMP_Text followersText;

    private DayManager dayManager;
    private SavedStats savedStats;

   
    private void Start()
    {
        dayManager = FindObjectOfType<DayManager>();
        savedStats = FindObjectOfType<GameLoader>().savedStats;
    }

    private void Update()
    {
        
        if (dayManager.newDay){
            dayText.text = "Giorno " + savedStats.day;
            recapText.text = "Riepilogo del giorno " + (savedStats.day-1);
            moneyText.text =  dayManager.moneyGain.ToString();
            viewsText.text = dayManager.views_yesterday.ToString();
            experienceText.text = dayManager.experienceGain.ToString();
            followersText.text = dayManager.followersGain.ToString();

            newDayPanel.SetActive(true);
            dayManager.newDay = false;
        }
        
        if (newDayPanel.activeSelf){
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
    }


}
