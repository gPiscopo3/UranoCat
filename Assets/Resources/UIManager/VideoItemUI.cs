using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VideoItemUI : MonoBehaviour
{
    
    [SerializeField] TMP_Text dayValue; 
    [SerializeField] TMP_Text viewValue; 

    public void SetDayValue(int day){
        this.dayValue.text = day.ToString();
        this.dayValue.enabled = true;
    }

    public void SetVideoItemPosition(Vector2 pos){
        GetComponent<RectTransform>().anchoredPosition += pos;
    }

    public void SetViewValue(long view){
        this.viewValue.text = view.ToString();
        this.viewValue.enabled = true;
    }
}
