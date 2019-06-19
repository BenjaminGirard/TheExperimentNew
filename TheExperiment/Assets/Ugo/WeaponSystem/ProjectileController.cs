using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{

    public bool isFiring;

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
            
                Bullet newBullet = Instantiate(bullet, this.transform.position, this.transform.rotation);
                newBullet.gameObject.SetActive(true);
                newBullet.speed = bulletSpeed;
            
        }
        
        

    }
}
