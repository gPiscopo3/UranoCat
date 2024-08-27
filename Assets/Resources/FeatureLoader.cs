using System;
using System.Collections.Generic;
using UnityEngine;

public class FeatureLoader : MonoBehaviour
{
    public const string path = "features";
    public List<Feature> features = new List<Feature>();

    // Start is called before the first frame update
    void Awake()
    {
        
        FeatureContainer ic = FeatureContainer.Load(path);

        foreach(Feature feature in ic.items){
            features.Add(feature);
        }

    }

}
