using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace COG.RTS
{
    public class TransportGroupUI : MonoBehaviour
    {
        public TMP_InputField XInputField;
        public TMP_InputField YInputField;
        public TMP_InputField ZInputField;
        
        private CameraRig _cameraRig;

        // Start is called before the first frame update
        void Start()
        {
            _cameraRig = FindObjectOfType<CameraRig>();
        }

        public void OnGoPressed()
        {
            Vector3 position = new Vector3();
            position.Set(string.IsNullOrEmpty(XInputField.text) ? 0 : Convert.ToSingle(XInputField.text),
                         string.IsNullOrEmpty(YInputField.text) ? 0 : Convert.ToSingle(YInputField.text),
                         string.IsNullOrEmpty(ZInputField.text) ? 0 : Convert.ToSingle(ZInputField.text));
            _cameraRig.TransportToPosition(position);
        }
    }
}
