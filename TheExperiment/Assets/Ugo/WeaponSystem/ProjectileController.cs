using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{

    public bool isFiring;
    public bool isShotGun = false;

    public Bullet bullet;
    public float bulletSpeed;

   

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (/*GetComponentInParent<WeaponSystem>().isWeaponEquiped &&*/ isFiring)
        {

            if (isShotGun)
            {
                Bullet newBullet = Instantiate(bullet, this.transform.position, this.transform.rotation);
                newBullet.gameObject.SetActive(true);
                newBullet.speed = bulletSpeed;
                newBullet.isShotGun = true;
                Bullet newBullet1 = Instantiate(bullet, this.transform.position, this.transform.rotation);
                newBullet1.gameObject.SetActive(true);
                newBullet1.speed = bulletSpeed;                
                newBullet1.isShotGun = true;
                Bullet newBullet2 = Instantiate(bullet, this.transform.position, this.transform.rotation);
                newBullet2.gameObject.SetActive(true);
                newBullet2.speed = bulletSpeed;                
                newBullet2.isShotGun = true;
                Bullet newBullet3 = Instantiate(bullet, this.transform.position, this.transform.rotation);
                newBullet3.gameObject.SetActive(true);
                newBullet3.speed = bulletSpeed;                
                newBullet3.isShotGun = true;
                Bullet newBullet4 = Instantiate(bullet, this.transform.position, this.transform.rotation);
                newBullet4.gameObject.SetActive(true);
                newBullet4.speed = bulletSpeed;                
                newBullet4.isShotGun = true;
                newBullet.transform.Rotate(Random.Range(-10,10), Random.Range(-10,10), 0);
                newBullet1.transform.Rotate(Random.Range(-10,10), Random.Range(-10,10), 0);
                newBullet2.transform.Rotate(Random.Range(-10,10), Random.Range(-10,10), 0);
                newBullet3.transform.Rotate(Random.Range(-10,10), Random.Range(-10,10), 0);
                newBullet4.transform.Rotate(Random.Range(-10,10), Random.Range(-10,10), 0);
            }
            else
            {
                Bullet newBullet = Instantiate(bullet, this.transform.position, this.transform.rotation);
                newBullet.gameObject.SetActive(true);
                newBullet.speed = bulletSpeed;                
            }
        }
        
        

    }
}
