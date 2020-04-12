using UnityEngine;
using UnityEngine.InputSystem;

namespace COG.RTS
{
    public class ScreenEdgeCameraInput : CameraInputBehaviour
    {
        public Vector2 ScreenDimensions { get; set; }
        
        private Vector2 _previousInputVector;
        
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
            
            Vector2 actionValue = pInputAction.ReadValue<Vector2>();
            Vector2 inputVector = new Vector2();
            if (actionValue.x > ScreenDimensions.x - 10)
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

            if (actionValue.y > ScreenDimensions.y - 10)
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
                pCameraRig.SetInput(_previousInputVector);

                return;
            }
            // Normalize to match keyboard controls, which are normalized by Unity's input system
            inputVector.Normalize();
            // Pass along the current input vector
            pCameraRig.SetInput(_previousInputVector);
            _previousInputVector = inputVector;
        }
    }
}
