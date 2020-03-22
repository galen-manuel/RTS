using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace COG.RTS
{
    public interface ICameraInputBehaviour
    {
        void ListenAction(InputAction pInputAction, CameraRig pCameraRig);
    }
}
