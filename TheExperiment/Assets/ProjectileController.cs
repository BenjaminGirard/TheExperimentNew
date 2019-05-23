using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{

    public bool isFiring;

    public Bullet bullet;
    public float bulletSpeed;

    public float timeBetweenShots;
    private float shotCounter;

    public Transform firePoint;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFiring)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                Bullet newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
                newBullet.gameObject.SetActive(true);
                newBullet.speed = bulletSpeed;
                print("je rentre");
            }
        }
        else
        {
            shotCounter = 0;
        }


    }
}
