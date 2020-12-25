using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WindowGameOverScript : MonoBehaviour
{
    public void CountinePressed()
    {
        SceneManager.LoadScene(1);
        Debug.Log("CountinePressed!");
    }

    public void ExitToMenuPressed()
    {
        SceneManager.LoadScene(0);
        Debug.Log("ExitToMenuPressed!");
    }
}
