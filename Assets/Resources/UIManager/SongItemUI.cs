using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SongItemUI: MonoBehaviour
{
    [SerializeField] TMP_Text songTitle;
    [SerializeField] TMP_Text author;
    [SerializeField] Button playButton;
    [SerializeField] Button stopButton;
    

    [SerializeField] GameObject giradischi;

    AudioSource audioSource;

    SongUIManager manager;

    public void Start(){

        manager = FindObjectOfType<SongUIManager>();

        audioSource = giradischi.GetComponent<AudioSource>();
    }


    public void SetSongPosition(Vector2 pos){

        GetComponent<RectTransform>().anchoredPosition += pos;

    }

    
    public void setSongName(string name){

        this.songTitle.text = name;
        this.songTitle.enabled = true;

    } 

    public void setAuthor(string author){

        this.author.text = author;
        this.author.enabled = true; 

    }

    public void setButtons(){

        this.playButton.enabled = true;
        playButton.onClick.AddListener(PlaySong);

        this.stopButton.enabled = true;
        stopButton.onClick.AddListener(StopSong);
    }

    
    
    private void PlaySong(){

       
        
        GameObject SongItem = playButton.transform.parent.gameObject;

        GameObject songTitle = SongItem.transform.GetChild(0).gameObject;
       
        
        //recupero la canzone dal nome
        string songName = songTitle.GetComponent<TMP_Text>().text;
       

        Song song = manager.songs.Find(x => x.SongName.Equals(songName));
        
        AudioClip clip = (AudioClip)Resources.Load(song.SongPath);
        audioSource.clip = clip;
        audioSource.Play();
        
    }

    public void StopSong(){

        audioSource.Stop();

    }



}