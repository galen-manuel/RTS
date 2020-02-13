using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace COG.RTS.Systems.Camera
{
    public class CameraInput : CogBehaviour
    {
        private RTSCamera _rtsCamera;
        
        public void Init(RTSCamera pRtsCamera)
        {
            base.Init();

            _rtsCamera = pRtsCamera;
        }

        public override void CustomUpdate(float pDt)
        {
            
        }

        public override void CleanUp()
        {
            
        }
    } 
}
