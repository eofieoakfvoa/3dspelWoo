using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class RangedWeapon : WeaponClass
{
    private float _Range;
    private float? _Zoom;

    [SerializeField]
    public float Damage
    {
        get { return _Damage; }
        set { _Damage = value; }
    }
    [SerializeField]
    public float Range
    {
        get { return _Range; }
        set { _Range = value; }
    }
    [SerializeField]
    public float? Zoom
    {
        get { return _Zoom; }
        set { _Zoom = value; }
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
