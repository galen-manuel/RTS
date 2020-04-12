using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace COG.RTS
{
    public class ChangePositionGroupUI : MonoBehaviour
    {
        public Toggle MoveToToggle;
        public Toggle ClearZoomToggle;
        public TMP_InputField XInputField;
        public TMP_InputField YInputField;
        public TMP_InputField ZInputField;
        
        private CameraRig _cameraRig;
        private CanvasGroup _canvasGroup;

        // Start is called before the first frame update
        void Start()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            _cameraRig = FindObjectOfType<CameraRig>();
        }

        public void OnGoPressed()
        {
            Vector3 position = new Vector3();
            position.Set(string.IsNullOrEmpty(XInputField.text) ? 0 : Convert.ToSingle(XInputField.text),
                         string.IsNullOrEmpty(YInputField.text) ? 0 : Convert.ToSingle(YInputField.text),
                         string.IsNullOrEmpty(ZInputField.text) ? 0 : Convert.ToSingle(ZInputField.text));
            if (MoveToToggle.isOn)
            {
                _canvasGroup.interactable = false;
                _cameraRig.MoveToPosition(position, OnMoveToComplete, ClearZoomToggle.isOn);
            }
            else
            {
                _cameraRig.TransportToPosition(position, ClearZoomToggle.isOn);
            }
        }

        private void OnMoveToComplete()
        {
            _canvasGroup.interactable = true;
        }
    }
}
