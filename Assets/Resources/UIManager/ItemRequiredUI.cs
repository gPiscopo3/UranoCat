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
    
    PlacedObjectManager placedObjectManager;

    public void Start(){
        bussola = FindObjectOfType<QT_CompassBar>();
        placedObjectManager = FindObjectOfType<PlacedObjectManager>();
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
        searchItemButton.gameObject.SetActive(true);
        searchItemButton.onClick.AddListener(SearchItem);
        
    }
    public void SearchItem(){
        Debug.Log("Cerco l'oggetto con tag: " + tag);
        bussola.HideAll();
        foreach(string objectName in placedObjectManager.getObjects(tag))
                bussola.ShowObject(objectName);

        
    }

}

