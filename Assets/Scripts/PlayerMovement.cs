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


    protected Rigidbody playerRigidBody;
    protected Animator Animator;

    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        Animator = GetComponent<Animator>();
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
        //Lägg till Hang Time I luften, Fire medans man åker uppåt stoppar en från att åka högre
        playerRigidBody.AddForce(Vector2.up * JumpForce, ForceMode.Impulse);
    }
    public void OnMovement()
    {
        // Långsamare när man strafear eller går bakåt.
        MoveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;
        playerRigidBody.AddForce(movementSpeed * Time.deltaTime * MoveDirection.normalized, ForceMode.Impulse);
    }
    public void OnFire()
    {

    }
}
