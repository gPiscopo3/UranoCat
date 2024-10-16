using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    private ClockManager clockManager;
    [SerializeField] private GameObject directionalLight;
    private float previousAngle;

    // Start is called before the first frame update
    void Start()
    {
        clockManager = FindObjectOfType<ClockManager>();
        directionalLight.transform.eulerAngles = new Vector3(180 * clockManager.getDayCompletionPercentage(), 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        directionalLight.transform.eulerAngles = new Vector3(180 * clockManager.getDayCompletionPercentage(), 0,0);
    }
}
