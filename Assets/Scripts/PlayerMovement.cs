using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Movement Variables")]
    [SerializeField] private int MovementMode;
    [SerializeField] GameObject mainCamera;
    protected int movementSpeed = 20;
    protected float horizontalMovement;
    protected float verticalMovement;
    private Vector3 MoveDirection;
    private int stepUpHeight;
    private int cameraMode = 1;

    [Header("Jump Variables")]
    [SerializeField] Transform groundChecker;

    [SerializeField] float groundRadius = 1f;

    [SerializeField] LayerMask groundLayer;

    bool isGrounded;

    [Header("Extras")]
    protected float airHangTime;
    protected float JumpForce = 10;

    protected Rigidbody playerRigidBody;
    protected Animator Animator;



    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {

        if (Physics.OverlapBox(groundChecker.position, new Vector3(groundRadius, 0.1f, groundRadius), Quaternion.identity, groundLayer).Length > 0)
        {
            isGrounded = true;
            playerRigidBody.drag = 2f;
        }
        else
        {
            isGrounded = false;
            playerRigidBody.drag = 1f;
        }
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            OnJump();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            cameraMode = 2;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            cameraMode = 1;
        }

        //ksk istället för att använda dessa så har jag i en animation controller som har olika states, "Running, Walking, Idle, Jumping, Falling" och mer.
        Animator.SetFloat("Speed", playerRigidBody.velocity.magnitude);
        Animator.SetBool("IsGrounded", isGrounded);
    }
    void FixedUpdate()
    {
        OnMovement();
    }

    private void OnJump()
    {
        //Lägg till Hang Time I luften, Fire medans man åker uppåt stoppar en från att åka högre, bara när man gör en action i luften dock..
        //Gör så den man faller långsamare när man börja närma sig marken, för en mer gracefull landing
        playerRigidBody.AddForce(Vector2.up * JumpForce, ForceMode.Impulse);

    }
    private void OnMovement()
    {
        playerRigidBody.AddForce(movementSpeed * Time.deltaTime * MoveDirection.normalized, ForceMode.Impulse);
        Vector3 forwardDirection = transform.forward;
        Vector3 rightDirection = transform.right;

        if (cameraMode == 1)
        {
            forwardDirection = mainCamera.transform.forward;
            forwardDirection.y = 0;
            rightDirection = mainCamera.transform.right;
            rightDirection.y = 0;
            transform.rotation = Quaternion.LookRotation(MoveDirection.normalized);
        }

        MoveDirection = forwardDirection * verticalMovement + rightDirection * horizontalMovement;
    }
    private void OnFire()
    {

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundChecker.position, new Vector3(groundRadius, 0.1f, groundRadius));
    }

}
