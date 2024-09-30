using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordPlayerController : MonoBehaviour, InteractableObject
{

    //[SerializeField] private GameObject songPanel;

    private bool isShown = false;

    private SongUIManager songUIManager;

    private void Start(){

        songUIManager = FindObjectOfType<SongUIManager>();
    }

    // Update is called once per frame
    public void Interact()
    {
        
        Debug.Log("ALEXA METTI UNA CANZONE");
        isShown = !isShown;

        songUIManager.AvviaGiradischi(isShown);

    }
}
