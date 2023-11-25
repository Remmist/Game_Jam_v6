using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAwarenessController : MonoBehaviour
{

    public bool awareOfPlayer;
    public Vector2 directionToPlayer;
    [SerializeField] private float playerAwarenessDistance;
    private Transform _player;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayer = _player.position - transform.position;
        directionToPlayer = enemyToPlayer.normalized;

        if (enemyToPlayer.magnitude <= playerAwarenessDistance)
        {
            awareOfPlayer = true;
        }
        else
        {
            awareOfPlayer = false;
        }
    }
}
