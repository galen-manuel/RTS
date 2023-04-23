using UnityEngine.InputSystem;

namespace COG.RTS
{
    public class ScrollWheelZoom : CameraInputBehaviour
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
            
            pCameraRig.ModifyZoomFactor(pInputAction.ReadValue<float>() < 0 ? -1 : 1);
        }
    }
}
