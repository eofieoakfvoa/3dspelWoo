using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{


    private float _x;
    private float _y;
    [SerializeField] private float _Sensitivity;
    [SerializeField] private Transform _Focus;
    [SerializeField] public float DistancefromTarget;
    [SerializeField] float groundRadius = 1f;

    [SerializeField] LayerMask groundLayer;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Transform Player = GameObject.FindGameObjectWithTag("Player").transform;  
        _Focus.position = new Vector3(Player.position.x, Player.position.y + 1  , Player.position.z); 
        float mouseX = Input.GetAxis("Mouse Y") * _Sensitivity;
        float mouseY = Input.GetAxis("Mouse X") * _Sensitivity;

        //Fixa så att karaktären blir transparent till slut desto närmare den är cameran/väggen
        if (Physics.Linecast(transform.position, Player.position, groundLayer))
        {
            DistancefromTarget = 1;
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out RaycastHit hitInfo, 3, groundLayer))
        {
            if (hitInfo.distance < 1 && DistancefromTarget > 1)
            {
                DistancefromTarget -=0.1f;
            }
        }
        else
        {
            if (DistancefromTarget < 3)
            {
                DistancefromTarget +=0.1f;
            }
        }
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * 10, Color.yellow);


        _y += mouseY;
        _x += mouseX;
        _x = Mathf.Clamp(_x, -40, 40);
        transform.localEulerAngles = new Vector3(_x,_y,0);

        transform.position = _Focus.position - transform.forward * DistancefromTarget;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(groundRadius, 0.3f, groundRadius));
    }
}
