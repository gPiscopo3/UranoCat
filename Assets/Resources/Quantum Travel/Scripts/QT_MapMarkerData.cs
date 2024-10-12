using System;
using UnityEngine;

namespace QuantumTek.QuantumTravel
{
    /// <summary>
    /// QT_MapMarkerData is used to create marker templates.
    /// </summary>
    [CreateAssetMenu(menuName = "Quantum Tek/Quantum Travel/Map Marker", fileName = "New Map Marker")]
    public class QT_MapMarkerData : ScriptableObject
    {
        [Header("Data")]
        public string Name;
        public Sprite Icon;
        private string id;

        

        [Header("Rules")]
        public bool ShowOnCompass = true;
        public bool isPlaced = false;
        public bool ShowRotation = true;

        public QT_MapMarkerData()
        {
            Guid myuuid = Guid.NewGuid();
            this.id = myuuid.ToString();
        }
        
    }
}