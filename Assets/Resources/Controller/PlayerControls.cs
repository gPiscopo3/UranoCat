//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Resources/Controller/PlayerControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""fd69f46d-b70d-4356-8189-d5d8652e60b9"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""dc1fdf87-e1f5-4afb-b22b-7f6f11a8e2d6"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ToggleInventory"",
                    ""type"": ""Button"",
                    ""id"": ""4c219604-cb63-4c5b-9e04-f31c0d6c5f98"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""67c6cb0f-d7a7-4fb6-bde0-fd6031217371"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ToggleShop"",
                    ""type"": ""Button"",
                    ""id"": ""b88ecead-a174-4048-b3ef-0c5ee4c62e24"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ToggleMissionBoard"",
                    ""type"": ""Button"",
                    ""id"": ""ffaba89b-4c5f-4914-8fc6-a09b39d0a048"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ToggleSummaryBoard"",
                    ""type"": ""Button"",
                    ""id"": ""a3b674ce-c465-41f8-af3e-52b32c4e404c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ToggleEsc"",
                    ""type"": ""Button"",
                    ""id"": ""9f9739b6-b4ba-4c02-b4a5-57fa47e5ae36"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ToggleViewBoard"",
                    ""type"": ""Button"",
                    ""id"": ""fec8c8d0-af8a-429f-99c1-ae8b923aa46d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ToggleSmartphone"",
                    ""type"": ""Button"",
                    ""id"": ""ee189d5d-cedf-4f68-b8a7-71125b66b963"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ToggleSprint"",
                    ""type"": ""Button"",
                    ""id"": ""d9ce47e3-f381-4f8d-b413-6a974814ee4b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ToggleJump"",
                    ""type"": ""Button"",
                    ""id"": ""f5d150d7-3af4-401a-bcea-d6905bb07acd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ToggleCrouch"",
                    ""type"": ""Button"",
                    ""id"": ""4e86931d-e1e6-44b5-a2ef-ab07eaee2807"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TogglePause"",
                    ""type"": ""Button"",
                    ""id"": ""47fab5c9-c8fb-42c6-8229-8f9519cb5dfa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""3D Vector"",
                    ""id"": ""fe4da93e-18e1-495e-9621-1485b88a7da2"",
                    ""path"": ""3DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a081808a-8da7-4456-aa79-ce49202c7dd3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b302bded-3111-48e2-a647-553931aecede"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""dd86e262-1fee-4c53-b6ef-36ccba8b553a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8fa738df-593f-45f1-bd15-5936816c2817"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""fd906186-08a7-4e68-85d9-fcbf422529fd"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d218c1f3-b512-40b2-8b20-9390d9245a1c"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f9eabf48-c72a-4689-9cfe-6e9dd138c152"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleShop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""666d9ba0-a25d-4d63-a545-9ffaf49ac217"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleMissionBoard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6c002081-82fc-4f7b-9e5c-4472e2b5a75c"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleSummaryBoard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""02212194-b294-4e8d-9895-21886c0fb0a2"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleEsc"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6a266673-fe28-45e6-af4d-92c969fc421a"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleViewBoard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""faf8a172-3be7-46dc-be64-d93885645bce"",
                    ""path"": ""<Keyboard>/h"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleSmartphone"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""efb05a46-775f-470a-963a-c15bbc574157"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleSprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bb4ce94e-955c-4347-9952-95f66de29f11"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleJump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a117c4d6-9fca-49ef-ab23-12d032768478"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleCrouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d7609f61-4215-4f6a-a94e-58ff2a7c1b8c"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TogglePause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_ToggleInventory = m_Player.FindAction("ToggleInventory", throwIfNotFound: true);
        m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
        m_Player_ToggleShop = m_Player.FindAction("ToggleShop", throwIfNotFound: true);
        m_Player_ToggleMissionBoard = m_Player.FindAction("ToggleMissionBoard", throwIfNotFound: true);
        m_Player_ToggleSummaryBoard = m_Player.FindAction("ToggleSummaryBoard", throwIfNotFound: true);
        m_Player_ToggleEsc = m_Player.FindAction("ToggleEsc", throwIfNotFound: true);
        m_Player_ToggleViewBoard = m_Player.FindAction("ToggleViewBoard", throwIfNotFound: true);
        m_Player_ToggleSmartphone = m_Player.FindAction("ToggleSmartphone", throwIfNotFound: true);
        m_Player_ToggleSprint = m_Player.FindAction("ToggleSprint", throwIfNotFound: true);
        m_Player_ToggleJump = m_Player.FindAction("ToggleJump", throwIfNotFound: true);
        m_Player_ToggleCrouch = m_Player.FindAction("ToggleCrouch", throwIfNotFound: true);
        m_Player_TogglePause = m_Player.FindAction("TogglePause", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_ToggleInventory;
    private readonly InputAction m_Player_Interact;
    private readonly InputAction m_Player_ToggleShop;
    private readonly InputAction m_Player_ToggleMissionBoard;
    private readonly InputAction m_Player_ToggleSummaryBoard;
    private readonly InputAction m_Player_ToggleEsc;
    private readonly InputAction m_Player_ToggleViewBoard;
    private readonly InputAction m_Player_ToggleSmartphone;
    private readonly InputAction m_Player_ToggleSprint;
    private readonly InputAction m_Player_ToggleJump;
    private readonly InputAction m_Player_ToggleCrouch;
    private readonly InputAction m_Player_TogglePause;
    public struct PlayerActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @ToggleInventory => m_Wrapper.m_Player_ToggleInventory;
        public InputAction @Interact => m_Wrapper.m_Player_Interact;
        public InputAction @ToggleShop => m_Wrapper.m_Player_ToggleShop;
        public InputAction @ToggleMissionBoard => m_Wrapper.m_Player_ToggleMissionBoard;
        public InputAction @ToggleSummaryBoard => m_Wrapper.m_Player_ToggleSummaryBoard;
        public InputAction @ToggleEsc => m_Wrapper.m_Player_ToggleEsc;
        public InputAction @ToggleViewBoard => m_Wrapper.m_Player_ToggleViewBoard;
        public InputAction @ToggleSmartphone => m_Wrapper.m_Player_ToggleSmartphone;
        public InputAction @ToggleSprint => m_Wrapper.m_Player_ToggleSprint;
        public InputAction @ToggleJump => m_Wrapper.m_Player_ToggleJump;
        public InputAction @ToggleCrouch => m_Wrapper.m_Player_ToggleCrouch;
        public InputAction @TogglePause => m_Wrapper.m_Player_TogglePause;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @ToggleInventory.started += instance.OnToggleInventory;
            @ToggleInventory.performed += instance.OnToggleInventory;
            @ToggleInventory.canceled += instance.OnToggleInventory;
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
            @ToggleShop.started += instance.OnToggleShop;
            @ToggleShop.performed += instance.OnToggleShop;
            @ToggleShop.canceled += instance.OnToggleShop;
            @ToggleMissionBoard.started += instance.OnToggleMissionBoard;
            @ToggleMissionBoard.performed += instance.OnToggleMissionBoard;
            @ToggleMissionBoard.canceled += instance.OnToggleMissionBoard;
            @ToggleSummaryBoard.started += instance.OnToggleSummaryBoard;
            @ToggleSummaryBoard.performed += instance.OnToggleSummaryBoard;
            @ToggleSummaryBoard.canceled += instance.OnToggleSummaryBoard;
            @ToggleEsc.started += instance.OnToggleEsc;
            @ToggleEsc.performed += instance.OnToggleEsc;
            @ToggleEsc.canceled += instance.OnToggleEsc;
            @ToggleViewBoard.started += instance.OnToggleViewBoard;
            @ToggleViewBoard.performed += instance.OnToggleViewBoard;
            @ToggleViewBoard.canceled += instance.OnToggleViewBoard;
            @ToggleSmartphone.started += instance.OnToggleSmartphone;
            @ToggleSmartphone.performed += instance.OnToggleSmartphone;
            @ToggleSmartphone.canceled += instance.OnToggleSmartphone;
            @ToggleSprint.started += instance.OnToggleSprint;
            @ToggleSprint.performed += instance.OnToggleSprint;
            @ToggleSprint.canceled += instance.OnToggleSprint;
            @ToggleJump.started += instance.OnToggleJump;
            @ToggleJump.performed += instance.OnToggleJump;
            @ToggleJump.canceled += instance.OnToggleJump;
            @ToggleCrouch.started += instance.OnToggleCrouch;
            @ToggleCrouch.performed += instance.OnToggleCrouch;
            @ToggleCrouch.canceled += instance.OnToggleCrouch;
            @TogglePause.started += instance.OnTogglePause;
            @TogglePause.performed += instance.OnTogglePause;
            @TogglePause.canceled += instance.OnTogglePause;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @ToggleInventory.started -= instance.OnToggleInventory;
            @ToggleInventory.performed -= instance.OnToggleInventory;
            @ToggleInventory.canceled -= instance.OnToggleInventory;
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
            @ToggleShop.started -= instance.OnToggleShop;
            @ToggleShop.performed -= instance.OnToggleShop;
            @ToggleShop.canceled -= instance.OnToggleShop;
            @ToggleMissionBoard.started -= instance.OnToggleMissionBoard;
            @ToggleMissionBoard.performed -= instance.OnToggleMissionBoard;
            @ToggleMissionBoard.canceled -= instance.OnToggleMissionBoard;
            @ToggleSummaryBoard.started -= instance.OnToggleSummaryBoard;
            @ToggleSummaryBoard.performed -= instance.OnToggleSummaryBoard;
            @ToggleSummaryBoard.canceled -= instance.OnToggleSummaryBoard;
            @ToggleEsc.started -= instance.OnToggleEsc;
            @ToggleEsc.performed -= instance.OnToggleEsc;
            @ToggleEsc.canceled -= instance.OnToggleEsc;
            @ToggleViewBoard.started -= instance.OnToggleViewBoard;
            @ToggleViewBoard.performed -= instance.OnToggleViewBoard;
            @ToggleViewBoard.canceled -= instance.OnToggleViewBoard;
            @ToggleSmartphone.started -= instance.OnToggleSmartphone;
            @ToggleSmartphone.performed -= instance.OnToggleSmartphone;
            @ToggleSmartphone.canceled -= instance.OnToggleSmartphone;
            @ToggleSprint.started -= instance.OnToggleSprint;
            @ToggleSprint.performed -= instance.OnToggleSprint;
            @ToggleSprint.canceled -= instance.OnToggleSprint;
            @ToggleJump.started -= instance.OnToggleJump;
            @ToggleJump.performed -= instance.OnToggleJump;
            @ToggleJump.canceled -= instance.OnToggleJump;
            @ToggleCrouch.started -= instance.OnToggleCrouch;
            @ToggleCrouch.performed -= instance.OnToggleCrouch;
            @ToggleCrouch.canceled -= instance.OnToggleCrouch;
            @TogglePause.started -= instance.OnTogglePause;
            @TogglePause.performed -= instance.OnTogglePause;
            @TogglePause.canceled -= instance.OnTogglePause;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnToggleInventory(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnToggleShop(InputAction.CallbackContext context);
        void OnToggleMissionBoard(InputAction.CallbackContext context);
        void OnToggleSummaryBoard(InputAction.CallbackContext context);
        void OnToggleEsc(InputAction.CallbackContext context);
        void OnToggleViewBoard(InputAction.CallbackContext context);
        void OnToggleSmartphone(InputAction.CallbackContext context);
        void OnToggleSprint(InputAction.CallbackContext context);
        void OnToggleJump(InputAction.CallbackContext context);
        void OnToggleCrouch(InputAction.CallbackContext context);
        void OnTogglePause(InputAction.CallbackContext context);
    }
}
