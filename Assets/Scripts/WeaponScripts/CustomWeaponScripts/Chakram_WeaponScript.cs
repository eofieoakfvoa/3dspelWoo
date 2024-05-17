using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cakram_WeapohnScript : MeleeWeapon 
{
    public override void LeftClickAction()
    {
        if(ComboAttacks.Count == 0)
        {
            ComboAttacks.Add(1);
            ComboAttacks.Add(2);
            ComboAttacks.Add(3);
            ComboAttacks.Add(4);
        }
        base.LeftClickAction();
    }
}