using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  COG.RTS.Systems.Camera
{
    public class RTSCamera : CogBehaviour
    {
        public CameraInput CameraInput { get; private set; }
        public CameraMovement CameraMovement { get; private set; }

        public override void Init()
        {
            base.Init();

            CameraInput = GetComponent<CameraInput>();
            CameraMovement = GetComponent<CameraMovement>();
            
            CameraInput.Init(this);
            CameraMovement.Init(this);
        }
    }
}
