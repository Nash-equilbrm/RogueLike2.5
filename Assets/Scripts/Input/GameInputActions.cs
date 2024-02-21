//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/Input/GameInputActions.inputactions
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

namespace MyGame.Input
{
    public partial class @GameInputActions: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @GameInputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""d6bbfa89-3362-450a-8212-ab659328de3f"",
            ""actions"": [
                {
                    ""name"": ""PlayerMovement"",
                    ""type"": ""Value"",
                    ""id"": ""099c3209-fc4e-4f0e-b3b6-d9ab57748ba9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""PlayerAim"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ebe7a944-61e3-4350-b58a-9357fc530b91"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""PlayerUseWeapon"",
                    ""type"": ""Value"",
                    ""id"": ""73227d82-d9cb-47e9-aa2a-ee9e23b9a4ab"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""PlayerDash"",
                    ""type"": ""Button"",
                    ""id"": ""82262b78-6404-47f9-a92a-af5a23394a4c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""e8da7617-c4c1-44d1-970d-84de032b824d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""4d68d747-b574-42a7-b626-1397e9f25436"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8035b027-8da1-40c3-b1f0-0468d7df2cda"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c595c3be-756f-4500-825f-ed0bf5a2dded"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3c444242-33ed-4997-a118-2e0890c1bffe"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7e1a655a-39e3-4664-8ea9-c293b33445f0"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerAim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7685f0a6-2186-4f1f-8ec7-531741135876"",
                    ""path"": ""<Mouse>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerUseWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""87efe772-d88d-4afb-8486-7c3fcccc8e7b"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayerDash"",
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
            m_Player_PlayerMovement = m_Player.FindAction("PlayerMovement", throwIfNotFound: true);
            m_Player_PlayerAim = m_Player.FindAction("PlayerAim", throwIfNotFound: true);
            m_Player_PlayerUseWeapon = m_Player.FindAction("PlayerUseWeapon", throwIfNotFound: true);
            m_Player_PlayerDash = m_Player.FindAction("PlayerDash", throwIfNotFound: true);
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
        private readonly InputAction m_Player_PlayerMovement;
        private readonly InputAction m_Player_PlayerAim;
        private readonly InputAction m_Player_PlayerUseWeapon;
        private readonly InputAction m_Player_PlayerDash;
        public struct PlayerActions
        {
            private @GameInputActions m_Wrapper;
            public PlayerActions(@GameInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @PlayerMovement => m_Wrapper.m_Player_PlayerMovement;
            public InputAction @PlayerAim => m_Wrapper.m_Player_PlayerAim;
            public InputAction @PlayerUseWeapon => m_Wrapper.m_Player_PlayerUseWeapon;
            public InputAction @PlayerDash => m_Wrapper.m_Player_PlayerDash;
            public InputActionMap Get() { return m_Wrapper.m_Player; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
            public void AddCallbacks(IPlayerActions instance)
            {
                if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
                @PlayerMovement.started += instance.OnPlayerMovement;
                @PlayerMovement.performed += instance.OnPlayerMovement;
                @PlayerMovement.canceled += instance.OnPlayerMovement;
                @PlayerAim.started += instance.OnPlayerAim;
                @PlayerAim.performed += instance.OnPlayerAim;
                @PlayerAim.canceled += instance.OnPlayerAim;
                @PlayerUseWeapon.started += instance.OnPlayerUseWeapon;
                @PlayerUseWeapon.performed += instance.OnPlayerUseWeapon;
                @PlayerUseWeapon.canceled += instance.OnPlayerUseWeapon;
                @PlayerDash.started += instance.OnPlayerDash;
                @PlayerDash.performed += instance.OnPlayerDash;
                @PlayerDash.canceled += instance.OnPlayerDash;
            }

            private void UnregisterCallbacks(IPlayerActions instance)
            {
                @PlayerMovement.started -= instance.OnPlayerMovement;
                @PlayerMovement.performed -= instance.OnPlayerMovement;
                @PlayerMovement.canceled -= instance.OnPlayerMovement;
                @PlayerAim.started -= instance.OnPlayerAim;
                @PlayerAim.performed -= instance.OnPlayerAim;
                @PlayerAim.canceled -= instance.OnPlayerAim;
                @PlayerUseWeapon.started -= instance.OnPlayerUseWeapon;
                @PlayerUseWeapon.performed -= instance.OnPlayerUseWeapon;
                @PlayerUseWeapon.canceled -= instance.OnPlayerUseWeapon;
                @PlayerDash.started -= instance.OnPlayerDash;
                @PlayerDash.performed -= instance.OnPlayerDash;
                @PlayerDash.canceled -= instance.OnPlayerDash;
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
            void OnPlayerMovement(InputAction.CallbackContext context);
            void OnPlayerAim(InputAction.CallbackContext context);
            void OnPlayerUseWeapon(InputAction.CallbackContext context);
            void OnPlayerDash(InputAction.CallbackContext context);
        }
    }
}
