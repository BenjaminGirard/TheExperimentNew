using System.Collections;
using System.Collections.Generic;
using QInventory;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    private Camera mainCamera;
    public GameObject projectile;
    public ProjectileController pController;
    public double fireRate = 1F;
    private double lastShot = 0.0F;

    private Vector3 initialPos;
    private Vector3 initialScale;
    private Vector3 invertScale;



    //  [HideInInspector]
    ///  public bool isWeaponEquiped = false;

    //  [HideInInspector]
    //  public GameObject WeaponEquiped;

    private Animator anim;


    void Start()
    {
        initialPos = this.transform.position;
        initialScale = this.transform.localScale;
        invertScale = initialScale;
        invertScale.x *= -1;
        anim = GetComponentInChildren<Animator>();
        mainCamera = FindObjectOfType<Camera>();
        //projectile = GameObject.FindGameObjectWithTag("ClassicProjectile");
    }

    // Update is called once per frame
    void Update()
    {
//        transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w);

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1000f));




        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
    //    print(rot);

        rot.x = transform.rotation.x;
        if (mousePosition.x < transform.root.position.x)
        {
            transform.position = new Vector3(initialPos.x + -0.5F, initialPos.y, initialPos.z);
            transform.localScale = invertScale;
        }
        else
        {
            transform.position = new Vector3(initialPos.x, initialPos.y, initialPos.z);
            transform.localScale = initialScale;
        }
        rot.y = 0;



        transform.rotation = rot;

        if (Input.GetMouseButton(0) && Time.time > fireRate + lastShot)
        {
            lastShot = Time.time;
            pController.isFiring = true;
            anim.SetBool("IsFiring", true);
        }
        else if (Input.GetMouseButtonUp(0)) 
        {
            anim.SetBool("IsFiring", false);
            pController.isFiring = false;
        }
        else 
        {
            anim.SetBool("IsFiring", false);
            pController.isFiring = false;
        }



    }

   
   
}
