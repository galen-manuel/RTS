using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace COG.RTS
{
    public class CameraInput : CogBehaviour//, KeyboardControls.IGamePlayActions
    {
        public bool WASDMovement = true;
        public bool ScreenEdgeMovement = true;
        public bool RotateAroundCenter = true;
        public bool ScrollWheelZoom = true;
        public bool ClickAndDrag = true;

        private KeyboardControls _keyboardControls;
        private RTSCamera _rtsCamera;
        private PlayerInput _playerInput;
        private List<CameraInputBehaviour> _cameraInputBehaviours;
        
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
            
            _cameraInputBehaviours = new List<CameraInputBehaviour>();

            WasdArrowCameraInput wasdArrowCameraInput = new WasdArrowCameraInput()
                                                        {
                                                            ActionName = _keyboardControls.GamePlay.CameraMovement.name, 
                                                            Priority = 1,
                                                            Enabled = WASDMovement
                                                        };
            ScreenEdgeCameraInput screenEdgeCameraInput = new ScreenEdgeCameraInput()
                                                          {
                                                              ActionName = _keyboardControls.GamePlay.MouseMovement.name,
                                                              Priority = 0,
                                                              ScreenDimensions = new Vector2(Screen.width, Screen.height),
                                                              Enabled = ScreenEdgeMovement
                                                          };
            RotateAroundCenterCameraInput rotateAroundCenterCameraInput = new RotateAroundCenterCameraInput()
                                                                          {
                                                                              ActionName = _keyboardControls.GamePlay.MouseDelta.name,
                                                                              ModifyName = _keyboardControls.GamePlay.ShouldRotateCamera.name,
                                                                              Priority = 2,
                                                                              Enabled = RotateAroundCenter
                                                                          };
            ScrollWheelZoom scrollWheelZoomInput = new ScrollWheelZoom()
                                              {
                                                  ActionName = _keyboardControls.GamePlay.MouseWheelDelta.name,
                                                  Priority = 3,
                                                  Enabled = ScrollWheelZoom
                                              };
            ClickAndDragInputBehaviour clickAndDragInput = new ClickAndDragInputBehaviour()
                                                           {
                                                               ActionName = _keyboardControls.GamePlay.MouseDelta.name,
                                                               ModifyName = _keyboardControls.GamePlay.ShouldClickAndDrag.name,
                                                               Priority = 4,
                                                               Enabled = ClickAndDrag
                                                           };
            
            _cameraInputBehaviours.Add(wasdArrowCameraInput);
            _cameraInputBehaviours.Add(screenEdgeCameraInput);
            _cameraInputBehaviours.Add(rotateAroundCenterCameraInput);
            _cameraInputBehaviours.Add(scrollWheelZoomInput);
            _cameraInputBehaviours.Add(clickAndDragInput);
            
            _cameraInputBehaviours.Sort((pX, pY) => pX.Priority.CompareTo(pY.Priority));
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

        private void OnActionTriggered(InputAction.CallbackContext pCallbackContext)
        {
            for (int i = _cameraInputBehaviours.Count - 1; i >= 0; i--)
            {
                _cameraInputBehaviours[i].ListenAction(pCallbackContext.action, _rtsCamera.CameraRig);
            }
        }
    }
}
