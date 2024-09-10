using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MissionItemUI: MonoBehaviour
{
    [SerializeField] Toggle toggle;
    [SerializeField] TMP_Text missionTag;
    [SerializeField] TMP_Text requirements;

    public void SetMissionPosition(Vector2 pos){

        GetComponent<RectTransform>().anchoredPosition += pos;

    }

    public void setToggle(Mission mission){

        if (mission.MissionState == MissionState.COMPLETATO){
            toggle.isOn = true;
        } else {
            toggle.isOn = false;
        }
    }

    public void setMissionTag(Mission mission){

        this.missionTag.text = mission.tag;
        this.missionTag.enabled = true;

    } 

    public void setRequirements(string requirements){

        this.requirements.text = requirements;
        this.requirements.enabled = true; 

    } 



}