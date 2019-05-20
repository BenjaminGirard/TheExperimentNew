using System.Collections;
using System.Collections.Generic;
using System.Linq;
using QInventory;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private Animator _animator;
    private bool _isDead;
    private float _currentHealth;
    [SerializeField]

    private HealthBar _healthBar;
    private float _maxHealth;

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
        _currentHealth = gameObject.CompareTag("Player") ? PlayerInventoryManager.FindPlayerAttributeMaxValueByName("Health") : 100;
        _maxHealth = _currentHealth;
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
        _currentHealth = _currentHealth - damage <= 0 ? 0 : _currentHealth - damage;
        if (gameObject.CompareTag("Player")) PlayerInventoryManager.SetPlayerAttributeByName("Health", _currentHealth, SetType.CurrentValue);
        _healthBar.SubFillBar(damage / _maxHealth * 100);
        _animator.Play("TakeDamage");
    }

    private void CheckStatus()
    {
        if (_currentHealth <= 0)
        {
            _animator.SetBool("isDead", true);
            _isDead = true;
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 1)
                SpawnerManager.Status = SpawnerManager.SpawnStatus.SPAWN;
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
