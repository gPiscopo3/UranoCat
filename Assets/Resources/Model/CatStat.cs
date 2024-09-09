using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

public class CatStat
{

    public float currentValue;
    public float maxValue;
    public CatTag catTag;

    public CatStat() {}

    public CatStat(float currentValue, float maxValue, CatTag catTag)
    {

        this.currentValue = currentValue;
        this.maxValue = maxValue;
        this.catTag = catTag;
        
    }

}


