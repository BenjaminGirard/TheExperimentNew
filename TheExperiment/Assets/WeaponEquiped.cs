using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QInventory;


public class WeaponEquiped : MonoBehaviour
{
    GameObject curentWeapon;
    bool isWeaponEquiped;
    // Start is called before the first frame update
    void Start()
    {
        isWeaponEquiped = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EquipItem(ItemData weapon)
    {
        if (isWeaponEquiped)
        {
            GameObject.Destroy(curentWeapon);
            //            curentWeapon.SetActive(false);
        }

        isWeaponEquiped = true;
        curentWeapon = GameObject.Instantiate(weapon.item.m_object, GameObject.Find("Player").transform);
        Debug.Log("equip weapon: " + curentWeapon.name);
        curentWeapon.SetActive(true);
    }
}
