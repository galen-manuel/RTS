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
            _inputVector.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            _translation.Set(_inputVector.x * XSpeed, 0, _inputVector.y * ZSpeed);
        }

        public override void CustomLateUpdate(float pDeltaTime)
        {
            _transform.Translate(_translation * pDeltaTime, Space.World);
        }

        public override void CleanUp()
        {
            throw new System.NotImplementedException();
        }

        public void SetTarget(Transform pTarget)
        {
            _target = pTarget;
        }
    } 
}
