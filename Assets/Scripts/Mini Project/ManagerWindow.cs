using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ManagerWindow : EditorWindow
{
    Color color;
    [MenuItem("Mini Project")]
    public void OpenManagerMenu()
    {
        GetWindow<ManagerWindow>("Mini Project Manager");
    }

    void OnGUI()
    {
        GUILayout.Label("Window Manager For Mini Project", EditorStyles.boldLabel);

        color = EditorGUILayout.ColorField("Color", color);
        if (GUILayout.Button("Colorize"))
        {
            
        }
    }

    void Colorize()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            Renderer renderer = obj.GetComponent<Rendere>();
            if (renderer != null)
            {
                renderer.sharedMaterial.color = color; 
            }
        }
    }
}
