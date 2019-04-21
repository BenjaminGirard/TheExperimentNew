using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [SerializeField]
    private int _bumpForce = 20;
    private HealthManager _healthManager;
    private Rigidbody2D _rigidbody2D;
    
    // Start is called before the first frame update
    void Start()
    {
        _healthManager = GetComponent<HealthManager>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("DamageDealer")) return;
        ContactPoint2D collisionPoint = other.GetContact(0);
        if (_rigidbody2D)
        {
            Vector2 collisionDirection = (Vector2)transform.position - collisionPoint.point;
            _rigidbody2D.AddForce(collisionDirection * _bumpForce, ForceMode2D.Impulse);
        }
        _healthManager.TakeDamage(other.gameObject.GetComponent<DamageDealer>().Damage);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("DamageDealer")) return;
        _healthManager.TakeDamage(other.gameObject.GetComponent<DamageDealer>().Damage);        
    }
}
