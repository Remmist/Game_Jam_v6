using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    private PlayerConfig _playerConfig;

    private void Awake()
    {
        _playerConfig = FindObjectOfType<PlayerConfig>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyConfig>().TakeDamage(_playerConfig.CurrentDamage);
        }
    }
}
