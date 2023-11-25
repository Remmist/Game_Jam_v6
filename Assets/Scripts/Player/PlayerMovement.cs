using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    
    [SerializeField] private float moveSpeed;
    
    private Vector2 _movement;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private PlayerAttack _playerAttack;

    private string _faced;
    private string _direction;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerAttack = GetComponent<PlayerAttack>();
    }
    

    void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        
        if (_movement.x > 0)
        {
            _spriteRenderer.flipX = true;
            _faced = "right";
        } 
        if(_movement.x < 0)
        {
            _spriteRenderer.flipX = false;
            _faced = "left";
        }
        
        if (_movement.y > 0)
        {
            _animator.SetBool("IsRunningBack", true);
            _animator.SetBool("IsRunningFront", false);
            _direction = "back";
        }
        else if (_movement.y < 0)
        {
            _animator.SetBool("IsRunningBack", false);
            _animator.SetBool("IsRunningFront", true);
            _direction = "front";
        }
        else
        {
            if (_movement.x != 0)
            {
                _animator.SetBool("IsRunningFront", true);
                _animator.SetBool("IsRunningBack", false);
                _direction = "front";
            }
            else
            {
                _animator.SetBool("IsRunningBack", false);
                _animator.SetBool("IsRunningFront", false);
                _direction = "front";
            }
        }
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _movement * moveSpeed * Time.fixedDeltaTime);
    }

    public string Faced
    {
        get => _faced;
        set => _faced = value;
    }

    public string Direction
    {
        get => _direction;
        set => _direction = value;
    }

    public float Speed
    {
        get => moveSpeed;
        set => moveSpeed = value;
    }
}
