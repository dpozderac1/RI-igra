using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public void quitGame()
    {
        Debug.Log("Quit igrice");
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
