using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace COG.RTS
{
    public class TestPlayer : MonoBehaviour
    {
        public Units.UnitView TestUnit;
        private CameraRig _cameraRig;
        private RTSCamera _rtsCamera;

        private void Start()
        {
            _cameraRig = FindObjectOfType<CameraRig>();
            _rtsCamera = FindObjectOfType<RTSCamera>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                Ray r = _rtsCamera.UnityCamera.ScreenPointToRay(Input.mousePosition);

                if (!Physics.Raycast(r, out RaycastHit hit, _cameraRig.CameraPlaneLayerMask))
                {
                    return;
                }
                TestUnit.SetPosition(hit.point);
            }
        }
    } 
}
