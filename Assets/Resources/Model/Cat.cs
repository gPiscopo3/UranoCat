using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class Cat
{

    [XmlElement("Stat")]
    public List<Stat> stats;

    public Cat(){
        stats = new List<Stat>();
    }

}