using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLoader: MonoBehaviour
{

    public const string path = "Assets/Resources/cat_items.xml";
    ItemContainer catItemList { get; set;}
    
    void Awake()
    {
        
        catItemList = ItemContainer.LoadFromXml(path);
        Debug.Log($"Lista di CatItem deserializzata. Numero di oggetti: {catItemList.items.Count}");

        // Stampa i dettagli degli oggetti deserializzati
        foreach (var catItem in catItemList.items)
        {
            Debug.Log($"Tag = {catItem.tag}, Nome = {catItem.name}, Durability = {catItem.durability}, Tipo = {catItem.itemType}");
            foreach (var modifier in catItem.catModifiers)
            {
                Debug.Log($"\tTargetStat = {modifier.targetStat}, Valore = {modifier.value}");
            }
        }

    }

}
