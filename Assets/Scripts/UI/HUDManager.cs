using System;
using System.Collections;
using System.Collections.Generic;
using EventSystems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private Image bacon;
    [SerializeField] private Image cheese;
    [SerializeField] private Image salad;
    [SerializeField] private Image healthBar;
    [SerializeField] private Sprite checkedBacon;
    [SerializeField] private Sprite checkedCheese;
    [SerializeField] private Sprite checkedSalad;
    [SerializeField] private Sprite healthBarLow;
    [SerializeField] private Sprite healthBarMed;
    [SerializeField] private Sprite healthBarHigh;

    private PlayerConfig _playerConfig;

    private void Awake()
    {
        _playerConfig = GetComponent<PlayerConfig>();
        GameEventSystem.OnPlayerPickUpCollectible += UpdateScore;
    }

    private void OnDestroy()
    {
        GameEventSystem.OnPlayerPickUpCollectible -= UpdateScore;
    }

    private void UpdateScore(string Name)
    {
        if (Name.Equals("Bacon"))
        {
            bacon.sprite = checkedBacon;
        }
        else if (Name.Equals("Cheese"))
        {
            cheese.sprite = checkedCheese;
        }
        else
        {
            salad.sprite = checkedSalad;
        }
    }

    private void UpdateHealthBar()
    {
        if (_playerConfig.CurrentHealth <= 33)
        {
            healthBar.sprite = healthBarLow;
        }else if(_playerConfig.CurrentHealth > 33 && _playerConfig.CurrentHealth <= 66)
        {
            healthBar.sprite = healthBarMed;
        }
        else
        {
            healthBar.sprite = healthBarHigh;
        }
    }
}
