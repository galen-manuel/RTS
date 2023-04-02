using System.Collections.Generic;
using UnityEngine.InputSystem;

namespace COG.RTS
{
    public abstract class CameraInputBehaviour : ICameraInputBehaviour
    {
        public int Priority { get; set; }
        public string ActionName { get; set; }
        public string ModifyName { get; set; }
        public bool Enabled { get; set; }

        public abstract void ListenAction(InputAction pInputAction, CameraRig pCameraRig);
        protected virtual bool IsInterested(string pActionName) => ActionName == pActionName;
    }
}
