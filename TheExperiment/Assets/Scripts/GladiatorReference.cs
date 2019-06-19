using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GladiatorReference : MonoBehaviour
{
    private HealthManager _healthManager;

    private GladiatorBehavior _gladiatorBehavior;
    // Start is called before the first frame update
    void Start()
    {
        _gladiatorBehavior = transform.GetComponentInParent<GladiatorBehavior>();
        _healthManager = transform.GetComponentInParent<HealthManager>();
    }

    public void Die()
    {
        _healthManager.Die();
    }

    public void Attack()
    {
        _gladiatorBehavior.Attack();
    }

    public void AttackEnd()
    {
        _gladiatorBehavior.AttackEnd();
    }
}
