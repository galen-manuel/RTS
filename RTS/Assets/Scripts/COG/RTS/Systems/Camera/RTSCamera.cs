using UnityEngine;

namespace  COG.RTS
{
    /// <summary>
    /// Coordinates Input and Movement
    /// </summary>
    public class RTSCamera : CogBehaviour
    {
        public CameraInput CameraInput { get; private set; }
        public CameraRig CameraRig { get; private set; }
        public Camera UnityCamera { get; private set; }

        public override void Init()
        {
            base.Init();

            Cursor.lockState = CursorLockMode.Confined;

            CameraInput = GetComponent<CameraInput>();
            CameraRig = GetComponent<CameraRig>();
            UnityCamera = CameraRig.UnityCamera;
            
            CameraInput.Init(this);
            CameraRig.Init(this);
        }
    }
}
