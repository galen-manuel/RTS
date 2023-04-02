using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace COG.RTS.Units
{
    public class FaceCamera : CogBehaviour
    {
        private Transform _transform;
        private Transform _targetCamera;
        private Plane _targetCameraPlane;

        public void Initialize(Transform rtsCameraTransform)
        {
            _targetCamera = rtsCameraTransform;
        }

        private void Awake()
        {
            _transform = transform;
        }

        private void Start()
        {
            // TODO GM => This should be passed in when created
            Initialize(MasterSystem.Instance.GetSystem<CameraSystem>().RTSCamera.UnityCamera.transform);
        }

        // Update is called once per frame
        private void LateUpdate()
        {
            // TODO GM => Only rotate on the y axis
            _targetCameraPlane.SetNormalAndPosition(_targetCamera.forward, _targetCamera.position);
            Vector3 closestPoint = _targetCameraPlane.ClosestPointOnPlane(_transform.position);
            _transform.LookAt(new Vector3(closestPoint.x, 0, closestPoint.z));
        }
    }
}