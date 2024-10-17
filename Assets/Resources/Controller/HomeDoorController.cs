using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeDoorController : MonoBehaviour, InteractableObject
{

    Animator doorAnimator; 
    public bool isOpen;

    
    [SerializeField] AudioSource openDoor;
    [SerializeField] AudioSource closeDoor;


    // Start is called before the first frame update
    void Start()
    {
        doorAnimator = GetComponent<Animator>();
        
        isOpen = false;
        doorAnimator.SetBool("isOpen", isOpen);
        
    }

    

    public void Interact()
    {
        isOpen = !isOpen;
        doorAnimator.SetBool("isOpen", isOpen);
        
         if(isOpen){
            openDoor.Play();
        }
        else{
            closeDoor.Play();
        }
        
        

        Debug.Log("Interacting with door");

    }
}
