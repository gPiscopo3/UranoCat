using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class MissingItemManager : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    private float timer = 0;
    private bool startTimer = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {
            timer += Time.deltaTime;
            text.gameObject.SetActive(true);
        }
        if (timer > 4)
        {
            timer = 0;
            text.gameObject.SetActive(false);
            startTimer = false;
        }
    }
    public void setTextAndStartTimer(string textToDisplay)
    {
        text.SetText(textToDisplay);
        startTimer = true;
        timer = 0;
    }
}
