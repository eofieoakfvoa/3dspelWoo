using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HoverBoxNPC : MonoBehaviour
{
    [SerializeField] private Transform hoverBoxCheckerCenter;
    [SerializeField] private float hoverBoxCheckerRadius;
    [SerializeField] GameObject HoverButtonPrefab;
    [SerializeField] KeyCode Input;
    bool playerInRange;
    GameObject? currentObject;

    void Update()
    {
        playerInRange = false;
        checkIfPlayerIsInRange();
        if (playerInRange == true)
        {
            if (currentObject == null)
            {
                currentObject = Instantiate(HoverButtonPrefab);
                currentObject.transform.position = new Vector3(hoverBoxCheckerCenter.position.x + 0.5f , hoverBoxCheckerCenter.position.y +1, hoverBoxCheckerCenter.position.z -1.5f);
                
            }
        }
        else
        {
            if (currentObject != null){
                Destroy(currentObject);
            }
        }

    }   
    void checkIfPlayerIsInRange()
    {
        Collider[] allCollidersInRange = Physics.OverlapSphere(hoverBoxCheckerCenter.position, hoverBoxCheckerRadius);
        foreach (Collider collider in allCollidersInRange)
        {
            if(collider.CompareTag("Player"))
            {
                playerInRange = true;
                break;
            }
        }
    }
    void checkIfCorrectButtonIsPressed()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(hoverBoxCheckerCenter.position, new Vector3(hoverBoxCheckerRadius, 0.1f, hoverBoxCheckerRadius));
    }
}
