using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class RulesLoader : MonoBehaviour
{

    public const string catRulesPath = "Assets/Resources/cat_rules.xml";
    public CatStatsRules catStatsRules;

    void Awake(){

        this.catStatsRules = XMLHelper.LoadFromXml<CatStatsRules>(catRulesPath);
    
    }



}