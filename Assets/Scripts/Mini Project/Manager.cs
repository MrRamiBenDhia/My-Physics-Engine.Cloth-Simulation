using UnityEditor;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public CubePush cubePush;

    // Start is called before the first frame update
    void Start()
    {
        UpdateForcesFromUI();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateForcesFromUI();
    }

    void UpdateForcesFromUI()
    {
        // Retrieve values from EditorPrefs and apply them at runtime
        cubePush.forceMagnitude1 = EditorPrefs.GetFloat("ForceValueF1", 2.5f);
        cubePush.forceMagnitude2 = EditorPrefs.GetFloat("ForceValueF2", 2.5f);
        // Retrieve other stored values as needed
    }
}
