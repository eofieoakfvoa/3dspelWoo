using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealingDamageObject : MonoBehaviour
{
    [SerializeField] private float Integer;
    [SerializeField] HealthSystem.Type type;
    void OnCollisionEnter(Collision collision)
    {
        GameObject collidedGameObject = collision.gameObject;
        if (collidedGameObject.CompareTag("Player"))
        {
            collidedGameObject.GetComponent<HealthSystem>().ChangeHealth(type, Integer);
        }
    }
}
