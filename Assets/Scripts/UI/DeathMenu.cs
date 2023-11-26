using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{

    private PlayerConfig _playerConfig;
    [SerializeField] private GameObject deathMenu;

    private void Awake()
    {
        _playerConfig = FindObjectOfType<PlayerConfig>();
        deathMenu.SetActive(false);
    }

    private void Update()
    {
        if (!_playerConfig.IsAlive)
        {
            deathMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
