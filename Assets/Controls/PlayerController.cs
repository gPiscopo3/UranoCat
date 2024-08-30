using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] protected CharacterController characterController;
    [SerializeField] protected GameObject inventory;

    protected CharacterStatus status;
    private PlayerControls playerControls;
    private InputAction toggleInventoryAction;
    private bool isInventoryActive;
    

    private void Awake()
    {
       characterController = GetComponent<CharacterController>(); 
       status = GetComponent<CharacterStatus>();

       playerControls = new PlayerControls();
       toggleInventoryAction = playerControls.Player.ToggleInventory;
       isInventoryActive = false;

       toggleInventoryAction.performed += ToggleMenu;
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
    }

    private void OnDisable()
    {
        toggleInventoryAction.Disable();
    }

    private void ToggleMenu(InputAction.CallbackContext context)
    {
        
        inventory.SetActive(!inventory.activeSelf);
        isInventoryActive = !isInventoryActive;

        if (isInventoryActive) {
            Time.timeScale = 0;
        } else {
            Time.timeScale = 1; 
        }

    }

}
