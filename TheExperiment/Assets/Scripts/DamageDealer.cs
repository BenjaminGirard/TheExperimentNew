using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public bool _isLaunchByPlayer = false;
    [SerializeField]
    private int _damage = 1;

    public int Damage => _damage;
}