using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

public class Stat
{

    public float currentValue;
    public float maxValue;
    public CatTag catTag;

    public Stat(int currentValue, int maxValue, CatTag catTag)
    {

        this.currentValue = currentValue;
        this.maxValue = maxValue;
        this.catTag = catTag;
        
    }

}


