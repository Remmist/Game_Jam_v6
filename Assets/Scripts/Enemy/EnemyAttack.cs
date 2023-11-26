using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Transform _target;
    private bool _isReadyToAttack;
    [SerializeField] private float attackRate;

    private EnemyConfig _enemyConfig;
    private Animator _animator;

    private void Awake()
    {
        _isReadyToAttack = true;
        _enemyConfig = GetComponent<EnemyConfig>();
        _animator = GetComponent<Animator>();
    }

    private IEnumerator Attack(Collision2D other)
    {
        _isReadyToAttack = false;
        other.gameObject.GetComponent<PlayerConfig>().TakeDamage(_enemyConfig.CurrentDamage);
        yield return new WaitForSeconds(attackRate);
        _isReadyToAttack = true;
    }
    
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && _isReadyToAttack)
        {
            _animator.SetTrigger("Attack");
            StartCoroutine(Attack(other));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _target = other.transform;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _target = null;
        }
    }
}
