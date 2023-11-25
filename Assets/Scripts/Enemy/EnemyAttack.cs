using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Transform _target;
    private bool _isReadyToAttack;
    [SerializeField] private float attackRate;

    [SerializeField] private int damage;
    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        _isReadyToAttack = true;
    }

    private IEnumerator Attack(Collision2D other)
    {
        Debug.Log("Attack");
        _isReadyToAttack = false;
        other.gameObject.GetComponent<PlayerConfig>().TakeDamage(damage);
        yield return new WaitForSeconds(attackRate);
        _isReadyToAttack = true;
    }
    
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && _isReadyToAttack)
        {
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
