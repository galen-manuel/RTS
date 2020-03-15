using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  COG.RTS
{
    /// <summary>
    /// Coordinates Input and Movement
    /// </summary>
    public class RTSCamera : CogBehaviour
    {
        public CameraInput CameraInput { get; private set; }
        public CameraMovement CameraMovement { get; private set; }
        public Camera UnityCamera { get; private set; }

        public override void Init()
        {
            base.Init();

            Cursor.lockState = CursorLockMode.Confined;

            CameraInput = GetComponent<CameraInput>();
            CameraMovement = GetComponent<CameraMovement>();
            UnityCamera = GetComponent<Camera>();
            
            CameraInput.Init(this);
            CameraMovement.Init(this);
        }
    }
}
