using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurReference : MonoBehaviour
{
    private HealthManager _healthManager;
    private MinotaurBehavior _behavior;

    // Start is called before the first frame update
    private void Start()
    {
        _healthManager = GetComponentInParent<HealthManager>();
        _behavior = GetComponentInParent<MinotaurBehavior>();
    }

    public void Die()
    {
        _healthManager.Die();
    }

    public void Attack()
    {
        _behavior.Attack();
    }

    public void AttackEnd()
    {
        _behavior.AttackEnd();
    }
}
