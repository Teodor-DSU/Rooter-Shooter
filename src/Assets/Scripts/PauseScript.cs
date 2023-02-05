using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject Shade;
 

    public void Menu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void Pause()
    {
        PauseMenu.SetActive(true);
        Shade.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        Shade.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Quit()
    {
        Debug.Log("Quitted Game!");
        Application.Quit();
    }

   
}
