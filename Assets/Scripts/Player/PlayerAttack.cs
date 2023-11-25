using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform attackCircle;

    [SerializeField] private float attackRange;
    [SerializeField] private float attackRate;
    
    // [SerializeField] private LayerMask layerToAttack;
    private bool _isReadyToAttack;

    private PlayerConfig _playerConfig;

    private void Awake()
    {
        _playerConfig = GetComponent<PlayerConfig>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && _isReadyToAttack)
        {
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        _isReadyToAttack = false;
        Collider2D[] hitObj = Physics2D.OverlapCircleAll(attackCircle.position, attackRange);
        // foreach (var hit in hitObj)
        // {
        //     if (hit.GetComponent<>() != null)
        //     {
        //         hit.TakeDamage(_playerConfig.CurrentDamage);
        //     }
        // }
        yield return new WaitForSeconds(attackRate);
        _isReadyToAttack = true;
    }
    
    private void OnDrawGizmosSelected()
    {
        if (attackCircle == null)
        {
            return;
        }
        
        Gizmos.DrawWireSphere(attackCircle.position, attackRange);
    }
    
}
