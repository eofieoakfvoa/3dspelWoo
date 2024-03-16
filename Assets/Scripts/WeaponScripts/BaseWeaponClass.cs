using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Composites;

public class WeaponClass : MonoBehaviour
{
    // * lägg till error catching
    public PlayerCombat playerCombat;
    protected float _Damage;
    public GameObject player;
    public WeaponClass()
    {
        //skaffa player här ifrån vet inte varför jag inte tänkte på att constructors fungerar i unity...
    }
    void Awake()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerCombat = player.GetComponent<PlayerCombat>();            
        }
        
    }
    //Since the game is using multiple weapons that vary from Melee to Ranged, I have implemented a polymorphism way, where the weapon will implement their own code using the Melee and Ranged Script
    public virtual void LeftClickAction(){}
    public virtual void RightClickAction(){}
    public void OnEquip(WeaponClass Weapon)
    {
        playerCombat.Weapon = Weapon;
    }

}
