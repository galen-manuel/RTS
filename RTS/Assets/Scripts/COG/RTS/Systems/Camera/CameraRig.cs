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
            Rotating,
            Dragging
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
        
        [Header("Click and Drag")] 
        public FloatReference ClickAndDragSmoothTime;
        public bool SyncMouseAndGroundMoveDirection;
        
        private Transform _target;
        private Transform _transform;
        private Vector2 _inputVector;
        private Vector3 _translation;
        private Vector3 _smoothDampVelocity;
        private State _state;

        private RTSCamera _rtsCamera;
        
        private Vector2 _deltaMousePos;
        private Vector3 _centreScreenPosition;

        private float _zoomPercentage;
        private Vector3 _zoomSmoothDampVelocity;
        
        private Vector3 _clickAndDragSmoothDampVelocity;

        public Camera UnityCamera => CameraTransform.GetComponent<Camera>();

        public void Init(RTSCamera pRtsCamera)
        {
            base.Init();
            
            _transform = transform;
            _inputVector = new Vector2();
            _translation = new Vector3();
            _deltaMousePos = new Vector2();

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
                case State.Dragging:
                    _translation.Set(_deltaMousePos.x * XSpeed.Value * (SyncMouseAndGroundMoveDirection ? 1 : -1), 0, _deltaMousePos.y * ZSpeed.Value * (SyncMouseAndGroundMoveDirection ? 1 : -1));
                    _translation = Quaternion.Euler(0, _transform.eulerAngles.y, 0) * _translation;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override void CustomLateUpdate(float pDeltaTime)
        {
            Vector3 curPos = _transform.position;
            switch (_state)
            {
                case State.Normal:
                    _transform.position = Vector3.SmoothDamp(curPos, curPos + _translation, ref _smoothDampVelocity, 0.5f);
                    break;
                case State.Rotating:
                    _transform.RotateAround(_centreScreenPosition, Vector3.up, _deltaMousePos.x / RotationDivisor.Value);
                    break;
                case State.Dragging:
                    _transform.position = Vector3.SmoothDamp(curPos, curPos + _translation, ref _smoothDampVelocity, ClickAndDragSmoothTime.Value);
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

        public void SetMouseDelta(Vector2 pDelta)
        {
            if (_state != State.Rotating && _state != State.Dragging)
            {
                return;
            }
            
            _deltaMousePos.Set(pDelta.x, pDelta.y);
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

        public void StartDragging()
        {
            _state = State.Dragging;
        }

        public void StopDragging()
        {
            _state = State.Normal;
        }

        public void SetTarget(Transform pTarget)
        {
            _target = pTarget;
        }
    } 
}
