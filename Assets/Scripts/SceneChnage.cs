using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChnage : MonoBehaviour
{
    public void SceneChang(string name)
    {
        SceneManager.LoadScene(name);
    }

}
