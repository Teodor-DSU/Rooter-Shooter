using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBehaviour : MonoBehaviour
{
    private void LoadScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
