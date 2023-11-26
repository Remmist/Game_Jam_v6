using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConfig : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int _currentHealth;

    [SerializeField] private int maxDamage;
    [SerializeField] private int rotationDamage;
    private int _currentDamage;

    private bool _isAlive;
    private Animator _animator;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

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

        if (_playerMovement.Direction == "front")
        {
            _animator.SetTrigger("HurtFront");
        }
        else
        {
            _animator.SetTrigger("HurtBack");
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
        Debug.Log("Player is died!");
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

    public int RotationDamage
    {
        get => rotationDamage;
        set => rotationDamage = value;
    }

    public int MaxHealth
    {
        get => maxHealth;
        set => maxHealth = value;
    }
}
