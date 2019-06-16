using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyclopReference : MonoBehaviour
{
    private HealthManager _healthManager;
    private CyclopBehavior _behavior;

    // Start is called before the first frame update
    private void Start()
    {
        _healthManager = GetComponentInParent<HealthManager>();
        _behavior = GetComponentInParent<CyclopBehavior>();
    }

    public void Die()
    {
        _healthManager.Die();
    }

    public void Attack()
    {
        _behavior.Attack();
    }
}
