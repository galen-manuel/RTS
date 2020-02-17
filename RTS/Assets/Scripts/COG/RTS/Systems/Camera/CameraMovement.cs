using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace COG.RTS.Systems.Camera
{
    public class CameraMovement : CogBehaviour
    {
        public float XSpeed;
        public float ZSpeed;
        
        private Transform _target;
        private Transform _transform;
        private Vector2 _inputVector;
        private Vector3 _translation;
        private Vector3 _velocity;

        private RTSCamera _rtsCamera;
        
        public void Init(RTSCamera pRtsCamera)
        {
            base.Init();
            
            _transform = transform;
            _inputVector = new Vector2();
            _translation = new Vector3();

            _rtsCamera = pRtsCamera;
        }

        public override void CustomUpdate(float pDt)
        {
            _translation.Set(_inputVector.x * XSpeed, 0, _inputVector.y * ZSpeed);
        }

        public override void CustomLateUpdate(float pDeltaTime)
        {
            Vector3 curPos = _transform.position;
            _transform.position =
                Vector3.SmoothDamp(curPos, curPos + _translation, ref _velocity, 0.5f);
        }

        public override void CleanUp()
        {
            throw new System.NotImplementedException($"{nameof(CameraMovement)}.CleanUp");
        }
        
        public void SetInput(Vector2 pMovement)
        {
            _inputVector = pMovement;
        }

        public void SetTarget(Transform pTarget)
        {
            _target = pTarget;
        }
    } 
}
