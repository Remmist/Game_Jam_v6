using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject pairedPortal;
    private GameObject _player;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerConfig>().gameObject;
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _player.transform.position = pairedPortal.transform.position * new Vector2(1.5f, 1);
        }
    }
}
