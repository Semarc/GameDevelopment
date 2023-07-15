//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Input/Controls.inputactions
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

public partial class @Controls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""PlayerBall"",
            ""id"": ""627ca6e1-0170-468a-855f-f4fe4c7d7cc0"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""592a6f86-326e-4fa0-9ba9-13e4084a7e0c"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""9ff7eb1d-7d6f-4f79-bed1-1c6fb6ffa4e0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""GodMode"",
                    ""type"": ""Button"",
                    ""id"": ""ab853f43-fd8d-4a6a-9798-380352b7b230"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ReturnMainMenu"",
                    ""type"": ""Button"",
                    ""id"": ""6bbbfb04-6c3c-4f4e-9c72-04f2c6d18d24"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""3D Vector"",
                    ""id"": ""853a7efa-cbb9-4eb2-9c88-fc13df1fab2c"",
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
                    ""id"": ""9bfd486c-095a-4cf2-bfca-9b7079fe1629"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9ec3c82b-2151-48f3-ab4f-380814e09f77"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""eb417fab-f833-49b4-90db-4352d62b5532"",
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
                    ""id"": ""7074194d-cbff-40f3-ad99-8d4ffb1ef043"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""forward"",
                    ""id"": ""cd044463-cfad-41df-be53-23cae9c0a9c5"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""backward"",
                    ""id"": ""08dd46cc-ee16-49ac-8e95-a0af6491a640"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8c3ef52e-68c2-4787-958b-a90980263804"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cd38afd7-7962-498b-b011-59499098e4f2"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GodMode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d63c5133-ab86-48db-ab5b-5a1aeb5edf70"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ReturnMainMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerBall
        m_PlayerBall = asset.FindActionMap("PlayerBall", throwIfNotFound: true);
        m_PlayerBall_Move = m_PlayerBall.FindAction("Move", throwIfNotFound: true);
        m_PlayerBall_Jump = m_PlayerBall.FindAction("Jump", throwIfNotFound: true);
        m_PlayerBall_GodMode = m_PlayerBall.FindAction("GodMode", throwIfNotFound: true);
        m_PlayerBall_ReturnMainMenu = m_PlayerBall.FindAction("ReturnMainMenu", throwIfNotFound: true);
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

    // PlayerBall
    private readonly InputActionMap m_PlayerBall;
    private List<IPlayerBallActions> m_PlayerBallActionsCallbackInterfaces = new List<IPlayerBallActions>();
    private readonly InputAction m_PlayerBall_Move;
    private readonly InputAction m_PlayerBall_Jump;
    private readonly InputAction m_PlayerBall_GodMode;
    private readonly InputAction m_PlayerBall_ReturnMainMenu;
    public struct PlayerBallActions
    {
        private @Controls m_Wrapper;
        public PlayerBallActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerBall_Move;
        public InputAction @Jump => m_Wrapper.m_PlayerBall_Jump;
        public InputAction @GodMode => m_Wrapper.m_PlayerBall_GodMode;
        public InputAction @ReturnMainMenu => m_Wrapper.m_PlayerBall_ReturnMainMenu;
        public InputActionMap Get() { return m_Wrapper.m_PlayerBall; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerBallActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerBallActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerBallActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerBallActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @GodMode.started += instance.OnGodMode;
            @GodMode.performed += instance.OnGodMode;
            @GodMode.canceled += instance.OnGodMode;
            @ReturnMainMenu.started += instance.OnReturnMainMenu;
            @ReturnMainMenu.performed += instance.OnReturnMainMenu;
            @ReturnMainMenu.canceled += instance.OnReturnMainMenu;
        }

        private void UnregisterCallbacks(IPlayerBallActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @GodMode.started -= instance.OnGodMode;
            @GodMode.performed -= instance.OnGodMode;
            @GodMode.canceled -= instance.OnGodMode;
            @ReturnMainMenu.started -= instance.OnReturnMainMenu;
            @ReturnMainMenu.performed -= instance.OnReturnMainMenu;
            @ReturnMainMenu.canceled -= instance.OnReturnMainMenu;
        }

        public void RemoveCallbacks(IPlayerBallActions instance)
        {
            if (m_Wrapper.m_PlayerBallActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerBallActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerBallActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerBallActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerBallActions @PlayerBall => new PlayerBallActions(this);
    public interface IPlayerBallActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnGodMode(InputAction.CallbackContext context);
        void OnReturnMainMenu(InputAction.CallbackContext context);
    }
}
