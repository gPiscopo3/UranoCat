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
        if(!CatSource.isPlaying && FindObjectOfType<DayManager>().isInteractionAvailable(InteractionType.CAT_ITERACTION)){
            CatSource.Play();
            Debug.Log("miao");
        }
        
    }
}
