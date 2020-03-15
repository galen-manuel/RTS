using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace COG.RTS
{
    public class CameraMovement : CogBehaviour
    {
        public FloatReference XSpeed;
        public FloatReference ZSpeed;
        [Tooltip("The higher the number the slower the camera rotates.")]
        public FloatReference RotationDivisor;
        public LayerMask CameraPlaneLayerMask;
        
        private Transform _target;
        private Transform _transform;
        private Vector2 _inputVector;
        private Vector3 _translation;
        private Vector3 _velocity;

        private RTSCamera _rtsCamera;
        
        private bool _isRotating;
        private float _deltaX;
        private Vector3 _centreScreenPosition;
        
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
            if (_isRotating == false)
            {
                _translation.Set(_inputVector.x * XSpeed.Value, 0, _inputVector.y * ZSpeed.Value);
                _translation = Quaternion.Euler(0, _transform.eulerAngles.y, 0) * _translation;
            }
        }

        public override void CustomLateUpdate(float pDeltaTime)
        {
            if (_isRotating)
            {
                _transform.RotateAround(_centreScreenPosition, Vector3.up, _deltaX / RotationDivisor.Value);
            }
            else
            {
                Vector3 curPos = _transform.position;
                _transform.position =
                    Vector3.SmoothDamp(curPos, curPos + _translation, ref _velocity, 0.5f);
            }
            
        }

        public override void CleanUp()
        {
            throw new System.NotImplementedException($"{nameof(CameraMovement)}.CleanUp");
        }
        
        public void SetInput(Vector2 pMovement)
        {
            _inputVector = pMovement;
        }

        public void SetMouseDeltaX(float pDeltaX)
        {
            _deltaX = pDeltaX;
        }

        public void StartRotating()
        {
            Ray r = _rtsCamera.UnityCamera.ScreenPointToRay(new Vector3(Screen.width / 2.0f, Screen.height / 2.0f));
            
            if (!Physics.Raycast(r, out RaycastHit hit, CameraPlaneLayerMask))
            {
                return;
            }

            _isRotating = true;
            _centreScreenPosition = hit.point;
        }

        public void StopRotating()
        {
            _isRotating = false;
        }

        public void SetTarget(Transform pTarget)
        {
            _target = pTarget;
        }
    } 
}
