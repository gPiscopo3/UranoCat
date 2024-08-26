using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Character : MonoBehaviour
{

    private List<Bar> stats;
    private BarLoader barLoader;


    // Start is called before the first frame update
    void Start()
    {
        GameObject loader = GameObject.Find("BarLoader");
        barLoader = loader.GetComponent<BarLoader>();

        stats = barLoader.bars;
        foreach (Bar item in stats)
        {
            Debug.Log(item.name + " " + item.currentValue + " " + item.maxValue);
        }

    }
    
    
}
