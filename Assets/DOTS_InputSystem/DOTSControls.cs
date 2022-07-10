// GENERATED AUTOMATICALLY FROM 'Assets/DOTS_InputSystem/DOTSControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @DOTSControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @DOTSControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""DOTSControls"",
    ""maps"": [
        {
            ""name"": ""DOTSplayer"",
            ""id"": ""e6d4303f-b497-4917-a48f-653644846373"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""75a3f76a-a395-4eb5-a965-c5847fcbd82b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""8beeab53-669b-4a88-b0ca-dd18a667f57d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Arrow"",
                    ""id"": ""9e5a971d-a898-4b36-b187-4b4624b07988"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""45b7f6d2-a6ae-467f-a6fc-ef2e902df02e"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""14076e46-1ee3-427c-b2e4-aa3abb3162ad"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""faa55707-efb2-4fc5-98c9-2323279d40dd"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""dfd87a38-4f9d-4782-aae9-722c821696ec"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""4fe9e718-cea9-4046-8425-1067f1f62ce5"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""SingletonSystem"",
            ""id"": ""b59ef7df-bfc1-4337-842e-b82e6723decd"",
            ""actions"": [
                {
                    ""name"": ""AddVal"",
                    ""type"": ""Button"",
                    ""id"": ""0dae609c-0cc6-4b15-9290-a76d745338b1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SubVal"",
                    ""type"": ""Button"",
                    ""id"": ""7f27822f-7ecc-4706-99c6-12d024818ee2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e396b865-d5cc-492f-a9de-8a91d299359e"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AddVal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ae3bb787-8bc1-4876-9477-8cdf0be05438"",
                    ""path"": ""<Keyboard>/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SubVal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // DOTSplayer
        m_DOTSplayer = asset.FindActionMap("DOTSplayer", throwIfNotFound: true);
        m_DOTSplayer_Move = m_DOTSplayer.FindAction("Move", throwIfNotFound: true);
        m_DOTSplayer_Jump = m_DOTSplayer.FindAction("Jump", throwIfNotFound: true);
        // SingletonSystem
        m_SingletonSystem = asset.FindActionMap("SingletonSystem", throwIfNotFound: true);
        m_SingletonSystem_AddVal = m_SingletonSystem.FindAction("AddVal", throwIfNotFound: true);
        m_SingletonSystem_SubVal = m_SingletonSystem.FindAction("SubVal", throwIfNotFound: true);
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

    // DOTSplayer
    private readonly InputActionMap m_DOTSplayer;
    private IDOTSplayerActions m_DOTSplayerActionsCallbackInterface;
    private readonly InputAction m_DOTSplayer_Move;
    private readonly InputAction m_DOTSplayer_Jump;
    public struct DOTSplayerActions
    {
        private @DOTSControls m_Wrapper;
        public DOTSplayerActions(@DOTSControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_DOTSplayer_Move;
        public InputAction @Jump => m_Wrapper.m_DOTSplayer_Jump;
        public InputActionMap Get() { return m_Wrapper.m_DOTSplayer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DOTSplayerActions set) { return set.Get(); }
        public void SetCallbacks(IDOTSplayerActions instance)
        {
            if (m_Wrapper.m_DOTSplayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_DOTSplayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_DOTSplayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_DOTSplayerActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_DOTSplayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_DOTSplayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_DOTSplayerActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_DOTSplayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public DOTSplayerActions @DOTSplayer => new DOTSplayerActions(this);

    // SingletonSystem
    private readonly InputActionMap m_SingletonSystem;
    private ISingletonSystemActions m_SingletonSystemActionsCallbackInterface;
    private readonly InputAction m_SingletonSystem_AddVal;
    private readonly InputAction m_SingletonSystem_SubVal;
    public struct SingletonSystemActions
    {
        private @DOTSControls m_Wrapper;
        public SingletonSystemActions(@DOTSControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @AddVal => m_Wrapper.m_SingletonSystem_AddVal;
        public InputAction @SubVal => m_Wrapper.m_SingletonSystem_SubVal;
        public InputActionMap Get() { return m_Wrapper.m_SingletonSystem; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SingletonSystemActions set) { return set.Get(); }
        public void SetCallbacks(ISingletonSystemActions instance)
        {
            if (m_Wrapper.m_SingletonSystemActionsCallbackInterface != null)
            {
                @AddVal.started -= m_Wrapper.m_SingletonSystemActionsCallbackInterface.OnAddVal;
                @AddVal.performed -= m_Wrapper.m_SingletonSystemActionsCallbackInterface.OnAddVal;
                @AddVal.canceled -= m_Wrapper.m_SingletonSystemActionsCallbackInterface.OnAddVal;
                @SubVal.started -= m_Wrapper.m_SingletonSystemActionsCallbackInterface.OnSubVal;
                @SubVal.performed -= m_Wrapper.m_SingletonSystemActionsCallbackInterface.OnSubVal;
                @SubVal.canceled -= m_Wrapper.m_SingletonSystemActionsCallbackInterface.OnSubVal;
            }
            m_Wrapper.m_SingletonSystemActionsCallbackInterface = instance;
            if (instance != null)
            {
                @AddVal.started += instance.OnAddVal;
                @AddVal.performed += instance.OnAddVal;
                @AddVal.canceled += instance.OnAddVal;
                @SubVal.started += instance.OnSubVal;
                @SubVal.performed += instance.OnSubVal;
                @SubVal.canceled += instance.OnSubVal;
            }
        }
    }
    public SingletonSystemActions @SingletonSystem => new SingletonSystemActions(this);
    public interface IDOTSplayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
    public interface ISingletonSystemActions
    {
        void OnAddVal(InputAction.CallbackContext context);
        void OnSubVal(InputAction.CallbackContext context);
    }
}
