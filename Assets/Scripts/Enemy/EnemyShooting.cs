using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    private EnemyAwarenessController _awarenessController;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float coolDown;
    private bool _isReady;
    private Animator _animator;

    private void Start()
    {
        _isReady = true;
    }

    private void Awake()
    {
        _awarenessController = GetComponent<EnemyAwarenessController>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_awarenessController.awareOfPlayer && _isReady)
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        _isReady = false;
        Instantiate(bullet, transform.position, Quaternion.identity);
        if (_animator.GetBool("IsRunningFront"))
        {
            _animator.SetTrigger("ShootFront");
        }
        else
        {
            _animator.SetTrigger("ShootBack");
        }
        yield return new WaitForSeconds(coolDown);
        _isReady = true;
    }
    
}
