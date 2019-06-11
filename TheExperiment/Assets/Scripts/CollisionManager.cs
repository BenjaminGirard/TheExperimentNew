﻿using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class CollisionManager : MonoBehaviour
{
    [SerializeField]
    private int _bumpForce = 20;
    [SerializeField]
    private bool _isEnemy = true;
    private HealthManager _healthManager;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _collisionDirection;
    
    // Start is called before the first frame update
    void Start()
    {
        _healthManager = GetComponent<HealthManager>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (_isEnemy && other.gameObject.CompareTag("Enemy"))
            return;
        if (_rigidbody2D)
        {
            _collisionDirection = (Vector2)transform.position - other.GetContact(0).point;
            _rigidbody2D.AddForce(_collisionDirection * _bumpForce, ForceMode2D.Impulse);
        }
        if (other.gameObject.GetComponent<DamageDealer>() != null)
            _healthManager.TakeDamage(other.gameObject.GetComponent<DamageDealer>().Damage);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (transform.gameObject.GetComponent<DamageDealer>()._isLaunchByPlayer && other.gameObject.CompareTag("Player") || 
            !other.gameObject.GetComponent<DamageDealer>()._isLaunchByPlayer && other.gameObject.CompareTag("Enemy"))
            return;
        _healthManager.TakeDamage(other.gameObject.GetComponent<DamageDealer>().Damage);        
    }
}
