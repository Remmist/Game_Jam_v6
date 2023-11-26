using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    [SerializeField] private int maxEnemiesOnLevel;
    
    public int MaxEnemiesOnLevel
    {
        get => maxEnemiesOnLevel;
        set => maxEnemiesOnLevel = value;
    }
}
