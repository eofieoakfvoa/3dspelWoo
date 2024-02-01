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
    List<Transform> Hands = new();
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
                        print(child.gameObject.name);
                        Hands.Add(child);
                    }
                }
            }
            print(Hands.Count);
            Weapon = Instantiate(WeaponPrefab);
            Handle = Weapon.transform.Find("Handle").gameObject;
            Weapon.transform.parent = Hands[0];
            
            //GameObject Hand =  Target.transform.Find("ORG-palm.02.R").gameObject;
        }
        catch(Exception e)
        {
            print(e);
        }
    }
    void Update()
    {
        
        try
        {
            //gör detta för att offset mellan handle och hand alltid ska vara 0,0,0
            Vector3 distance = Hands[0].position - Handle.transform.position;
            Weapon.transform.position += distance;
            print(distance);
        }
        catch
        {

        }
    }
}
