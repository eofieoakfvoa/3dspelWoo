using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public WeaponClass Weapon;
    // ! lägg de här i en PlayerController script
    void Update()
    {
        if (Weapon != null)
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

    
}
