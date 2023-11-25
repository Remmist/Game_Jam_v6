using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;

    [SerializeField] private Camera cam;
    [SerializeField] private float moveSpeed = 5f;
    
    private Vector2 _movement;
    private Vector2 _mousePos;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private string faced;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    

    void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        _mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
        if (_movement.x > 0)
        {
            _spriteRenderer.flipX = true;
            faced = "right";
        } 
        if(_movement.x < 0)
        {
            _spriteRenderer.flipX = false;
            faced = "left";
        }
        
        if (_movement.y > 0)
        {
            _animator.SetBool("IsRunningBack", true);
            _animator.SetBool("IsRunningFront", false);
        }
        else if (_movement.y < 0)
        {
            _animator.SetBool("IsRunningBack", false);
            _animator.SetBool("IsRunningFront", true);
        }
        else
        {
            if (_movement.x != 0)
            {
                _animator.SetBool("IsRunningFront", true);
                _animator.SetBool("IsRunningBack", false);
            }
            else
            {
                _animator.SetBool("IsRunningBack", false);
                _animator.SetBool("IsRunningFront", false);
            }
        }
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _movement * moveSpeed * Time.fixedDeltaTime);

        // Vector2 lookDir = _mousePos - _rb.position;
        //
        // float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        // _rb.rotation = angle;
    }

    public string Faced
    {
        get => faced;
        set => faced = value;
    }
}
