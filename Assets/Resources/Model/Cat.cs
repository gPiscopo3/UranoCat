using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class Cat
{

    public List<CatStat> stats;

    public Cat(){
        }

    public CatStat getStat(CatTag tag)
    {
        return this.stats.Find(obj => obj.catTag == tag);
    }
    public void setStat(CatTag tag, float value)
    {
        CatStat stat = this.stats.Find(obj => obj.catTag == tag);
        if (value >= stat.maxValue)
        {
            stat.currentValue = stat.maxValue;
        }
        else
        {
            stat.currentValue = value;
        }
    }
}