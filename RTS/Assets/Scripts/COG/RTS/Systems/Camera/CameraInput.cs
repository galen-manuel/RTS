using System.Collections;
using System.Collections.Generic;
using COG.RTS.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace COG.RTS.Systems.Camera
{
    public class CameraInput : CogBehaviour
    {
        private KeyboardControls _keyboardControls;
        private RTSCamera _rtsCamera;
        private PlayerInput _playerInput;
        
        public void Init(RTSCamera pRtsCamera)
        {
            base.Init();

            _keyboardControls = new KeyboardControls();
            
            _rtsCamera = pRtsCamera;
            _playerInput = GetComponent<PlayerInput>();
            _playerInput.actions = _keyboardControls.asset;

            _playerInput.onDeviceLost += OnDeviceLost;
            _playerInput.onDeviceRegained += OnDeviceRegained;
            _playerInput.onControlsChanged += OnControlsChanged;
            _playerInput.onActionTriggered += OnActionTriggered;
        }

        public override void CustomUpdate(float pDt)
        {
            
        }

        public override void CleanUp()
        {
            _playerInput.onActionTriggered -= OnActionTriggered;
        }

        private void OnDeviceLost(PlayerInput pPlayerInput)
        {
            
        }

        private void OnDeviceRegained(PlayerInput pPlayerInput)
        {
            
        }
        
        private void OnControlsChanged(PlayerInput pPlayerInput)
        {
            
        }

        private void OnActionTriggered(InputAction.CallbackContext pCallbackContext)
        {
            if (pCallbackContext.action.name == _keyboardControls.GamePlay.CameraMovement.name)
            {
                _rtsCamera.PassInput(pCallbackContext.ReadValue<Vector2>());
            }
        }
    }
}
