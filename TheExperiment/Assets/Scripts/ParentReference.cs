using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentReference : MonoBehaviour
{
    private HealthManager _healthManager;
    private EnemyBehavior _enemyBehavior;

    // Start is called before the first frame update
    private void Start()
    {
        _healthManager = GetComponentInParent<HealthManager>();
        _enemyBehavior = GetComponentInParent<EnemyBehavior>();
    }

    public void Die()
    {
        _healthManager.Die();
    }

    public void Attack()
    {
        _enemyBehavior.Attack();
    }
}
