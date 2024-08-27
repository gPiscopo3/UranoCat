using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modifier
{
    
    public FType featureType;
    public float value;

    public Modifier(FType fType, float value)
    {
        this.featureType = fType;
        this.value = value; 
    }

}
