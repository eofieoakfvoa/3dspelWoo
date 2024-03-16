using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponClass
{
    private PlayerCombat playerCombat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();
    protected float _Damage;
    //Since the game is using multiple weapons that vary from Melee to Ranged, I have implemented a polymorphism way, where the weapon will implement their own code using the Melee and Ranged Script
    public virtual void LeftClickAction(){}
    public virtual void RightClickAction(){}
    public void OnEquip(WeaponClass Weapon)
    {
        playerCombat.Weapon = Weapon;    
    }

}
