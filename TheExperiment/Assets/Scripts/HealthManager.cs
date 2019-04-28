using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private Animator _animator;
    private bool _isDead;
    private int _currentHealth;
    [SerializeField]
    private int _maxHealth = 100;
    private HealthBar _healthBar;

    public bool IsDead
    {
        get { return _isDead; }
        set { _isDead = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _healthBar = GetComponentInChildren<HealthBar>();
        _currentHealth = _maxHealth;
        _isDead = false;
    }

    private void Update()
    {
        CheckStatus();
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0 || _isDead)
            return;
        _currentHealth -= damage;
        _healthBar.SubFillBar((float)damage / _maxHealth * 100);
        _animator.Play("TakeDamage");
    }

    private void CheckStatus()
    {
        if (_currentHealth <= 0)
        {
            _animator.SetBool("isDead", true);
            _isDead = true;
        }
        else if (_isDead && _currentHealth > 0)
        {
            _animator.SetBool("isDead", false);
            _isDead = false;
        }        
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
