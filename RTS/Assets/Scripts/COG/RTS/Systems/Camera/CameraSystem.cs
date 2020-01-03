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
            GameObject mainCameraGo = null;
            UnityEngine.Camera mainCamera = UnityEngine.Camera.main;

            // Grab main camera game object or create one
            if (mainCamera == null)
            {
                mainCameraGo = new GameObject("MainCamera");
                mainCamera = mainCameraGo.AddComponent<UnityEngine.Camera>();
                mainCameraGo.tag = "MainCamera";
            }
            else
            {
                mainCameraGo = mainCamera.gameObject;
            }
            
            CogBehaviourSystem cogBehaviourSystem = MasterSystem.Instance.GetSystem<CogBehaviourSystem>();

            if (cogBehaviourSystem == null)
            {
                Debug.LogError("CogBehaviourSystem is NULL!");
                return;
            }

            _cameraInput = cogBehaviourSystem.AddBehaviour<CameraInput>(mainCameraGo);

            _cameraMovement = cogBehaviourSystem.AddBehaviour<CameraMovement>(mainCameraGo);
            _cameraMovement.XSpeed = 5;
            _cameraMovement.ZSpeed = 5;

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
