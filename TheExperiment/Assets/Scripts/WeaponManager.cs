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
        //Output this to console when Button1 or Button3 is clicked
        Debug.Log("You have clicked the button!");
    }

    public void EquipItem(ItemData weapon)
    {
        isWeaponEquiped = true;
        WeaponEquiped = weapon;
    }    
}
