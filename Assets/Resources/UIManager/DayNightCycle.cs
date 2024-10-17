using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    private ClockManager clockManager;
    [SerializeField] private GameObject directionalLight;
    

    void Start()
    {
        clockManager = FindObjectOfType<ClockManager>();
        directionalLight.transform.eulerAngles = new Vector3(180 * clockManager.getDayCompletionPercentage(), 0, 0);
    }

    void FixedUpdate()
    {
        directionalLight.transform.eulerAngles = new Vector3(180 * clockManager.getDayCompletionPercentage(), 0,0);
    }
}
