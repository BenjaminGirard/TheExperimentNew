using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 100f;
    private Vector3 v;
    float destroyTime = 5;
    public bool isShotGun = false;
    public bool isCannon = false;
    private int _enemyCount;



    void Start()
    {
        Destroy(gameObject, isShotGun ? 1 : destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            _enemyCount++;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isCannon && other.gameObject.CompareTag("Enemy") && _enemyCount == 4)
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }        
    }
}
