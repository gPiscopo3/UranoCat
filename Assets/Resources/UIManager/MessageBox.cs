using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageBox : MonoBehaviour
{

    [SerializeField] protected Transform interactorSource;
    [SerializeField] protected float interactRange;
    [SerializeField] protected GameObject textbox;

    // Update is called once per frame
    void Update()
    {

        Ray r = new Ray(interactorSource.position, interactorSource.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out InteractableObject intercatObj))
            {
                textbox.gameObject.SetActive(true);
            }
        }
        else
        {
            textbox.gameObject.SetActive(false);
        }
    }
}
