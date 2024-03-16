using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : WeaponClass
{
    [SerializeField]
    public float Damage
    {
        get { return _Damage; }
        set { _Damage = value; }
    }
    public override void LeftClickAction()
    {
        Debug.Log("Left Click");
    }
    public override void RightClickAction()
    {
        Debug.Log("Right Click");
    }
}
