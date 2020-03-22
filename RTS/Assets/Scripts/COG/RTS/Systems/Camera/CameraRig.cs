using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace COG.RTS
{
    public class CameraRig : CogBehaviour
    {
        private enum State
        {
            Normal,
            Rotating
        }
        
        public FloatReference XSpeed;
        public FloatReference ZSpeed;
        [Tooltip("The higher the number the slower the camera rotates.")]
        public FloatReference RotationDivisor;
        public LayerMask CameraPlaneLayerMask;
        public Transform CameraTransform;
        [Header("Camera Zoom")]
        public FloatReference ZoomStep;
        public Vector3 NoZoomPosition;
        public Vector3 FullZoomPosition;
        public FloatReference MinZoom;
        public FloatReference MaxZoom;
        public FloatReference ZoomSmoothTime;
        
        private Transform _target;
        private Transform _transform;
        private Vector2 _inputVector;
        private Vector3 _translation;
        private Vector3 _smoothDampVelocity;
        private State _state;

        private RTSCamera _rtsCamera;
        
        private float _deltaX;
        private Vector3 _centreScreenPosition;

        private float _zoomPercentage;
        private Vector3 _zoomSmoothDampVelocity;

        public Camera UnityCamera => CameraTransform.GetComponent<Camera>();

        public void Init(RTSCamera pRtsCamera)
        {
            base.Init();
            
            _transform = transform;
            _inputVector = new Vector2();
            _translation = new Vector3();

            _rtsCamera = pRtsCamera;

            _state = State.Normal;
        }

        public override void CustomUpdate(float pDt)
        {
            switch (_state)
            {
                case State.Normal:
                    _translation.Set(_inputVector.x * XSpeed.Value, 0, _inputVector.y * ZSpeed.Value);
                    _translation = Quaternion.Euler(0, _transform.eulerAngles.y, 0) * _translation;
                    CameraTransform.localPosition = Vector3.SmoothDamp(CameraTransform.localPosition, 
                        Vector3.Lerp(NoZoomPosition, FullZoomPosition, _zoomPercentage / MaxZoom.Value), ref _zoomSmoothDampVelocity, ZoomSmoothTime.Value);
                    break;
                case State.Rotating:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override void CustomLateUpdate(float pDeltaTime)
        {
            switch (_state)
            {
                case State.Normal:
                    Vector3 curPos = _transform.position;
                    Vector3 newPos = curPos + _translation;
                    _transform.position = Vector3.SmoothDamp(curPos, newPos, ref _smoothDampVelocity, 0.5f);
                    break;
                case State.Rotating:
                    _transform.RotateAround(_centreScreenPosition, Vector3.up, _deltaX / RotationDivisor.Value);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void ModifyZoomFactor(float pModification)
        {
            _zoomPercentage = Mathf.Clamp(_zoomPercentage + pModification * ZoomStep.Value, MinZoom.Value, MaxZoom.Value);
        }
        
        public void SetInput(Vector2 pMovement)
        {
            if (_state != State.Normal)
            {
                return;
            }
            
            _inputVector = pMovement;
        }

        public void SetMouseDeltaX(float pDeltaX)
        {
            if (_state != State.Rotating)
            {
                return;
            }
            
            _deltaX = pDeltaX;
        }

        public void StartRotating()
        {
            Ray r = _rtsCamera.UnityCamera.ScreenPointToRay(new Vector3(Screen.width / 2.0f, Screen.height / 2.0f));
            
            if (!Physics.Raycast(r, out RaycastHit hit, CameraPlaneLayerMask))
            {
                return;
            }

            _state = State.Rotating;
            _centreScreenPosition = hit.point;
        }

        public void StopRotating()
        {
            _state = State.Normal;
        }

        public void SetTarget(Transform pTarget)
        {
            _target = pTarget;
        }
    } 
}
