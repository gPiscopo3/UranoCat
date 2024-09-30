using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class PlacedObjectController : MonoBehaviour, InteractableObject
{

    Player player;
    PlacedObject placedObject;
    List<PlacedObjectStatus> statusList;

    GameLoader gameLoader;

    void Awake(){
        
    }



    void Start()


    {
        gameLoader = FindObjectOfType<GameLoader>();
        player = gameLoader.player;
        placedObject = gameLoader.placedObjects.FirstOrDefault(x => x.objectName.Equals(gameObject.name));
        this.statusList = gameLoader.placedObjectsStatus;

        PlacedObjectStatus status = this.statusList.FirstOrDefault(x => x.name == gameObject.name);
        Debug.Log(status);

        if(status != null && status.obtained && placedObject != null)
            gameObject.SetActive(false);
                
        
    
    }

    void Update()
    {
        
       
    }

    public void Interact()
    {   

        bool isObtainable = true;
        
       

        if(placedObject.requirements!=null){
            List<ItemRequirement> requirements = placedObject.requirements;
            foreach(ItemRequirement requirement in requirements){
                 Debug.Log(requirement.tag);
                if(player.inventory.items.FindAll(obj => obj.tag.Equals(requirement.tag)).Count < requirement.quantity){
                    isObtainable = false;
                    break;
                }
            }
        }

        if(!isObtainable){
            Debug.Log("non puoi averlo ");
        }
        else{
            Item item = gameLoader.GetItem(placedObject.itemTag);


            player.inventory.addItem(item);
            Debug.Log("ottenuto " + item);

            statusList.Add(new PlacedObjectStatus{name = gameObject.name, obtained = true});

            gameObject.SetActive(false);
        }


    }

    
    // override object.GetHashCode
    public override int GetHashCode()
    {
        // TODO: write your implementation of GetHashCode() here
        throw new System.NotImplementedException();
        return base.GetHashCode();
    }
    

}
