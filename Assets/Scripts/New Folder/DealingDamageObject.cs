using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealingDamageObject : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        GameObject collidedGameObject = collision.gameObject;
        if (collidedGameObject.CompareTag("Player"))
        {
            collidedGameObject.GetComponent<HealthSystem>().TakeHealth(0.01f);
        }
    }
}
