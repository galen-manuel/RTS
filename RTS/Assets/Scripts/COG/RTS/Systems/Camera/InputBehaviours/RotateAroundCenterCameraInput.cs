using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace COG.RTS
{
    public class RotateAroundCenterCameraInput : CameraInputBehaviour
    {
        private bool _middleMouseButtonDown;
        public override void ListenAction(InputAction pInputAction, CameraRig pCameraRig)
        {
            if (!Enabled)
            {
                return;
            }
            
            if (!IsInterested(pInputAction.name))
            {
                return;
            }

            if (pInputAction.name == ModifyName)
            {
                _middleMouseButtonDown = Convert.ToBoolean(pInputAction.ReadValue<float>());
                if (_middleMouseButtonDown)
                {
                    pCameraRig.StartRotating();
                }
                else
                {
                    pCameraRig.StopRotating();
                }
            }
            else if (pInputAction.name == ActionName)
            {
                if (_middleMouseButtonDown == false)
                {
                    return;
                }
                
                pCameraRig.SetMouseDeltaX(pInputAction.ReadValue<float>());
            }
        }

        protected override bool IsInterested(string pActionName) =>
            ActionName == pActionName || ModifyName == pActionName;
    }   
}
