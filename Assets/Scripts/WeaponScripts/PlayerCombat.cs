using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public WeaponClass Weapon;
    // ! lägg de här i en PlayerController
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {            
            Weapon.LeftClickAction();
        }
        if (Input.GetButtonDown("Fire2"))
        {            
            Weapon.RightClickAction();
        }
    }

    
}
