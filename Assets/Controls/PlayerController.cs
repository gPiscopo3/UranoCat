using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] protected CharacterController characterController;
    [SerializeField] protected GameObject inventory;

    [SerializeField] protected Transform interactorSource;
    [SerializeField] protected float interactRange;

    protected CharacterStatus status;
    private PlayerControls playerControls;

    private InputAction toggleInventoryAction;
    private InputAction interact;

    private bool isInventoryActive;
    

    private void Awake()
    {
       characterController = GetComponent<CharacterController>(); 
       status = GetComponent<CharacterStatus>();

       playerControls = new PlayerControls();
       toggleInventoryAction = playerControls.Player.ToggleInventory;
       interact = playerControls.Player.Interact;

       isInventoryActive = false;

       toggleInventoryAction.performed += ToggleMenu;
       interact.performed += Interact;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(0, 0, 0);
        if (status.IsMoving)
        {
            movement.z = status.Movement.z*Time.deltaTime;
            movement.x = status.Movement.x*Time.deltaTime;
        }
        movement = transform.TransformDirection(movement);
        characterController.SimpleMove(movement);
    }

    private void OnEnable()
    {
        toggleInventoryAction.Enable();
        interact.Enable();
    }

    private void OnDisable()
    {
        toggleInventoryAction.Disable();
        interact.Disable();
    }

    private void ToggleMenu(InputAction.CallbackContext context)
    {
        
        inventory.SetActive(!inventory.activeSelf);
        isInventoryActive = !isInventoryActive;

        if (isInventoryActive) {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            
        } else {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }

    }

    // TO DO: Refactor del metodo
    private void Interact(InputAction.CallbackContext context)
    {
        Ray r = new Ray(interactorSource.position, interactorSource.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange)) 
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out InteractableObject intercatObj))
            {
                intercatObj.Interact();
            }
        }
    }

}
