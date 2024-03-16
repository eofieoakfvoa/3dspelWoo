using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class WeaponController : MonoBehaviour
{
    private WeaponClass weaponType;
    public void SetWeaponType(WeaponClass type)
    {
        weaponType = type;
    }
    

}
