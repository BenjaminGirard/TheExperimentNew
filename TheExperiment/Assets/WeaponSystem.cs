using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    private Camera mainCamera;
    public GameObject projectile;
    public ProjectileController pController;

    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
        //projectile = GameObject.FindGameObjectWithTag("ClassicProjectile");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1000f));
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
        rot.x = transform.rotation.x;
        rot.y = transform.rotation.y;
        transform.rotation = rot;

        if (Input.GetMouseButtonDown(0))
        {
            print("coucou");
            pController.isFiring = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            pController.isFiring = false;

        }


    }

   
}
