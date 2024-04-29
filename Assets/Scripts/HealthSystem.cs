using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float currentHealth; 
    public void Awake()
    {
        if (maxHealth > 0)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth = 1;
        }
    }
    public void TakeHealth(float damageToAdd) //Function to Take Health // Dealing Damage
    {
        if (damageToAdd > 0)
        {
            currentHealth -= damageToAdd;
            if (currentHealth <= 0)
            {
                print("Is Dead"); // Ha någon typ av Death State, I guess jag borde typ ha En player Och Enemycontroller som har egna HandleDeaths() som blir callat här ifrån
            }
        }
        else
        {
            print("Took 0 or negative damage");
        }
    }
    public void GiveHealth(float healthToAdd) //Function to Give health // healing
    {
        if (healthToAdd > 0)
        {
            currentHealth += healthToAdd;
            if (currentHealth > maxHealth) //Overheal
            {
                currentHealth = maxHealth;
            }
        }
        else
        {
            print("Healing done was either 0 or negative");
        }
    }
    public void ChangeMaxHealthValue(float ValueChange) //Change the MaxHealth Variable
    {
        maxHealth += ValueChange; //Negative value to decrease max health, postive to increase max health
        if (maxHealth <= 0)
        {
            maxHealth = 1;
        } 
    }

}
