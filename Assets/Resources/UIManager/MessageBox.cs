using UnityEngine;


public class MessageBox : MonoBehaviour
{

    [SerializeField] protected Transform interactorSource;
    [SerializeField] protected float interactRange;
    [SerializeField] protected GameObject textbox;


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
