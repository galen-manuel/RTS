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
            
            RTSCamera rtsCamera = cogBehaviourSystem.LoadBehaviour<RTSCamera>($"Camera/{nameof(RTSCamera)}");

            _cameraInput = rtsCamera.CameraInput;
            _cameraMovement = rtsCamera.CameraMovement;
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
            throw new System.NotImplementedException($"{nameof(CameraSystem)}.PauseSystem");
        }

        public void ResumeSystem()
        {
            throw new System.NotImplementedException($"{nameof(CameraSystem)}.ResumeSystem");
        }

        public void ShutdownSystem()
        {
            _cameraInput.CleanUp();
            _cameraMovement.CleanUp();
        }

        public void StartSystem()
        {
            throw new System.NotImplementedException($"{nameof(CameraSystem)}.StartSystem");
        }

        public void StopSystem()
        {
            throw new System.NotImplementedException($"{nameof(CameraSystem)}.StopSystem");
        }
    } 
}
