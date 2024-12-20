using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public static class CustomEditorGUILayout
{

    public static void PropertyDrawerWithEditButton(Rect rect, SerializedProperty property)
    {
        PropertyDrawerWithEditButton(rect,property,new GUIContent(property.displayName));
    }
    public static void PropertyDrawerWithEditButton(Rect rect, SerializedProperty property,GUIContent windowLabel)
    {
        EditorGUI.PropertyField(rect, property, GUIContent.none);
        return;
        //Trouver une astuce pour detecter uniquement les classes pur et les list et arrays etc...
        if (property.hasChildren && property.type != typeof(string).ToString())
        {
            if(GUI.Button(rect,"Edit"))
            {
                ChildPropertiesEditor.ShowWindowEditorProperty(property,windowLabel);
            }
        }
        else
        {
            EditorGUI.PropertyField(rect,property, GUIContent.none);
        }
    }
    
}
