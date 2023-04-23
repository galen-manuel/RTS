using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace COG.RTS
{
    public class ClickAndDragInputBehaviour : CameraInputBehaviour
    {
        private bool _rightMouseButtonDown;
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
                _rightMouseButtonDown = Convert.ToBoolean(pInputAction.ReadValue<float>());
                if (_rightMouseButtonDown)
                {
                    pCameraRig.StartDragging();
                }
                else
                {
                    pCameraRig.StopDragging();
                }
            }
            else if (actionName == ActionName)
            {
                if (_rightMouseButtonDown == false)
                {
                    return;
                }
                
                pCameraRig.SetMouseDelta(pInputAction.ReadValue<Vector2>());
            }
        }

        protected override bool IsInterested(string pActionName) => pActionName == ActionName || pActionName == ModifyName;
    }
}
