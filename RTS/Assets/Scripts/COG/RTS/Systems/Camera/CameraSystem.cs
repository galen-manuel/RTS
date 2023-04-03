using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace COG.RTS
{
    public class CameraSystem : MonoBehaviour, ISystem
    {
        public RTSCamera RTSCamera { get; private set; }

        private CameraInput _cameraInput;
        private CameraRig _cameraRig;

        public void InitSystem(MasterSystem masterSystem)
        {
            CogBehaviourSystem cogBehaviourSystem = masterSystem.GetSystem<CogBehaviourSystem>();

            if (cogBehaviourSystem == null)
            {
                Debug.LogError("CogBehaviourSystem is NULL!");
                return;
            }
            
            RTSCamera = cogBehaviourSystem.LoadBehaviour<RTSCamera>($"Camera/{nameof(RTSCamera)}");

            _cameraInput = RTSCamera.CameraInput;
            _cameraRig = RTSCamera.CameraRig;
        }

        public void UpdateSystem(float pDeltaTime)
        {
            _cameraInput.CustomUpdate(pDeltaTime);
            _cameraRig.CustomUpdate(pDeltaTime);
        }

        public void LateUpdateSystem(float pDeltaTime)
        {
            _cameraInput.CustomLateUpdate(pDeltaTime);
            _cameraRig.CustomLateUpdate(pDeltaTime);
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
            _cameraRig.CleanUp();
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
