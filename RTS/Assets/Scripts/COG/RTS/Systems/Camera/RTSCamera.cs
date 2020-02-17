using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  COG.RTS.Systems.Camera
{
    /// <summary>
    /// Coordinates Input and Movement
    /// </summary>
    public class RTSCamera : CogBehaviour
    {
        public CameraInput CameraInput { get; private set; }
        public CameraMovement CameraMovement { get; private set; }

        public override void Init()
        {
            base.Init();

            Cursor.lockState = CursorLockMode.Confined;

            CameraInput = GetComponent<CameraInput>();
            CameraMovement = GetComponent<CameraMovement>();
            
            CameraInput.Init(this);
            CameraMovement.Init(this);
        }

        public void PassInput(Vector2 pInputVector2)
        {
            CameraMovement.SetInput(pInputVector2);
        }
    }
}
