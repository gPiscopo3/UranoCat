using UnityEngine;

public class NewLevelUIManager : MonoBehaviour
{

    [SerializeField] private GameObject newLevelPanel;
    PlayerManager playerManager;

    float timer = 5;

    void Start()
    {
        this.playerManager = FindObjectOfType<PlayerManager>();   
    }

    void Update()
    {
        if (playerManager.newLevel){
            timer = 0;
            playerManager.newLevel = false;
        }
        if(timer <4){

            newLevelPanel.SetActive(true);
            timer += Time.deltaTime;
        }
        else{
            newLevelPanel.SetActive(false);
        }
    }

}
