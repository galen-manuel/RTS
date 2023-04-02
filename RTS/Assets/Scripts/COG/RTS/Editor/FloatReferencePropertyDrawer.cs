using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

// namespace COG.RTS
// {
    // [CustomPropertyDrawer(typeof(FloatReference))]
    // public class FloatReferencePropertyDrawer : PropertyDrawer
    // {
    //     private int _selectedIndex = 0;
    //     private readonly string[] _labels = new[] {"Constant", "Reference"};
    //     
    //     public override void OnGUI(Rect pPosition, SerializedProperty pProperty, GUIContent pLabel)
    //     {
    //         EditorGUI.BeginProperty(pPosition, pLabel, pProperty);
    //
    //         pPosition = EditorGUI.PrefixLabel(pPosition, GUIUtility.GetControlID(FocusType.Passive), pLabel);
    //
    //         int indent = EditorGUI.indentLevel;
    //         EditorGUI.indentLevel = 0;
    //         
    //         Rect useConstantRect = new Rect(pPosition.x, pPosition.y, 85, pPosition.height);
    //         Rect constantValueRect = new Rect(pPosition.x + 90, pPosition.y, pPosition.width, pPosition.height);
    //         Rect variableRect = new Rect(pPosition.x + 90, pPosition.y, pPosition.width, pPosition.height);
    //
    //         SerializedProperty useConstantProperty = pProperty.FindPropertyRelative("UseConstant");
    //         _selectedIndex = EditorGUI.Popup(useConstantRect, _selectedIndex, _labels);
    //         useConstantProperty.boolValue = _selectedIndex == 0;
    //         if (useConstantProperty.boolValue)
    //         {
    //             EditorGUI.PropertyField(constantValueRect, pProperty.FindPropertyRelative("ConstantValue"), GUIContent.none);
    //         }
    //         else
    //         {
    //             EditorGUI.PropertyField(variableRect, pProperty.FindPropertyRelative("Variable"), GUIContent.none);
    //         }
    //
    //         EditorGUI.indentLevel = indent;
    //         
    //         EditorGUI.EndProperty();
    //     }
    // }
// }
