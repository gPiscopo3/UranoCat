using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject inventory;

    private PlayerControls playerControls;
    private InputAction toggleInventoryAction;
    private bool isActive;

    // Start is called before the first frame update

    void Awake()
    {
        playerControls = new PlayerControls();
        toggleInventoryAction = playerControls.Player.ToggleInventory;
        isActive = false;

        toggleInventoryAction.performed += ToggleMenu;
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
        isActive = !isActive;

        if (isActive) {
            Time.timeScale = 0;
        } else {
            Time.timeScale = 1; 
        }

    }

}
