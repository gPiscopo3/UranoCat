using System;
using System.Collections.Generic;
using UnityEngine;

public class BarLoader : MonoBehaviour
{
    public const string path = "bars";
    public List<Bar> bars = new List<Bar>();

    // Start is called before the first frame update
    void Awake()
    {
        
        BarContainer ic = BarContainer.Load(path);

        foreach(Bar bar in ic.items){
            bars.Add(bar);
        }

    }

}
