// GENERATED AUTOMATICALLY FROM 'Assets/Scenes/TestScene/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""8b3e4bcf-9f3b-465c-9043-fe9f9ca76b23"",
            ""actions"": [
                {
                    ""name"": ""PressA"",
                    ""type"": ""Button"",
                    ""id"": ""d3fb38f6-994e-4e0b-a8e8-18cc14221953"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftStick"",
                    ""type"": ""Button"",
                    ""id"": ""4e64de22-2e5a-4ba7-a021-b9b016899f2d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f6d85fb1-98d3-4c21-9958-1537c131eeca"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": ""XboxControllerScheme"",
                    ""action"": ""PressA"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""8d54792f-95ee-4143-9d0d-ec8d1208ffce"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftStick"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""33979d09-3db7-4e45-b420-95af90470b4c"",
                    ""path"": ""<Gamepad>/leftStick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxControllerScheme"",
                    ""action"": ""LeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a77de053-c494-41ad-b2b3-8375f6f1310b"",
                    ""path"": ""<Gamepad>/leftStick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxControllerScheme"",
                    ""action"": ""LeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e8145ad0-76ba-4cab-a2fc-6ee6e4cee001"",
                    ""path"": ""<Gamepad>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxControllerScheme"",
                    ""action"": ""LeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""55469067-5aee-4f5b-92d3-716a0d3792cc"",
                    ""path"": ""<Gamepad>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxControllerScheme"",
                    ""action"": ""LeftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""XboxControllerScheme"",
            ""bindingGroup"": ""XboxControllerScheme"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_PressA = m_Player.FindAction("PressA", throwIfNotFound: true);
        m_Player_LeftStick = m_Player.FindAction("LeftStick", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_PressA;
    private readonly InputAction m_Player_LeftStick;
    public struct PlayerActions
    {
        private @InputMaster m_Wrapper;
        public PlayerActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @PressA => m_Wrapper.m_Player_PressA;
        public InputAction @LeftStick => m_Wrapper.m_Player_LeftStick;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @PressA.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPressA;
                @PressA.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPressA;
                @PressA.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPressA;
                @LeftStick.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftStick;
                @LeftStick.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftStick;
                @LeftStick.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftStick;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PressA.started += instance.OnPressA;
                @PressA.performed += instance.OnPressA;
                @PressA.canceled += instance.OnPressA;
                @LeftStick.started += instance.OnLeftStick;
                @LeftStick.performed += instance.OnLeftStick;
                @LeftStick.canceled += instance.OnLeftStick;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_XboxControllerSchemeSchemeIndex = -1;
    public InputControlScheme XboxControllerSchemeScheme
    {
        get
        {
            if (m_XboxControllerSchemeSchemeIndex == -1) m_XboxControllerSchemeSchemeIndex = asset.FindControlSchemeIndex("XboxControllerScheme");
            return asset.controlSchemes[m_XboxControllerSchemeSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnPressA(InputAction.CallbackContext context);
        void OnLeftStick(InputAction.CallbackContext context);
    }
}
