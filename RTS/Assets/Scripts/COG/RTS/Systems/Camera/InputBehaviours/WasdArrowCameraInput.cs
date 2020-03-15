using UnityEngine;
using UnityEngine.InputSystem;

namespace COG.RTS
{
    public class WasdArrowCameraInput : CameraInputBehaviour
    {
        public override void ListenAction(InputAction pInputAction, CameraMovement pCameraMovement)
        {
            if (!IsInterested(pInputAction.name))
            {
                return;
            }
            
            pCameraMovement.SetInput(pInputAction.ReadValue<Vector2>());
        }
    }
}
