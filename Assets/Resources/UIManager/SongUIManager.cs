using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class SongUIManager: MonoBehaviour
{

    [Header ("Layout Settings")]
    [SerializeField] float itemSpacing = 5.5f;
    float itemWidth;
    float itemHeight;
    float diff;


    [Header("UI Elements")]
    [SerializeField] GameObject contentPanel; // questo serve per la creazione dinamica del pannello Content
    [SerializeField] GameObject ItemPrefab;

    [SerializeField] GameObject songPanel; // questo è necessario per mostrare l'intera UI; se si usasse contentPanel passandoci la radice Songs non verrebbe creata bene la board dinamicamente

    public List<Song> songs;
    
    [SerializeField] GameObject giradischi;

    [SerializeField] Button stopButton;

    AudioSource audioSource;
    

    public void Start()
    {   
       
        songs = FindObjectOfType<GameLoader>().songs;

        CreateSongBoard();
        GenerateSongItemUI();

        audioSource = giradischi.GetComponent<AudioSource>();
        stopButton.onClick.AddListener(StopSong);
    }

    public void Update(){
        if (audioSource.isPlaying){
            stopButton.gameObject.SetActive(true);
        }
        else{
            stopButton.gameObject.SetActive(false);
        }
    }

    
    private void CreateSongBoard()
    { 

        itemWidth = contentPanel.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.x;
        itemHeight = contentPanel.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.y;

        diff = (contentPanel.GetComponent<RectTransform>().sizeDelta.x - contentPanel.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.x)/2;

    }

    private void GenerateSongItemUI()
    {

        for(int j=1; j<contentPanel.transform.childCount; j++)
        {
        
            Destroy(contentPanel.transform.GetChild(j).gameObject);
           
        }
        
        contentPanel.transform.GetChild(0).gameObject.SetActive(false);
        int i = 0;

        //contentPanel.GetComponent<RectTransform>().sizeDelta = Vector2.up * (itemHeight + itemSpacing) * missions.Count;

        foreach (Song song in this.songs)
        {

            SongItemUI songItemUI = Instantiate(ItemPrefab, contentPanel.transform).GetComponent<SongItemUI>();
            songItemUI.gameObject.SetActive(true);

            Debug.Log("spacing: " + Vector2.down * i * (itemHeight + itemSpacing));
            songItemUI.SetSongPosition(Vector2.down * i * (itemHeight + itemSpacing));
            songItemUI.setSongName(song.SongName);
            songItemUI.setAuthor(song.Author);
            songItemUI.setButtonsPlay();

          
           
            //songItemUI.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, diff, itemWidth);
            contentPanel.GetComponent<RectTransform>().sizeDelta= Vector2.up * (itemHeight + itemSpacing) * songs.Count;
                
            i++; 
            

        }

        

    }
    
    public void AvviaGiradischi(bool isShown){

            songPanel.SetActive(isShown);

            if (songPanel.activeSelf){
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
            }
            else{
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void StopSong(){

        audioSource.Stop();
      //  this.stopButton.gameObject.SetActive(false);

    }

    /*public void PlayAllSongs(int indexOfSong){

        Song proxSong;

        for(int i = indexOfSong; i<songs.Count; i++){

             while (audioSource.isPlaying){
                 
            }
            
            proxSong = songs[i];
        
            AudioClip clip = (AudioClip)Resources.Load(proxSong.SongPath);
            audioSource.clip = clip;
            audioSource.Play();
        } 

    }*/

    


}