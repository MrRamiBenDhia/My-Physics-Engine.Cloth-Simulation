using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ManagerWindow : EditorWindow 
{
    Color color;

    public float sliderValue;
    public Vector3 forceVector;
    public float forceValueF1 = 2.5f;
    public float forceValueF2 = 2.5f;
    public bool isActive = false;



    [MenuItem("Services/Mini Project")]
    public static void OpenManagerMenu()
    {
        GetWindow<ManagerWindow>("Mini Project Manager");
    }

    void OnGUI()
    {

        // Determine the middle position and the fixed height for the sliders
        float middleX = Screen.width / 2f;
        float middleY = Screen.height / 2f;
        float sliderHeight = 150f;

        //!~~~~~~~~~~~~~~~~~~~~~


        // Start a new GUI area for the sliders
        GUILayout.BeginArea(new Rect(middleX - 20, 200, 100, sliderHeight));

        // Box and label
        GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(1));
        GUILayout.Label("left / right: ", GUILayout.Width(200), GUILayout.Height(20));
        GUILayout.Space(20);

        GUILayout.BeginHorizontal();//!

        // First vertical slider
        sliderValue = GUILayout.VerticalSlider(sliderValue, 5f, 0f, GUILayout.Height(sliderHeight / 2f));
        GUILayout.Space(20);
        sliderValue = GUILayout.VerticalSlider(sliderValue, 5f, 0f, GUILayout.Height(sliderHeight / 2f));

        GUILayout.EndHorizontal();

        // Second vertical slider

        // End the GUI area for the sliders
        GUILayout.EndArea();

        //!~~~~~~~~~~~~~~~~~~~~~

        GUILayout.BeginArea(new Rect(10, 0, 200, 350));

        GUILayout.Space(20);


        GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(1));
        GUILayout.Label("Force Value: " + forceValueF1.ToString("F2"), GUILayout.Width(200), GUILayout.Height(10));
        GUILayout.Space(20);

        GUILayout.BeginHorizontal();
        // Float input field
        string forceString = GUILayout.TextField(forceValueF1.ToString(), 4);
        float.TryParse(forceString, out forceValueF1);
        // Slider for force value
        forceValueF1 = GUILayout.HorizontalSlider(forceValueF1, 0f, 5f);

        GUILayout.EndHorizontal();
        //GUILayout.EndArea();

        // New "Force Value" section beside the original one
        GUILayout.BeginArea(new Rect(00, 050, 200, 250)); // Adjust the horizontal position

        GUILayout.Space(10);

        GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(1));
        GUILayout.Label("Force Value 2: " + forceValueF2.ToString("F2"), GUILayout.Width(200), GUILayout.Height(10));
        GUILayout.Space(10);

        GUILayout.BeginHorizontal();
        // Float input field
        string forceString2 = GUILayout.TextField(forceValueF2.ToString(), 4);
        float.TryParse(forceString2, out forceValueF2);
        // Slider for force value
        forceValueF2 = GUILayout.HorizontalSlider(forceValueF2, 0f, 5f);

        GUILayout.EndHorizontal();

        GUILayout.EndArea();
        //!~~~~~~~~~~~~~~~~~~~~~

        GUILayout.Space(20);
        GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(1));
        GUILayout.Label("Force Vector", GUILayout.Width(200), GUILayout.Height(20));

        GUILayout.Space(10);

        GUILayout.BeginHorizontal();
        GUILayout.Label("X:", GUILayout.Width(20));
        string xInput = GUILayout.TextField(forceVector.x.ToString("F2"), 10, GUILayout.Width(60));
        float.TryParse(xInput, out forceVector.x);
        forceVector.x = GUILayout.HorizontalSlider(forceVector.x, -1f, 1f);
        GUILayout.EndHorizontal();

        GUILayout.Space(10);

        GUILayout.BeginHorizontal();
        GUILayout.Label("Y:", GUILayout.Width(20));
        string yInput = GUILayout.TextField(forceVector.y.ToString("F2"), 10, GUILayout.Width(60));
        float.TryParse(yInput, out forceVector.y);
        forceVector.y = GUILayout.HorizontalSlider(forceVector.y, -1f, 1f);
        GUILayout.EndHorizontal();

        GUILayout.Space(10);

        GUILayout.BeginHorizontal();
        GUILayout.Label("Z:", GUILayout.Width(20));
        string zInput = GUILayout.TextField(forceVector.z.ToString("F2"), 10, GUILayout.Width(60));
        float.TryParse(zInput, out forceVector.z);
        forceVector.z = GUILayout.HorizontalSlider(forceVector.z, -1f, 1f);
        GUILayout.EndHorizontal();

        GUILayout.Space(10);

        GUILayout.EndArea();

        //!~~~~~~~~~~~~~~~~~~~~~

        GUILayout.BeginArea(new Rect(10, 450, 200, 150));
        GUILayout.BeginHorizontal();
        if (isActive)
        {
            if (GUILayout.Button("Stop"))
            {
                isActive = false;
            }
        }
        else
        {
            if (GUILayout.Button("Start"))
            {
                isActive = true;
            }
        }

        // Reset the thrust vector
        if (GUILayout.Button("Reset"))
        {
            forceVector = Vector3.zero;
        }
        GUILayout.EndHorizontal();

        GUILayout.EndArea();

        if (GUI.changed)
        {
            // Save the values to EditorPrefs when they are changed in the Editor window
            EditorPrefs.SetFloat("ForceValueF1", forceValueF1);
            EditorPrefs.SetFloat("ForceValueF2", forceValueF2);
            EditorPrefs.SetFloat("ForceVectorX", forceVector.x);
            EditorPrefs.SetFloat("ForceVectorY", forceVector.y);
            EditorPrefs.SetFloat("ForceVectorZ", forceVector.z);
        }
    }

    void Colorize()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            //Renderer renderer = obj.GetComponent<Rendere>();
            //if (renderer != null)
            //{
            //    renderer.sharedMaterial.color = color; 
            //}
        }
    }
}
