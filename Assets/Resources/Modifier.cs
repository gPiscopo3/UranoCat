using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

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

public enum FType { 
    AAA,
    BBB
}