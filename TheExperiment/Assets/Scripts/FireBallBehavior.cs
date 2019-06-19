using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallBehavior : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _targetPos;
    private Vector2 _normalizedDir;

    // Start is called before the first frame update
    void Start()
    {
        _targetPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
        Vector3 difference = _targetPos - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        _normalizedDir = (_targetPos - transform.position).normalized;
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)_normalizedDir * _speed * Time.deltaTime;
    }
}
