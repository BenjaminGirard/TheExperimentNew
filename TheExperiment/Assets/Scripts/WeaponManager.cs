using System.Collections;
using System.Collections.Generic;
using QInventory;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private bool isWeaponEquiped = false;
    
    [HideInInspector]
    public ItemData WeaponEquiped;

    private void Update()
    {
        if (isWeaponEquiped)
        {
            Debug.Log("Weapon Equiped !");
        }
    }
    
    void TaskOnClick()
    {
        if (!WeaponEquiped) return;
        
       
        
    }

       
}
