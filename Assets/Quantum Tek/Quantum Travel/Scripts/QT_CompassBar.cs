using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

namespace QuantumTek.QuantumTravel
{
    /// <summary>
    /// QT_CompassBar is used as a compass bar, showing travel direction in 3D space and any important markers.
    /// </summary>
    [AddComponentMenu("Quantum Tek/Quantum Travel/Compass Bar")]
    [DisallowMultipleComponent]
    public class QT_CompassBar : MonoBehaviour
    {
        [SerializeField] private RectTransform rectTransform = null;
        [SerializeField] private RectTransform barBackground = null;
        [SerializeField] private RectTransform markersTransform = null;
        [SerializeField] private RawImage image = null;

        
        public Dictionary<string, QT_MapObject> Objects = new Dictionary<string, QT_MapObject>();

        [HideInInspector] public QT_MapObject ReferenceObject;
       
        [Header("Object References")]


        public String playerName;
        public String cat;
        public QT_MapMarker MarkerPrefab;
        public List<QT_MapMarker> Markers { get; set; } = new List<QT_MapMarker>();

        [Header("Compass Bar Variables")]
        public Vector2 CompassSize = new Vector2(200, 25);
        public Vector2 ShownCompassSize = new Vector2(100, 25);
        public float MaxRenderDistance;
        public float MarkerSize = 20;
        public float MinScale = 0.5f;
        public float MaxScale = 2f;

        DayManager dayManager;

        private void Awake()
        {
           
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, ShownCompassSize.x);
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, ShownCompassSize.y);
            barBackground.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, CompassSize.x);
            barBackground.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, CompassSize.y);

        }

        public void Start(){
            
            foreach(QT_MapObject mapObject in FindObjectsOfType<QT_MapObject>()){
                if(mapObject.Name.Equals(playerName))
                    ReferenceObject = mapObject;
                else
                    Objects.Add(mapObject.Name, mapObject);
            }

            foreach(QT_MapObject obj in Objects.Values){   
                CreateMarker(obj);
            }

            dayManager = FindObjectOfType<DayManager>();

        }

        private void Update()
        {
            image.uvRect = new Rect(ReferenceObject.transform.localEulerAngles.y / 360, 0, 1, 1);

            foreach(QT_MapObject mapObject in Objects.Values)
                SetMarker(mapObject);
    
            foreach (var marker in Markers)
            {
                marker.SetPosition(CalculatePosition(marker));
                marker.SetScale(CalculateScale(marker));
                if(marker.Object.Name.Equals(cat))
                    if(dayManager.isInteractionAvailable(InteractionType.CAT_ITERACTION));
                        
                
            }
        }

        private Vector2 CalculatePosition(QT_MapMarker marker)
        {
            float compassDegree = CompassSize.x / 360;
            Vector2 referencePosition = ReferenceObject.Position(QT_MapType.Map3D);
            Vector2 referenceForward = new Vector2(ReferenceObject.transform.forward.x, ReferenceObject.transform.forward.z);
            float angle = Vector2.SignedAngle(marker.Object.Position(QT_MapType.Map3D) - referencePosition, referenceForward);

            return new Vector2(compassDegree * angle, 0);
        }

        private Vector2 CalculateScale(QT_MapMarker marker)
        {
            float distance = Vector2.Distance(ReferenceObject.Position(QT_MapType.Map3D), marker.Object.Position(QT_MapType.Map3D));
            float scale = 0;

            if (distance < MaxRenderDistance)
                scale = Mathf.Clamp(1 - distance / MaxRenderDistance, MinScale, MaxScale);

            return new Vector2(scale, scale);
        }
 
        public void CreateMarker(QT_MapObject obj)
        {

            QT_MapMarker marker;

            if (Markers.Find(x => x.Object.Name.Equals(obj.Name)) == null){
                marker = Instantiate(MarkerPrefab, markersTransform);
                marker.Initialize(obj, MarkerSize);
                Markers.Add(marker);
            }

        }

        public void SetMarker(QT_MapObject obj){

            QT_MapMarker marker = Markers.Find(x => x.Object.Name.Equals(obj.Name));
            if(marker != null)
                marker.SetActive(obj.isToShow());

        }


        public void ShowObject(String name){
            if(Objects.ContainsKey(name))
                Objects[name].show = true;
        }

        public void HideObject(string name){
             if(Objects.ContainsKey(name))
                Objects[name].show = false;
        }

        public void HideAll(){
            foreach(QT_MapObject mapObject in Objects.Values){
                if(!mapObject.alwaysOnMap)
                    mapObject.show = false;
            }
        }

    }
}