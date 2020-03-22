using UnityEngine;
using UnityEngine.InputSystem;

namespace COG.RTS
{
    public class WasdArrowCameraInput : CameraInputBehaviour
    {
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
            
            pCameraRig.SetInput(pInputAction.ReadValue<Vector2>());
        }
    }
}
