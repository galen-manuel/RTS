using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace COG.RTS
{
    public class RotateAroundCenterCameraInput : CameraInputBehaviour
    {
        private bool _middleMouseButtonDown;
        public override void ListenAction(InputAction pInputAction, CameraMovement pCameraMovement)
        {
            if (!IsInterested(pInputAction.name))
            {
                return;
            }

            if (pInputAction.name == ModifyName)
            {
                _middleMouseButtonDown = Convert.ToBoolean(pInputAction.ReadValue<float>());
                if (_middleMouseButtonDown)
                {
                    pCameraMovement.StartRotating();
                }
                else
                {
                    pCameraMovement.StopRotating();
                }
            }
            else if (pInputAction.name == ActionName)
            {
                if (_middleMouseButtonDown == false)
                {
                    return;
                }
                
                pCameraMovement.SetMouseDeltaX(pInputAction.ReadValue<float>());
            }
        }

        protected override bool IsInterested(string pActionName) =>
            ActionName == pActionName || ModifyName == pActionName;
    }   
}
