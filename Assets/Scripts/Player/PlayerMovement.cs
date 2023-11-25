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
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    

    void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        _mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = _mousePos - _rb.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        _rb.rotation = angle;
    }
}
