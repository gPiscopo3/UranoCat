using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPanelUI : MonoBehaviour{

    [SerializeField] public Button button;
    [SerializeField] private TMP_Text lastAccess;
    [SerializeField] private TMP_Text hourPlayed;

    public void SetButtonText(string text){
        this.button.GetComponentInChildren<TMP_Text>().text = text;
        this.button.enabled = true;
       
    }

    public void SetLastAccess(string text){
        this.lastAccess.text = text;
        this.lastAccess.enabled = true;
    }
    
    public void SetHourPlayed(string text){
        this.hourPlayed.text = text;
        this.hourPlayed.enabled = true;
    }

    public void SetButtonInteractable(bool value){
        this.button.interactable = value;
    }

    public void SetPosition(Vector2 pos){
        this.GetComponent<RectTransform>().anchoredPosition += pos;
    }
    

}