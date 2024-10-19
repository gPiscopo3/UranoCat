using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemUI : MonoBehaviour
{

    [SerializeField] Image imageItem;
    [SerializeField] TMP_Text itemName;
    [SerializeField] TMP_Text description;
    [SerializeField] Button useButton;
    [SerializeField] TMP_Text usesRemaining;
    [SerializeField] TMP_Text quantity;
    InventoryItem itemToUse;

    public void setItem(InventoryItem item){
        this.itemToUse = item;
    }

    public void SetItemPosition(Vector2 pos){

        GetComponent<RectTransform>().anchoredPosition += pos;

    }

    public void SetItemImage (string imagePath){

        Sprite sprite = Resources.Load(imagePath, typeof(Sprite)) as Sprite;
        
        imageItem.sprite = sprite;
        this.imageItem.GetComponent<Image>().enabled = true;

    }

    public void SetItemName(string name){

        this.itemName.text = name;
        this.itemName.enabled = true;
    }

    public void SetItemDescription(string description){

        this.description.text = description;
        this.description.enabled = true;
    }

    public void SetItemQuantity(int quantity){

        this.quantity.text = quantity.ToString();
        this.quantity.enabled = true;
        
    }

    public void SetRemainingUses(int numUses, int totalUses){

        this.usesRemaining.text = "Usi rimanenti: " + numUses.ToString() + "/" + totalUses.ToString();
        this.usesRemaining.enabled = true;
        
    }

    public void SetNotUsurable(){

        this.usesRemaining.enabled = false;
        
    }
    public void setUsable(){
        this.useButton.gameObject.SetActive(true);
        this.useButton.GetComponent<Image>().enabled = true;
        this.useButton.enabled = true;
        useButton.onClick.AddListener(Usa);
    }

    private void Usa(){
        
        Player player = FindObjectOfType<GameLoader>().player;
        player.equip(itemToUse);
                
    }

}
