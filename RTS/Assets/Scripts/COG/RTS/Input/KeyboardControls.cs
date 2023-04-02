// GENERATED AUTOMATICALLY FROM 'Assets/Input/KeyboardControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace COG.RTS
{
    public class @KeyboardControls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @KeyboardControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""KeyboardControls"",
    ""maps"": [
        {
            ""name"": ""GamePlay"",
            ""id"": ""c5b476ca-19df-4848-912d-7846edc1a123"",
            ""actions"": [
                {
                    ""name"": ""CameraMovement"",
                    ""type"": ""Value"",
                    ""id"": ""6cb0f0b6-5297-4e17-9adc-b316e15673fe"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseMovement"",
                    ""type"": ""Button"",
                    ""id"": ""60e86a0d-4361-41c6-b2ae-af3f66954314"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseDelta"",
                    ""type"": ""Value"",
                    ""id"": ""c7d3624a-aafd-4436-9747-e5cfa0ed504a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseWheelDelta"",
                    ""type"": ""Value"",
                    ""id"": ""c33d4b15-454f-449d-b2df-d6b19707d8bb"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ShouldClickAndDrag"",
                    ""type"": ""Button"",
                    ""id"": ""9a74ec21-cd21-4e77-999f-4a6bbbaae6f0"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ShouldRotateCamera"",
                    ""type"": ""Button"",
                    ""id"": ""7b8e21e4-29ca-40a0-b7b6-a4f44a6a2fdc"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WSAD"",
                    ""id"": ""0edaeb6a-b9e1-4781-984b-797b4f37aff4"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9be7ed9b-6ee1-48b9-b095-b3f4d204dfa2"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""137c9088-99e5-425f-ad10-9adf626f01aa"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5dc1c4c0-b78b-420e-b49f-62021b12f457"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""064dc568-639a-4feb-b6ca-ee31ffa5ae89"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ArrowKeys"",
                    ""id"": ""d4ffc1c3-77e7-46c4-9258-cb6801459530"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""875905ff-21f7-465c-b2b7-8d799b82efdc"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""09fa90b6-879f-4c97-a86e-bac587096ea3"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""50c4c0de-dd77-465b-ad15-6be724a610b5"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""154ebcf2-bc10-4c82-a730-d8f01d6cd64a"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d49bb760-a015-481a-9c2a-2d7c5c453886"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0f1c99d6-e586-415d-896b-9c1bf766eb73"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1f629f28-32c3-4237-bdbc-d01da72f6518"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseWheelDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0311ef56-ea62-4ec9-a863-7915db83af5e"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShouldClickAndDrag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bce8ae22-7564-4ec1-87d5-57ac780d85b9"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShouldRotateCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // GamePlay
            m_GamePlay = asset.FindActionMap("GamePlay", throwIfNotFound: true);
            m_GamePlay_CameraMovement = m_GamePlay.FindAction("CameraMovement", throwIfNotFound: true);
            m_GamePlay_MouseMovement = m_GamePlay.FindAction("MouseMovement", throwIfNotFound: true);
            m_GamePlay_MouseDelta = m_GamePlay.FindAction("MouseDelta", throwIfNotFound: true);
            m_GamePlay_MouseWheelDelta = m_GamePlay.FindAction("MouseWheelDelta", throwIfNotFound: true);
            m_GamePlay_ShouldClickAndDrag = m_GamePlay.FindAction("ShouldClickAndDrag", throwIfNotFound: true);
            m_GamePlay_ShouldRotateCamera = m_GamePlay.FindAction("ShouldRotateCamera", throwIfNotFound: true);
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

        // GamePlay
        private readonly InputActionMap m_GamePlay;
        private IGamePlayActions m_GamePlayActionsCallbackInterface;
        private readonly InputAction m_GamePlay_CameraMovement;
        private readonly InputAction m_GamePlay_MouseMovement;
        private readonly InputAction m_GamePlay_MouseDelta;
        private readonly InputAction m_GamePlay_MouseWheelDelta;
        private readonly InputAction m_GamePlay_ShouldClickAndDrag;
        private readonly InputAction m_GamePlay_ShouldRotateCamera;
        public struct GamePlayActions
        {
            private @KeyboardControls m_Wrapper;
            public GamePlayActions(@KeyboardControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @CameraMovement => m_Wrapper.m_GamePlay_CameraMovement;
            public InputAction @MouseMovement => m_Wrapper.m_GamePlay_MouseMovement;
            public InputAction @MouseDelta => m_Wrapper.m_GamePlay_MouseDelta;
            public InputAction @MouseWheelDelta => m_Wrapper.m_GamePlay_MouseWheelDelta;
            public InputAction @ShouldClickAndDrag => m_Wrapper.m_GamePlay_ShouldClickAndDrag;
            public InputAction @ShouldRotateCamera => m_Wrapper.m_GamePlay_ShouldRotateCamera;
            public InputActionMap Get() { return m_Wrapper.m_GamePlay; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GamePlayActions set) { return set.Get(); }
            public void SetCallbacks(IGamePlayActions instance)
            {
                if (m_Wrapper.m_GamePlayActionsCallbackInterface != null)
                {
                    @CameraMovement.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnCameraMovement;
                    @CameraMovement.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnCameraMovement;
                    @CameraMovement.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnCameraMovement;
                    @MouseMovement.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMouseMovement;
                    @MouseMovement.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMouseMovement;
                    @MouseMovement.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMouseMovement;
                    @MouseDelta.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMouseDelta;
                    @MouseDelta.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMouseDelta;
                    @MouseDelta.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMouseDelta;
                    @MouseWheelDelta.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMouseWheelDelta;
                    @MouseWheelDelta.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMouseWheelDelta;
                    @MouseWheelDelta.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMouseWheelDelta;
                    @ShouldClickAndDrag.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnShouldClickAndDrag;
                    @ShouldClickAndDrag.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnShouldClickAndDrag;
                    @ShouldClickAndDrag.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnShouldClickAndDrag;
                    @ShouldRotateCamera.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnShouldRotateCamera;
                    @ShouldRotateCamera.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnShouldRotateCamera;
                    @ShouldRotateCamera.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnShouldRotateCamera;
                }
                m_Wrapper.m_GamePlayActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @CameraMovement.started += instance.OnCameraMovement;
                    @CameraMovement.performed += instance.OnCameraMovement;
                    @CameraMovement.canceled += instance.OnCameraMovement;
                    @MouseMovement.started += instance.OnMouseMovement;
                    @MouseMovement.performed += instance.OnMouseMovement;
                    @MouseMovement.canceled += instance.OnMouseMovement;
                    @MouseDelta.started += instance.OnMouseDelta;
                    @MouseDelta.performed += instance.OnMouseDelta;
                    @MouseDelta.canceled += instance.OnMouseDelta;
                    @MouseWheelDelta.started += instance.OnMouseWheelDelta;
                    @MouseWheelDelta.performed += instance.OnMouseWheelDelta;
                    @MouseWheelDelta.canceled += instance.OnMouseWheelDelta;
                    @ShouldClickAndDrag.started += instance.OnShouldClickAndDrag;
                    @ShouldClickAndDrag.performed += instance.OnShouldClickAndDrag;
                    @ShouldClickAndDrag.canceled += instance.OnShouldClickAndDrag;
                    @ShouldRotateCamera.started += instance.OnShouldRotateCamera;
                    @ShouldRotateCamera.performed += instance.OnShouldRotateCamera;
                    @ShouldRotateCamera.canceled += instance.OnShouldRotateCamera;
                }
            }
        }
        public GamePlayActions @GamePlay => new GamePlayActions(this);
        public interface IGamePlayActions
        {
            void OnCameraMovement(InputAction.CallbackContext context);
            void OnMouseMovement(InputAction.CallbackContext context);
            void OnMouseDelta(InputAction.CallbackContext context);
            void OnMouseWheelDelta(InputAction.CallbackContext context);
            void OnShouldClickAndDrag(InputAction.CallbackContext context);
            void OnShouldRotateCamera(InputAction.CallbackContext context);
        }
    }
}
