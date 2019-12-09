using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace COG.RTS.Systems.Camera
{
    public class CameraSystem : MonoBehaviour, ISystem
    {
        private CameraInput _cameraInput;
        private CameraMovement _cameraMovement;

        public void InitSystem()
        {
            _cameraInput.Init();
            _cameraMovement.Init();
        }

        public void UpdateSystem(float pDeltaTime)
        {
            _cameraInput.CustomUpdate(pDeltaTime);
            _cameraMovement.CustomUpdate(pDeltaTime);
        }

        public void LateUpdateSystem(float pDeltaTime)
        {
            throw new System.NotImplementedException();
        }

        public void PauseSystem()
        {
            throw new System.NotImplementedException();
        }

        public void ShutdownSystem()
        {
            _cameraInput.CleanUp();
            _cameraMovement.CleanUp();
        }

        public void StartSystem()
        {
            throw new System.NotImplementedException();
        }

        public void StopSystem()
        {
            throw new System.NotImplementedException();
        }
    } 
}
