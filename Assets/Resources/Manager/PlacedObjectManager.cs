using System.Collections.Generic;
using UnityEngine;

public class PlacedObjectManager: MonoBehaviour{

    public Dictionary<string,List<string>> dictionary;

    void Awake(){
        dictionary = new Dictionary<string, List<string>>();
    }


    public void Update(){
        
        foreach(PlacedObjectController placedObjectController in FindObjectsOfType<PlacedObjectController>())
            if(placedObjectController.isActive())
                Register(placedObjectController.recivedItemTag, placedObjectController.Name);
            else
                UnRegister(placedObjectController.recivedItemTag, placedObjectController.Name);
    }


    public void Register(string itemTag, string objectName){
        if(!dictionary.ContainsKey(itemTag))
            dictionary.Add(itemTag, new List<string>());
        if(!dictionary[itemTag].Contains(objectName))
            dictionary[itemTag].Add(objectName);

    }
    

    public void UnRegister(string itemTag, string objectName){
        if(dictionary.ContainsKey(itemTag) && dictionary[itemTag].Contains(objectName))
            dictionary[itemTag].Remove(objectName);
    }

    public List<string> getObjects(string itemTag){
        if(dictionary.ContainsKey(itemTag))
            return dictionary[itemTag];
        return new List<string>();
    }


}