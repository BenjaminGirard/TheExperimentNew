using System.Collections;
using System.Collections.Generic;
using QInventory;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [HideInInspector]
    public ItemData WeaponEquiped;

    private void Update()
    {
        if (WeaponEquiped)
        {
            // do something
        }
    }
    
    void TaskOnClick()
    {
        //Output this to console when Button1 or Button3 is clicked
        Debug.Log("You have clicked the button!");
    }

}
