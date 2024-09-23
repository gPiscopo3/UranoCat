using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class NewLevelUIManager : MonoBehaviour
{

    [SerializeField] private GameObject newLevelPanel;
    PlayerManager playerManager;

    float timer = 5;

    // Start is called before the first frame update
    void Start()
    {
        this.playerManager = FindObjectOfType<PlayerManager>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (playerManager.newLevel){
            timer = 0;
            playerManager.newLevel = false;
        }
        if(timer <4){

            Debug.Log("New Level");
            newLevelPanel.SetActive(true);
            timer += Time.deltaTime;
        }
        else{
            newLevelPanel.SetActive(false);
        }
    }

}
