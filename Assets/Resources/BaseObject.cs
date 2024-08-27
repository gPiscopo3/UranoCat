using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

abstract class BaseObject
{

    public int tag; 
    public string name;  
    public Dictionary<string, Feature> features;
    public List<Modifier> modifiers; 
    public BaseObject()
    {
        this.features = new Dictionary<string, Feature>();
        this.modifiers = new List<Modifier>();
    }    

}
