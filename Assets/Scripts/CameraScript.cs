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
        if (Physics.OverlapBox(transform.position, new Vector3(groundRadius, 0.3f, groundRadius), Quaternion.identity, groundLayer).Length > 0)
        {
            DistancefromTarget-= 0.1f;
        }
        else
        {
            if (DistancefromTarget <= 3)
            {
                DistancefromTarget+= 0.1f;
            }
            print("notHit");

        }
        Transform Player = GameObject.FindGameObjectWithTag("Player").transform;  
        _Focus.position = new Vector3(Player.position.x, Player.position.y + 1  , Player.position.z); 
        float mouseX = Input.GetAxis("Mouse Y") * _Sensitivity;
        float mouseY = Input.GetAxis("Mouse X") * _Sensitivity;
        
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
