using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponAttatchment : MonoBehaviour
{
    // Ta in vapnet och person, Försök hitta Handle, och Hand, Beroende på hur många som ska attachas 1 eller 2 ksk fler?, Handles "Up" Bör vara vart fingrarna ska vara och dens down ska vara där palm ska vara (jag hoppas). 
    [SerializeField] GameObject Target;
    [SerializeField] GameObject WeaponPrefab;
    [SerializeField] int Amount;
    [SerializeField] bool testfunction;
    List<GameObject> CurrentWeapons = new();
    List<Transform> Hands = new();
    List<string> AvailableHands = new()
    {
        "L",
        "R"
    };
    GameObject Handle;
    GameObject Weapon;
    void Start()
    {

        try
        {
            if (Hands.Count == 0)
            {
                foreach (Transform child in Target.transform.GetComponentsInChildren<Transform>())
                {
                    if (child.gameObject.name == "palm.R" || child.gameObject.name == "palm.L")
                    {
                        Hands.Add(child);
                    }
                }
            }


        }
        catch (Exception e)
        {
            print(e);
        }
    }
    void Update()
    {
        if (CurrentWeapons.Count != 0)
        {
            try
            {
                foreach (GameObject weapons in CurrentWeapons)
                {
                    if (weapons.name.Contains(".L"))
                    {
                        Vector3 distance = Hands[0].position - weapons.transform.Find("Handle").transform.position;
                        weapons.transform.position += distance;
                    }
                    if (weapons.name.Contains(".R"))
                    {
                        Vector3 distance = Hands[1].position - weapons.transform.Find("Handle").transform.position;
                        weapons.transform.position += distance;
                    }
                }
                //gör detta för att offset mellan handle och hand alltid ska vara 0,0,0
            }
            catch
            {

            }
        }
        if (testfunction == true)
        {
            AttachWeapon();
            testfunction = false;
        }
    }
    public void AttachWeapon()
    {
        foreach (GameObject weapon in CurrentWeapons)
        {
            //weaponname - weaponname = L / R sen använd det istället
            if (weapon.name.Contains(".L"))
            {
                AvailableHands.Add("L");
            } 
            if (weapon.name.Contains(".R"))
            {
                AvailableHands.Add("R");
            } 
            CurrentWeapons.Remove(weapon);
            Destroy(weapon);
        }

        for (int i = 0; i < Amount; i++)
        {            
            Weapon = Instantiate(WeaponPrefab);
            Handle = Weapon.transform.Find("Handle").gameObject;
            if (AvailableHands.Count != 0)
            {
                if (AvailableHands[0].Contains("L"))
                {
                    Weapon.name += ".L";
                    Weapon.transform.parent = Hands[0];
                    AvailableHands.Remove("L");
                }
                else
                {
                    Weapon.name += ".R";
                    Weapon.transform.parent = Hands[1];
                    AvailableHands.Remove("R");
                }
            }
            
            CurrentWeapons.Add(Weapon);
        }

    }
}
