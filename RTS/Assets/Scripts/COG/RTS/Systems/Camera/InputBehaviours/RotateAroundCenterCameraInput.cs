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

            string actionName = pInputAction.name;
            if (!IsInterested(actionName))
            {
                return;
            }

            if (actionName == ModifyName)
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
            else if (actionName == ActionName)
            {
                if (_middleMouseButtonDown == false)
                {
                    return;
                }
                
                pCameraRig.SetMouseDelta(pInputAction.ReadValue<Vector2>());
            }
        }

        protected override bool IsInterested(string pActionName) =>
            ActionName == pActionName || ModifyName == pActionName;
    }   
}
