﻿using UnityEngine;
using UnityEngine.UI;

namespace QuantumTek.QuantumTravel
{
    /// <summary>
    /// QT_MapMarker is the UI map marker representing a map object.
    /// </summary>
    [AddComponentMenu("Quantum Tek/Quantum Travel/Map Marker")]
    [DisallowMultipleComponent]
    public class QT_MapMarker : MonoBehaviour
    {
        [SerializeField] private RectTransform rectTransform = null;
        [SerializeField] public Image image = null;


        [HideInInspector] public QT_MapObject Object;

        public void Initialize(QT_MapObject obj, float size)
        {

            Object = obj;
            image.sprite = obj.Icon;
            if (obj.Icon == null)
                image.enabled = false;
            else
                image.enabled = true;
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size);
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size);
        }

        public void SetPosition(Vector2 position)
        { rectTransform.anchoredPosition = position; }

        public void SetScale(Vector2 scale)
        { rectTransform.localScale = scale; }

        public void SetActive(bool active){
   
           gameObject.SetActive(active);
        }
    

    }
}