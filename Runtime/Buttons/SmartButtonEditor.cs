using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;

namespace Kuroneko.UIDelivery
{
    [CustomEditor(typeof(SmartButton), true)]
    [CanEditMultipleObjects]
    public class SmartButtonEditor : ButtonEditor
    {
        SerializedProperty presetController;
        SerializedProperty text;
        
        protected override void OnEnable()
        {
            base.OnEnable();
            presetController = serializedObject.FindProperty("m_presetController");
            text = serializedObject.FindProperty("m_text");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(presetController);
            EditorGUILayout.PropertyField(text);
            EditorGUILayout.Space();
            serializedObject.ApplyModifiedProperties();
            
            base.OnInspectorGUI();
        }
    }
}
