using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float directionChangeRate;
    [SerializeField] private float screenBorder;
    private EnemyAwarenessController _enemyAwarenessController;
    private Vector2 _targetDirection;
    private Camera _camera;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _enemyAwarenessController = GetComponent<EnemyAwarenessController>();
        _targetDirection = transform.up;
        _camera = Camera.main;
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
        HandleRandomDirection();
        HandlePlayerTargeting();
        HandleEnemyOffScreen();
    }

    private void HandleRandomDirection()
    {
        directionChangeRate -= Time.deltaTime;
        
        if (directionChangeRate <= 0)
        {
            float angleChange = Random.Range(-90f, 90f);
            Quaternion rotation = Quaternion.AngleAxis(angleChange, transform.forward);
            _targetDirection = rotation * _targetDirection;

            directionChangeRate = Random.Range(1f, 5f);
        }
    }

    private void HandlePlayerTargeting()
    {
        if (_enemyAwarenessController.awareOfPlayer)
        {
            _targetDirection = _enemyAwarenessController.directionToPlayer;
        }
    }

    private void HandleEnemyOffScreen()
    {
        Vector2 screenPosition = _camera.WorldToScreenPoint(transform.position);

        if ((screenPosition.x < screenBorder && _targetDirection.x < 0) ||
            (screenPosition.x > _camera.pixelWidth - screenBorder && _targetDirection.x > 0))
        {
            _targetDirection = new Vector2(-_targetDirection.x, _targetDirection.y);
        }

        if ((screenPosition.y < screenBorder && _targetDirection.y < 0) ||
            (screenPosition.y > _camera.pixelHeight - screenBorder && _targetDirection.y > 0))
        {
            _targetDirection = new Vector2(_targetDirection.x, -_targetDirection.y);
        }
    }

    private void RotateTowardsTarget()
    {
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        
        _rb.SetRotation(rotation);
    }

    private void SetVelocity()
    { 
        _rb.velocity = transform.up * moveSpeed;
    }
}
