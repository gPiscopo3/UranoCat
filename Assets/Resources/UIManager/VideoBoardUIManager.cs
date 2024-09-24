using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoBoardUIManager : MonoBehaviour
{
    [Header ("Layout Settings")]
    [SerializeField] float itemSpacing = 5.5f;
    float itemWidth;
    float itemHeight;
    float diff;


    [Header("UI Elements")]
    [SerializeField] GameObject contentPanel;
    [SerializeField] GameObject ItemPrefab;


    List<Video> videos;


    void Start()
    {   
        Debug.Log("VideoBoardUIManager Start");
        videos = FindObjectOfType<SaveLoader>().videos;
        CreateVideoBoard();
        GenerateVideoItemUI();
    }

    private void CreateVideoBoard()
    { 

        itemWidth = contentPanel.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.x;
        itemHeight = contentPanel.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.y;

        diff = (contentPanel.GetComponent<RectTransform>().sizeDelta.x - contentPanel.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.x)/2;

    }
    
    public void GenerateVideoItemUI()
    {

        for(int j=1; j<contentPanel.transform.childCount; j++)
        {
        
            Destroy(contentPanel.transform.GetChild(j).gameObject);
           
        }
        
        contentPanel.transform.GetChild(0).gameObject.SetActive(false);
        int i = 0;

        foreach(Video video in videos)
        {
            GameObject item = Instantiate(ItemPrefab, contentPanel.transform);
            item.gameObject.SetActive(true);
            item.GetComponent<VideoItemUI>().SetDayValue(video.day);
            item.GetComponent<VideoItemUI>().SetViewValue(video.views);
            item.GetComponent<VideoItemUI>().SetVideoItemPosition(Vector2.down * (itemHeight + itemSpacing) * i);

            contentPanel.GetComponent<RectTransform>().sizeDelta= Vector2.up * (itemHeight + itemSpacing) * videos.Count;
                
            i++;
        }
    }
}
