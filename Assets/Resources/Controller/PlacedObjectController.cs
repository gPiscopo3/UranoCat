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
    PlacedObjectRequirement objectRequirements;
    List<PlacedObjectStatus> statusList;

    GameLoader gameLoader;

    [SerializeField] public string itemTag;

    void Awake(){
        
    }



    void Start()


    {
        gameLoader = FindObjectOfType<GameLoader>();
        player = gameLoader.player;
        objectRequirements = gameLoader.placedObjectRequirements.FirstOrDefault(x => x.name.Equals(gameObject.name));
        this.statusList = gameLoader.placedObjects;

        PlacedObjectStatus status = this.statusList.FirstOrDefault(x => x.name == gameObject.name);
        Debug.Log(status);

        if(status != null && status.obtained)
            gameObject.SetActive(false);
                
        
    
    }

    void Update()
    {
        
       
    }

    public void Interact()
    {   

        bool isObtainable = true;
        
       

        if(objectRequirements!=null){
            List<ItemRequirement> requirements = objectRequirements.requirements;
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
            Item item = gameLoader.GetItem(itemTag);


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
