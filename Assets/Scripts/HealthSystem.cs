using System.Collections;
using System.Collections.Generic;
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
        
    }
    public void GiveHealth(float healthToAdd) //Function to Give health // healing
    {

    }
    public void ChangeMaxHealthValue(float ValueChange) //Change the MaxHealth Variable
    {
        
    }

}
