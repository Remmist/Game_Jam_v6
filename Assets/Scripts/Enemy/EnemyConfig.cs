using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConfig : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int _currentHealth;

    [SerializeField] private int maxDamage;
    private int _currentDamage;

    private bool _isAlive;

    private void Start()
    {
        _currentHealth = maxHealth;
        _currentDamage = maxDamage;
        _isAlive = true;
    }
    
    public void TakeDamage(int damage)
    {
        if (!_isAlive)
        {
            return;
        }
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _isAlive = false;
        Debug.Log("Enemy is died!");
    }

    public int CurrentHealth
    {
        get => _currentHealth;
        set => _currentHealth = value;
    }

    public int CurrentDamage
    {
        get => _currentDamage;
        set => _currentDamage = value;
    }

    public bool IsAlive
    {
        get => _isAlive;
        set => _isAlive = value;
    }
}
