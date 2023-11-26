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
    [SerializeField] private Sprite checkedBacon;
    [SerializeField] private Sprite checkedCheese;
    [SerializeField] private Sprite checkedSalad;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private GameObject player;

    private void Awake()
    {
        GameEventSystem.OnPlayerPickUpCollectible += UpdateScore;
    }

    private void OnDestroy()
    {
        GameEventSystem.OnPlayerPickUpCollectible -= UpdateScore;
    }

    private void Update()
    {
        _healthBar.maxValue = player.GetComponent<PlayerConfig>().MaxHealth;
        _healthBar.value = player.GetComponent<PlayerConfig>().CurrentHealth;
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
}
