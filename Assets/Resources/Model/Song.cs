
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;


public class Song
{
    
    public string SongName { get; set; }

    public string Author {get; set; }

    public string SongPath {get; set;}

    public Song(){}

    public Song(string name, string author, string path){
        this.SongName = name;
        this.Author = author;
        this.SongPath = path;

    }

    

}