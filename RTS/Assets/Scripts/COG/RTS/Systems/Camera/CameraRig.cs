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
            Dragging,
            AutoMove
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
        private Vector3 _moveToTargetPosition;
        private Action _moveToOnComplete;
        
        private Transform _transform;
        private Vector2 _inputVector;
        private Vector3 _translation;
        private Vector3 _smoothDampVelocity;
        private State _state;

        private RTSCamera _rtsCamera;
        
        private Vector2 _deltaMousePos;
        private Vector3 _centreScreenPosition;

        private float _zoomPercentage = 1;
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
                    // Set translation
                    _translation.Set(_inputVector.x * XSpeed.Value, 0, _inputVector.y * ZSpeed.Value);
                    // Rotate translation
                    _translation = Quaternion.Euler(0, _transform.eulerAngles.y, 0) * _translation;
                    // Zoom camera
                    CameraTransform.localPosition = Vector3.SmoothDamp(CameraTransform.localPosition, 
                        Vector3.Lerp(NoZoomPosition, FullZoomPosition, _zoomPercentage / MaxZoom.Value), ref _zoomSmoothDampVelocity, ZoomSmoothTime.Value);
                    break;
                case State.Rotating:
                    break;
                case State.Dragging:
                    // Set translation
                    _translation.Set(_deltaMousePos.x * XSpeed.Value * (SyncMouseAndGroundMoveDirection ? 1 : -1), 0, _deltaMousePos.y * ZSpeed.Value * (SyncMouseAndGroundMoveDirection ? 1 : -1));
                    // Rotate translation
                    _translation = Quaternion.Euler(0, _transform.eulerAngles.y, 0) * _translation;
                    break;
                case State.AutoMove:
                    // Zoom camera
                    CameraTransform.localPosition = Vector3.SmoothDamp(CameraTransform.localPosition, 
                                                                       Vector3.Lerp(NoZoomPosition, FullZoomPosition, _zoomPercentage / MaxZoom.Value), ref _zoomSmoothDampVelocity, ZoomSmoothTime.Value);
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
                    // Smoothly move towards target position
                    _transform.position = Vector3.SmoothDamp(curPos, curPos + _translation, ref _smoothDampVelocity, 0.5f);
                    break;
                case State.Rotating:
                    // Rotate around the centre point of the screen
                    _transform.RotateAround(_centreScreenPosition, Vector3.up, _deltaMousePos.x / RotationDivisor.Value);
                    break;
                case State.Dragging:
                    // Smoothly move towards target position
                    _transform.position = Vector3.SmoothDamp(curPos, curPos + _translation, ref _smoothDampVelocity, ClickAndDragSmoothTime.Value);
                    break;
                case State.AutoMove:
                    // Smoothly move towards target position
                    _transform.position =
                        Vector3.SmoothDamp(curPos, _moveToTargetPosition, ref _smoothDampVelocity, 0.5f);
                    // If we've reached our target, switch to normal state and invoke complete callback
                    if (Vector3.Distance(curPos, _moveToTargetPosition) < 0.1f)
                    {
                        _state = State.Normal;
                        _moveToOnComplete?.Invoke();
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void ModifyZoomFactor(float pModification)
        {
            _zoomPercentage = Mathf.Clamp(_zoomPercentage + pModification * ZoomStep.Value, MinZoom.Value, MaxZoom.Value);
        }

        public void ClearZoomFactor()
        {
            _zoomPercentage = 0;
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
            if (_state == State.AutoMove)
            {
                return;
            }
            
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
            if (_state == State.AutoMove)
            {
                return;
            }
            
            _state = State.Normal;
        }

        public void StartDragging()
        {
            if (_state == State.AutoMove)
            {
                return;
            }
            
            _state = State.Dragging;
        }

        public void StopDragging()
        {
            if (_state == State.AutoMove)
            {
                return;
            }
            
            _state = State.Normal;
            _deltaMousePos.Set(0, 0);
        }

        public void SetTarget(Transform pTarget)
        {
            _target = pTarget;
        }

        public void TransportToPosition(Vector3 pNewPosition, bool pClearZoom = false)
        {
            _state = State.Normal;
            _translation.Set(0, 0, 0);
            _transform.position = pNewPosition;
            if (pClearZoom)
            {
                ClearZoomFactor();
            }
        }

        public void MoveToPosition(Vector3 pNewPosition, Action pOnComplete = null, bool pClearZoom = false)
        {
            _state = State.AutoMove;
            _moveToTargetPosition = pNewPosition;
            _moveToOnComplete = pOnComplete;
            if (pClearZoom)
            {
                ClearZoomFactor();
            }
        }

        // TODO GM => Function to move to position that is looking at a position/target
    } 
}
