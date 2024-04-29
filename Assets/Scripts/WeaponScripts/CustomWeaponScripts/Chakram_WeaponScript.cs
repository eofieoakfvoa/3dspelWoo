using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chakram_WeaponScript : WeaponClass 
{
    [SerializeField]
    public float Damage
    {
        get { return _Damage; }
        set { _Damage = value; }
    }
    public override void LeftClickAction()
    {
        
    }
    public override void RightClickAction()
    {
     
        Debug.Log("Right Click");

    }
}
