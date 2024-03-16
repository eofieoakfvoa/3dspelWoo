using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : WeaponClass
{
    //! Ta bort denna fil tror jag?, eftersom vapnena är så annurlunda så hjälper inte detta.
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
