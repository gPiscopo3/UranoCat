using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

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
    [SerializeField] private Transform mainCamera;

    private InputAction toggleInventoryAction;
    private InputAction toggleShopAction;
    private InputAction interact;
    private InputAction toggleMissionBoard;
    private InputAction toggleSummaryBoard;
    private InputAction toggleEsc;
    private InputAction toggleViewsBoard;
    private InputAction toggleSmartphone; 

    private InputAction toggleSprint;
    private InputAction toggleJump;
    private InputAction toggleCrouch;
    private bool isInventoryActive;
    private bool isShopActive;
    private bool isMissionBoardActive;
    private bool isSummaryBoardActive;
    private bool isViewsBoardActive;
    private bool isSprinting;
    private bool isJumping = false;
    private bool isCrouching = false;

    private MissionItemUIManager missionManagerUI;

    private Animator anim;

    private Player player;

    private float sprintMultiplier = 1f;

    [SerializeField] private float baseVelocity = 1f;
    [SerializeField] private float sprintVelocity = 1.5f;
    [SerializeField] private float crouchVelocity = 0.5f;
    private float currentVelocity;

    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float jumpHeight = 3.5f;

    //gravit� alta per evitare rimbalzi del giocatore dopo un salto
    private float gravityValue = -30.81f;


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
        toggleSmartphone = playerControls.Player.ToggleSmartphone;
        toggleSprint = playerControls.Player.ToggleSprint;
        toggleJump = playerControls.Player.ToggleJump;
        toggleCrouch = playerControls.Player.ToggleCrouch;

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
        toggleSmartphone.performed += ToggleSmartphone;
       
        toggleSprint.performed += ToggleSprint;
        toggleJump.performed += ToggleJump;
        toggleCrouch.performed += ToggleCrouch;

        currentVelocity = baseVelocity;

    }

    private void Start()
    {
       player = FindObjectOfType<SaveLoader>().player;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(0, 0, 0);
        Debug.Log("movement: "+ status.Movement);
        if (status.IsMoving)
        {
            movement.z = status.Movement.z*Time.deltaTime* currentVelocity;
            movement.x = status.Movement.x*Time.deltaTime* currentVelocity * 2;
        }
        movement = transform.TransformDirection(movement);
        characterController.SimpleMove(movement);

        //animazioni
        if (status.IsMoving)
        {
            if(isSprinting)
            {
                anim.SetFloat("speed", 1f);
            }
            else
            {
                anim.SetFloat("speed", 0.5f);
            }
            
        }
        else
        {
            anim.SetFloat("speed", 0f);
            isSprinting = false;
        }

        //salto
        groundedPlayer = characterController.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        if (isJumping && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            isJumping = false;
        }

        
        playerVelocity.y += gravityValue * Time.deltaTime;

        characterController.Move(playerVelocity * Time.deltaTime);
        
        //crouch
        anim.SetBool("crouch", isCrouching);

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
        toggleSmartphone.Enable();
        toggleSprint.Enable();
        toggleJump.Enable();
        toggleCrouch.Enable();
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
        toggleSmartphone.Disable();
        toggleSprint.Disable();
        toggleJump.Disable();
        toggleCrouch.Disable(); 
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

    private void ToggleSprint(InputAction.CallbackContext context)
    {
        isSprinting = !isSprinting;
        if (isSprinting && !isCrouching)
        {
            currentVelocity = sprintVelocity;
        }
        else
        {
            if(isCrouching)
                currentVelocity = crouchVelocity;
            else
                currentVelocity = baseVelocity;
        }
    }

    private void ToggleJump(InputAction.CallbackContext context)
    {
        isJumping = true;
        anim.SetTrigger("jump");
    }

    private void ToggleCrouch(InputAction.CallbackContext context)
    {
        isCrouching = !isCrouching;
        
        if (isCrouching)
        {
            mainCamera.position -= new Vector3(0, 0.7f, 0);
            
        }
        else
        {
            mainCamera.position -= new Vector3(0, -0.7f, 0);
            
        }

        if (isCrouching)
        {
            currentVelocity = crouchVelocity;
        }
        else
        {
            currentVelocity = baseVelocity;
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

    private void ToggleSmartphone(InputAction.CallbackContext context)
    {
        
        Debug.Log("Smartphone attivato");
        player.equip( new InventoryItem(new Smartphone(){
            name = "Smartphone"
        }));
        
        
    }
}
