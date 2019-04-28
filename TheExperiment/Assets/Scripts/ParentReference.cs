using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentReference : MonoBehaviour
{
    private HealthManager _healthManager;

    // Start is called before the first frame update
    private void Start()
    {
        _healthManager = GetComponentInParent<HealthManager>();
    }

    public void Die()
    {
        _healthManager.Die();
    }
}
