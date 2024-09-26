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

        savedStats = FindAnyObjectByType<SaveLoader>().savedStats;
        ambient.Play();
        lago.Play();

        

    }
    void Update()
    {
        Debug.Log("interazioni: " + savedStats.interactions_cat);

        if(CatSource.isPlaying == false && savedStats.interactions_cat > 0)

        {
            //Debug.Log("il verro mi fa incazzare ");
            CatSource.Play();
        }
        /*else{
            CatSource.Stop();
        }*/

    }


}
