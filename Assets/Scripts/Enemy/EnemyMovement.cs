using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    private EnemyAwarenessController _enemyAwarenessController;
    private Vector2 _targetDirection;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _enemyAwarenessController = GetComponent<EnemyAwarenessController>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }

    private void UpdateTargetDirection()
    {
        if (_enemyAwarenessController.awareOfPlayer)
        {
            _targetDirection = _enemyAwarenessController.directionToPlayer;
        }
        else
        {
            _targetDirection = Vector2.zero;
        }
    }

    private void RotateTowardsTarget()
    {
        if (_targetDirection == Vector2.zero)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        
        _rb.SetRotation(rotation);
    }

    private void SetVelocity()
    {
        if (_targetDirection == Vector2.zero)
        {
            _rb.velocity = Vector2.zero;
        }
        else
        {
            _rb.velocity = transform.up * moveSpeed;
        }
    }
}
