using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatModifier
{
    
    public CatTag targetStat;
    public float value; 
    public CatModifier() {}

    public CatModifier(CatTag targetStat, float value)
    {
        this.targetStat = targetStat;
        this.value = value;
    }

}

