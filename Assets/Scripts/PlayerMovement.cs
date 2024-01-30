using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    protected int movementSpeed = 10;
    protected float horizontalMovement;
    protected float verticalMovement;
    private Vector3 MoveDirection;
    private int StepUpHeight;

    
    protected float airHangTime;
    protected float JumpForce = 10;


    public Rigidbody playerRigidBody;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnJump();
        }
    }
    void FixedUpdate()
    {
        OnMovement();
    }

    public void OnJump()
    {
        print("WAA");
        playerRigidBody.AddForce(Vector2.up * JumpForce, ForceMode.Impulse);
    }
    public void OnMovement()
    {
        MoveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;
        playerRigidBody.AddForce(movementSpeed * Time.deltaTime * MoveDirection.normalized, ForceMode.Impulse);
    }
    public void OnFire()
    {

    }
}
