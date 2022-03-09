using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneScript : MonoBehaviour
{
    public void loadIsland()
    {
        SceneManager.LoadScene("Island");
    }
    public void loadMap()
    {
        SceneManager.LoadScene("MapScene");
    }
}
