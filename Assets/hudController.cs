using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hudController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject healthVignette;
    [SerializeField] GameObject manaVignette;
    [SerializeField] HealthSystem playerHealthSystem;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthVignette.SetActive(playerHealthSystem.GetHealth() <= 1);
    }
}
