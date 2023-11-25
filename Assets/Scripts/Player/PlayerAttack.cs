using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform attackCircle;
    [SerializeField] private LayerMask enemyLayer;
    
    [SerializeField] private float attackRange;
    [SerializeField] private float attackRate;
    [SerializeField] private float sphereAttackRate;
    private bool _isReadyToAttack;

    [SerializeField] private GameObject attackLeft;
    [SerializeField] private GameObject attackRight;
    
    
    private PlayerConfig _playerConfig;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _playerConfig = GetComponent<PlayerConfig>();
        _playerMovement = GetComponent<PlayerMovement>();
        _isReadyToAttack = true;
        attackLeft.SetActive(false);
        attackRight.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && _isReadyToAttack)
        {
            StartCoroutine(Attack(_playerMovement.Faced));
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse1) && _isReadyToAttack)
        {
            StartCoroutine(AttackSphere());
        }
    }

    private IEnumerator Attack(string facing)
    {
        _isReadyToAttack = false;
        if (facing == "left")
        {
            attackLeft.SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }
        else
        {
            attackRight.SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }
        attackLeft.SetActive(false);
        attackRight.SetActive(false);
        yield return new WaitForSeconds(attackRate);
        _isReadyToAttack = true;
    }

    private IEnumerator AttackSphere()
    {
        _isReadyToAttack = false;
        Collider2D[] hitObj = Physics2D.OverlapCircleAll(attackCircle.position, attackRange, enemyLayer);
        foreach (var hit in hitObj)
        {
            hit.GetComponent<EnemyConfig>().TakeDamage(_playerConfig.CurrentDamage);
        }
        yield return new WaitForSeconds(sphereAttackRate);
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
