using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10;
    private Transform _target;
    private bool _isIdle = true;
    private Animator _animator;
    private Rigidbody2D _rb;
    private Vector2 _direction;
    private SpriteRenderer _spriteRenderer;
    private HealthManager _healthManager;

    void Start() {
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _animator = transform.GetComponentInChildren<Animator>();
        _spriteRenderer = transform.GetComponentInChildren<SpriteRenderer>();
        _healthManager = transform.GetComponent<HealthManager>();
        _rb = transform.GetComponent<Rigidbody2D>();
    }
 
    void Update()
    {
        if (_healthManager.IsDead)
        {
            _rb.Sleep();
            _rb.velocity = Vector2.zero;
            _rb.angularVelocity = 0;
            return;            
        }
        _spriteRenderer.flipX = _rb.velocity.x < 0;            
        if (_rb.velocity.magnitude > 0.3)
        {
            if (_isIdle)
                _animator.SetBool("isIdle", false);
            _isIdle = false;
        }
        else
        {
            if (!_isIdle)
                _animator.SetBool("isIdle", true);
            _isIdle = true;
        }
        if (!(Vector2.Distance(transform.position, _target.position) > 1.4)) return;
        _direction = _target.position - transform.position;
        _rb.AddForce(_direction.normalized * _speed);
    }
}
