using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] protected CharacterController characterController;
    [SerializeField] protected GameObject inventory;
    [SerializeField] protected GameObject shop;
    [SerializeField] protected GameObject missionBoard;

    [SerializeField] protected Transform interactorSource;
    [SerializeField] protected float interactRange;

    protected CharacterStatus status;
    private PlayerControls playerControls;

    private InputAction toggleInventoryAction;
    private InputAction toggleShopAction;
    private InputAction interact;
    private InputAction toggleMissionBoard;

    private bool isInventoryActive;
    private bool isShopActive;
    private bool isMissionBoardActive;

    private MissionItemUIManager missionManagerUI;

    private Animator anim;

    private void Awake()
    {
       characterController = GetComponent<CharacterController>(); 
       status = GetComponent<CharacterStatus>();
       missionManagerUI = FindObjectOfType<MissionItemUIManager>();
       anim = GetComponent<Animator>();

        playerControls = new PlayerControls();
       toggleInventoryAction = playerControls.Player.ToggleInventory;
       toggleShopAction = playerControls.Player.ToggleShop;
       interact = playerControls.Player.Interact;
       toggleMissionBoard = playerControls.Player.ToggleMissionBoard;

       isInventoryActive = false;
       isShopActive = false;
       isMissionBoardActive = false;

       toggleInventoryAction.performed += ToggleInventory;
       toggleShopAction.performed += ToggleShop;
       interact.performed += Interact;
       toggleMissionBoard.performed += ToggleMissionBoard;
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

        if (status.IsMoving)
        {
            anim.SetFloat("speed", 1f);
        }
        else
        {
            anim.SetFloat("speed", 0f);
        }
    }

    private void OnEnable()
    {
        toggleShopAction.Enable();
        toggleInventoryAction.Enable();
        toggleMissionBoard.Enable();
        interact.Enable();
    }

    private void OnDisable()
    {
        toggleShopAction.Enable();
        toggleInventoryAction.Disable();
        toggleMissionBoard.Disable();
        interact.Disable();
    }

    private void ToggleShop(InputAction.CallbackContext context)
    {
        
        shop.SetActive(!shop.activeSelf);
        isShopActive = !isShopActive;

        if (isShopActive) {
            toggleInventoryAction.Disable();
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            
        } else {
            toggleInventoryAction.Enable();
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }

    }


    private void ToggleInventory(InputAction.CallbackContext context)
    {
        
        inventory.SetActive(!inventory.activeSelf);
        isInventoryActive = !isInventoryActive;

        if (isInventoryActive) {
            toggleShopAction.Disable();
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            
        } else {
            toggleShopAction.Enable();
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

    private void ToggleMissionBoard(InputAction.CallbackContext context)
    {
        missionManagerUI.GenerateMissionItemUI();
        missionBoard.SetActive(!missionBoard.activeSelf);
        isMissionBoardActive = !isMissionBoardActive;

        if (isMissionBoardActive) {
            toggleShopAction.Disable();
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            
        } else {
            toggleShopAction.Enable();
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

}
