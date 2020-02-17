using System.Collections;
using System.Collections.Generic;
using COG.RTS.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace COG.RTS.Systems.Camera
{
    public class CameraInput : CogBehaviour, KeyboardControls.IGamePlayActions
    {
        private KeyboardControls _keyboardControls;
        private RTSCamera _rtsCamera;
        private PlayerInput _playerInput;
        private Vector2 _screenDimensions;
        private Vector2 _previousInputVector;
        
        public void Init(RTSCamera pRtsCamera)
        {
            base.Init();

            _screenDimensions = new Vector2(Screen.width, Screen.height);
            _previousInputVector = new Vector2();
            
            _keyboardControls = new KeyboardControls();
            _keyboardControls.GamePlay.SetCallbacks(this);
            
            _rtsCamera = pRtsCamera;
            _playerInput = GetComponent<PlayerInput>();
            _playerInput.actions = _keyboardControls.asset;

            _playerInput.onDeviceLost += OnDeviceLost;
            _playerInput.onDeviceRegained += OnDeviceRegained;
            _playerInput.onControlsChanged += OnControlsChanged;
        }

        public override void CustomUpdate(float pDt)
        {
            
        }

        public override void CleanUp()
        {
            _keyboardControls.Dispose();
        }

        private void OnDeviceLost(PlayerInput pPlayerInput)
        {
            Debug.LogWarning("Device lost");
        }

        private void OnDeviceRegained(PlayerInput pPlayerInput)
        {
            Debug.LogWarning("Device regained");
        }
        
        private void OnControlsChanged(PlayerInput pPlayerInput)
        {
            Debug.LogWarning("Controls changed");
        }

        public void OnCameraMovement(InputAction.CallbackContext pCallbackContext)
        {
            Vector2 actionValue = pCallbackContext.ReadValue<Vector2>();
            
            _rtsCamera.PassInput(actionValue);
        }

        public void OnMouseMovement(InputAction.CallbackContext pCallbackContext)
        {
            Vector2 actionValue = pCallbackContext.ReadValue<Vector2>();
            Vector2 inputVector = new Vector2();
            if (actionValue.x > _screenDimensions.x - 10)
            {
                inputVector.x = 1.0f;
            }
            else if (actionValue.x < 10)
            {
                inputVector.x = -1.0f;
            }
            else
            {
                inputVector.x = 0;
            }

            if (actionValue.y > _screenDimensions.y - 10)
            {
                inputVector.y = 1.0f;
            }
            else if (actionValue.y < 10)
            {
                inputVector.y = -1.0f;
            }
            else
            {
                inputVector.y = 0;
            }

            // If we've stopped moving the mouse
            if (Mathf.Approximately(inputVector.x, 0) && Mathf.Approximately(inputVector.y, 0))
            {
                // If we weren't moving the mouse before, do nothing
                if (Mathf.Approximately(_previousInputVector.x, 0) && Mathf.Approximately(_previousInputVector.y, 0))
                {
                    return;
                }

                // If we were, pass along zero input once
                _previousInputVector = inputVector;
                _rtsCamera.PassInput(_previousInputVector);

                return;
            }
            // Normalize to match keyboard controls, which are normalized by Unity's input system
            inputVector.Normalize();
            // Pass along the current input vector
            _rtsCamera.PassInput(inputVector);
            _previousInputVector = inputVector;
        }
    }
}
