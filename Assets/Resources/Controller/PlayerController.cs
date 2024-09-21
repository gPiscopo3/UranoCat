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
    [SerializeField] protected GameObject summaryBoard;
    [SerializeField] protected GameObject viewsBoard;

    [SerializeField] protected Transform interactorSource;
    [SerializeField] protected float interactRange;

    [SerializeField] protected GameObject newDayPanel;

    protected CharacterStatus status;
    private PlayerControls playerControls;

    private InputAction toggleInventoryAction;
    private InputAction toggleShopAction;
    private InputAction interact;
    private InputAction toggleMissionBoard;
    private InputAction toggleSummaryBoard;
    private InputAction toggleEsc;
    private InputAction toggleViewsBoard;
    private bool isInventoryActive;
    private bool isShopActive;
    private bool isMissionBoardActive;
    private bool isSummaryBoardActive;
    private bool isViewsBoardActive;

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
        toggleSummaryBoard = playerControls.Player.ToggleSummaryBoard;
        toggleEsc = playerControls.Player.ToggleEsc; 
        toggleViewsBoard = playerControls.Player.ToggleViewBoard;

        isInventoryActive = false;
        isShopActive = false;
        isMissionBoardActive = false;
        isSummaryBoardActive = false;
        isViewsBoardActive = false;

        toggleInventoryAction.performed += ToggleInventory;
        toggleShopAction.performed += ToggleShop;
        interact.performed += Interact;
        toggleMissionBoard.performed += ToggleMissionBoard;
        toggleSummaryBoard.performed += ToggleSummaryBoard;
        toggleEsc.performed += ToggleEsc;
        toggleViewsBoard.performed += ToggleViewBoard;
       
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
        toggleSummaryBoard.Enable();
        toggleEsc.Enable();
        toggleViewsBoard.Enable();
    }

    private void OnDisable()
    {
        toggleShopAction.Disable();
        toggleInventoryAction.Disable();
        toggleMissionBoard.Disable();
        interact.Disable();
        toggleSummaryBoard.Disable();
        toggleEsc.Disable();
        toggleViewsBoard.Disable();
    }

    private void ToggleShop(InputAction.CallbackContext context)
    {
        
        shop.SetActive(!shop.activeSelf);
        isShopActive = !isShopActive;

        if (shop.activeSelf) {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            
        } else {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }

    }

    private void ToggleInventory(InputAction.CallbackContext context)
    {
        
        inventory.SetActive(!inventory.activeSelf);
        isInventoryActive = !isInventoryActive;

        if (inventory.activeSelf) {
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

    private void ToggleMissionBoard(InputAction.CallbackContext context)
    {
        missionManagerUI.GenerateMissionItemUI();
        missionBoard.SetActive(!missionBoard.activeSelf);
        isMissionBoardActive = !isMissionBoardActive;

        if (missionBoard.activeSelf) {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            
        } else {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void ToggleSummaryBoard(InputAction.CallbackContext context)
    {
        
        isSummaryBoardActive = !isSummaryBoardActive;
        if(inventory.activeSelf || shop.activeSelf || missionBoard.activeSelf || viewsBoard.activeSelf)
        {
            inventory.SetActive(false);
            shop.SetActive(false);
            missionBoard.SetActive(false);
            viewsBoard.SetActive(false);
        }
        else
            summaryBoard.SetActive(!summaryBoard.activeSelf);



        if (summaryBoard.activeSelf) {
            //toggleSummaryBoard.Disable();
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            
        } else {
            //toggleSummaryBoard.Enable();
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void ToggleViewBoard(InputAction.CallbackContext context)
    {
        viewsBoard.SetActive(!viewsBoard.activeSelf);
        isViewsBoardActive = !isViewsBoardActive;

        if (viewsBoard.activeSelf) {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            
        } else {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void ToggleEsc(InputAction.CallbackContext context)
    {

        if(shop.activeSelf || inventory.activeSelf || missionBoard.activeSelf || viewsBoard.activeSelf || newDayPanel.activeSelf)
        {
            shop.SetActive(false);
            inventory.SetActive(false);
            missionBoard.SetActive(false);
            viewsBoard.SetActive(false);
            newDayPanel.SetActive(false);
        }
        else if(summaryBoard.activeSelf)    
            summaryBoard.SetActive(false);

        if(shop.activeSelf || inventory.activeSelf || missionBoard.activeSelf || summaryBoard.activeSelf || viewsBoard.activeSelf || newDayPanel.activeSelf)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
        

        

        
    }
}
