using System;
using UnityEngine;

namespace QuantumTek.QuantumTravel
{
    /// <summary>
    /// QT_MapObject represents a physical object in the world that corresponds to a map marker.
    /// </summary>

    public class QT_MapObject : MonoBehaviour
    {

        [HideInInspector] public string Name;
        [SerializeField] public Sprite Icon;

        [SerializeField] public bool alwaysOnMap;
        [HideInInspector] public bool show;
        public Vector2 Position (QT_MapType type) => 
            new Vector2(transform.position.x, type == QT_MapType.Map3D ? transform.position.z : transform.position.y);

        void Awake(){
            Name = gameObject.name;
            if(alwaysOnMap)
                show = true;
            Debug.Log(Name);
        }

        public bool isToShow(){
            if(!gameObject.activeSelf)
                show = false;
            return show;
        }

    }
}