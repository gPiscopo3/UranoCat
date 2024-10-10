using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using QuantumTek.QuantumTravel;

public class ItemRequiredUI : MonoBehaviour
{

    [SerializeField] Image image;
    [SerializeField] TMP_Text quantity;

    [SerializeField] Button searchItemButton;

    string tag;

    QT_CompassBar bussola;
    List<QT_MapObject> mapObjects;

    public void Start(){
        bussola = FindObjectOfType<QT_CompassBar>();
        mapObjects = bussola.Objects;
      //  searchItemButton.enabled = false;
    }

    public void SetImage(string imagePath){
        image.sprite = Resources.Load<Sprite>("Images/" + imagePath);
        image.enabled = true;
    }

    public void SetQuantity(string quantity){
        this.quantity.text = quantity;
        this.quantity.enabled = true;
    }

    public void SetPositionItem(Vector2 pos){
        GetComponent<RectTransform>().anchoredPosition += pos;
    }

    public void SetSearchButton(string tag){
        this.tag = tag;
        searchItemButton.enabled = true;
        
        searchItemButton.onClick.AddListener(SearchItem);
        
    }

    public void SearchItem(){
        Debug.Log("Cerco l'oggetto con tag: " + tag);
        //List<> obj = FindObjectsByType<PlacedObjectController>(obj => obj.GetComponent<PlacedObjectController>().recivedItemTag.Equals(tag));
        foreach(QT_MapObject o in obj){
            o.Data.ShowOnCompass = true;
            Debug.Log(o.Data.ShowOnCompass);
            
        }
        
    }


}

