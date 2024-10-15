using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    [SerializeField] AudioSource CatSource;
    [SerializeField] AudioSource ambient;
    [SerializeField] AudioSource lago;

    SavedStats savedStats;

    public void Start(){

        savedStats = FindAnyObjectByType<GameLoader>().savedStats;
        ambient.Play();
        lago.Play();

    }

    void Update()
    {

        if(CatSource.isPlaying == false && FindObjectOfType<DayManager>().isInteractionAvailable(InteractionType.CAT_ITERACTION))

        {
            //Debug.Log("il verro mi fa incazzare ");
            CatSource.Play();
        }
        /*else{
            CatSource.Stop();
        }*/

    }


}
