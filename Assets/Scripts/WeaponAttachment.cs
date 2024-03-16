using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponAttachment : MonoBehaviour
{
    // Ta in vapnet och person, Försök hitta Handle, och Hand, Beroende på hur många som ska attachas 1 eller 2 ksk fler?, Handles "Up" Bör vara vart fingrarna ska vara och dens down ska vara där palm ska vara (jag hoppas). 


    //gör så att man kan ha mer en 2 vapen
    //Current bugs, Ifall karaktären är faced ett annat hål en hållet som vapnena är skapad när de blir assigned så blir det inte en initial rotation, och därför är de konstant ungefär 0-90 grader off
    //Ifall jag pallar ta bort SerializeField och bara gör den hitta "Player" Tagen sen sett gameobject i start()
    [SerializeField] GameObject Target;
    [SerializeField] GameObject weaponPrefab;
    [SerializeField] int amountOfWeapons;
    [SerializeField] bool testfunction; // tabort sen, just nu används för att snabbt ge vapen med SerializeField
    List<GameObject> currentWeapons = new();
    List<Transform> Hands = new();
    List<string> availableHands = new() { "L", "R" };

    void Start()
    {
        GetHands(); //Ifall Gethands inte fungerar betyder det att personen inte har händer därför behövs det ingen error catching? hoppas jag lol, eller så existerar inte Han.
    }
    void Update()
    {
        UpdateWeaponPosition();
        if (testfunction == true)
        {
            AttachWeapon(weaponPrefab, weaponPrefab.GetComponent<WeaponClass>());
            testfunction = false;
        }
    }

    private void GetHands()
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


    private void UpdateWeaponPosition()
    {
        //gör detta för att offset mellan handle och hand alltid ska vara 0,0,0
        //Annars följer den inte med i animationer.
        //Måste dock hitta ett sätt så jag inte behöver uppdatera positionen hela tiden
        foreach (GameObject weapons in currentWeapons)
        {
            if (weapons.name.Contains(".L"))
            {
                Vector3 distance = Hands[0].position - weapons.transform.Find("Handle").transform.position;
                weapons.transform.position += distance;
            }
            else if (weapons.name.Contains(".R"))
            {
                Vector3 distance = Hands[1].position - weapons.transform.Find("Handle").transform.position;
                weapons.transform.position += distance;
            }
        }
    }

    public void AttachWeapon(GameObject WeaponToChangeToo, WeaponClass weaponClass)
    {
        weaponPrefab = WeaponToChangeToo;
        ClearWeapons();
        GameObject newWeapon;
        for (int i = 0; i < amountOfWeapons; i++)
        {
            newWeapon = Instantiate(weaponPrefab);
            Transform handle = newWeapon.transform.Find("Handle");

            newWeapon.GetComponent<WeaponClass>().OnEquip(weaponClass);
            AssignToHand(newWeapon);
            currentWeapons.Add(newWeapon);
        }
    }

    private void AssignToHand(GameObject weapon)
    {
        string handToUse = availableHands[0];
        availableHands.RemoveAt(0);
        weapon.name += "." + handToUse;
        //condition ? consequent : alternative = Ternary expression, ifall en condition är san så använder den den första annars den andra
        //som i detta fall betyder ifall handToUse = 1 så använder den hand[0] och eftersom det kan vara L eller R, så är det basically en else där efter, skulle inte fungera ifall man hade 3 händer
        //https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator
        weapon.transform.parent = Hands[handToUse == "L" ? 0 : 1];
    }
    private void ClearWeapons()
    {
        foreach (GameObject weapon in currentWeapons)
        {
            Destroy(weapon);
        }
        currentWeapons.Clear();
        availableHands.Clear();
        availableHands.Add("L");
        availableHands.Add("R");
    }
}
