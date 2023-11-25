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
    private bool _isReadyToAttackSphere;

    [SerializeField] private GameObject attackLeft;
    [SerializeField] private GameObject attackRight;
    
    
    private PlayerConfig _playerConfig;
    private PlayerMovement _playerMovement;
    private Animator _animator;
    [SerializeField] private ParticleSystem ps;

    private void Awake()
    {
        _playerConfig = GetComponent<PlayerConfig>();
        _playerMovement = GetComponent<PlayerMovement>();
        _animator = GetComponent<Animator>();
        _isReadyToAttack = true;
        _isReadyToAttackSphere = true;
        attackLeft.SetActive(false);
        attackRight.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && _isReadyToAttack)
        {
            StartCoroutine(Attack(_playerMovement.Faced));
            if (_playerMovement.Direction == "front")
            {
                _animator.SetTrigger("FrontAttack");
            }
            else
            {
                _animator.SetTrigger("BackAttack");
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse1) && _isReadyToAttackSphere)
        {
            _animator.SetTrigger("RotationAttack");
            StartCoroutine(AttackSphere());
            if (ps.isPlaying)
            {
                ps.Stop();
            }
            else
            {
                ps.Play();
            }
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
        _isReadyToAttackSphere = false;
        Collider2D[] hitObj = Physics2D.OverlapCircleAll(attackCircle.position, attackRange, enemyLayer);
        foreach (var hit in hitObj)
        {
            hit.GetComponent<EnemyConfig>().TakeDamage(_playerConfig.RotationDamage);
        }
        yield return new WaitForSeconds(sphereAttackRate);
        _isReadyToAttackSphere = true;
    }
    
    private void OnDrawGizmosSelected()
    {
        if (attackCircle == null)
        {
            return;
        }
        
        Gizmos.DrawWireSphere(attackCircle.position, attackRange);
    }

    public bool IsReadyToAttack
    {
        get => _isReadyToAttack;
        set => _isReadyToAttack = value;
    }
}
