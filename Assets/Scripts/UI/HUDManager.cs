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

    private void Awake()
    {
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
}
