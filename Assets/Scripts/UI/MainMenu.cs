using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 1f;
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void CreditsButton()
    {
        SceneManager.LoadScene("Credits");
    }


    public void MainMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }

    public void TutorialButton()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
