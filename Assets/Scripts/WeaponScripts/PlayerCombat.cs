using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private WeaponClass _Weapon;
    // ! lägg de här i en PlayerController
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {            
            _Weapon.LeftClickAction();
        }
        if (Input.GetButtonDown("Fire2"))
        {            
            _Weapon.RightClickAction();
        }
    }

    
}
