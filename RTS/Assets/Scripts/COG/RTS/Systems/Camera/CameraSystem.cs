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
            CogBehaviourSystem cogBehaviourSystem = MasterSystem.Instance.GetSystem<CogBehaviourSystem>();

            if (cogBehaviourSystem == null)
            {
                Debug.LogError("CogBehaviourSystem is NULL!");
                return;
            }
            
            GameObject mainCameraGo = null;
            RTSCamera rtsCamera = cogBehaviourSystem.LoadBehaviour<RTSCamera>($"Camera/{nameof(RTSCamera)}");

            mainCameraGo = rtsCamera.gameObject;

            _cameraInput = rtsCamera.CameraInput;
            _cameraMovement = rtsCamera.CameraMovement;

            // _cameraInput = cogBehaviourSystem.AddBehaviour<CameraInput>(mainCameraGo);
            //
            // _cameraMovement = cogBehaviourSystem.AddBehaviour<CameraMovement>(mainCameraGo);
            // _cameraMovement.XSpeed = 5;
            // _cameraMovement.ZSpeed = 5;
            //
            // _cameraInput.Init();
            // _cameraMovement.Init();
        }

        public void UpdateSystem(float pDeltaTime)
        {
            _cameraInput.CustomUpdate(pDeltaTime);
            _cameraMovement.CustomUpdate(pDeltaTime);
        }

        public void LateUpdateSystem(float pDeltaTime)
        {
            _cameraInput.CustomLateUpdate(pDeltaTime);
            _cameraMovement.CustomLateUpdate(pDeltaTime);
        }

        public void PauseSystem()
        {
            throw new System.NotImplementedException();
        }

        public void ResumeSystem()
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
