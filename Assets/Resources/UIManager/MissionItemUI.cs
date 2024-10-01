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
    [SerializeField] TMP_Text missionName;
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

    public void setMissionName(Mission mission){

        this.missionName.text = mission.name;
        this.missionName.enabled = true;

    } 

    public void setRequirements(string requirements){

        this.requirements.text = requirements;
        this.requirements.enabled = true; 

    } 



}