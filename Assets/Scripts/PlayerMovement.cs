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
    private int stepUpHeight;


    [SerializeField] Transform groundChecker;

    [SerializeField] float groundRadius = 1f;

    [SerializeField] LayerMask groundLayer;

    protected float airHangTime;
    protected float JumpForce = 10;

    protected Rigidbody playerRigidBody;
    protected Animator Animator;
    bool isGrounded;

    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {

        //bool isGrounded = Physics2D.OverlapBox(groundChecker.position, new Vector2(3, groundRadius), 0, groundLayer);
        if (Physics.OverlapBox(groundChecker.position, new Vector3(groundRadius, 0.1f, groundRadius), Quaternion.identity, groundLayer).Length > 0)
        {
            isGrounded = true;
            playerRigidBody.drag = 0.5f;
        }
        else
        {
            isGrounded = false;
            playerRigidBody.drag = 0f;
        }
        print(isGrounded);
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            OnJump();
        }
    }
    void FixedUpdate()
    {
        OnMovement();
    }

    private void OnJump()
    {
        //Lägg till Hang Time I luften, Fire medans man åker uppåt stoppar en från att åka högre
        playerRigidBody.AddForce(Vector2.up * JumpForce, ForceMode.Impulse);
        
    }
    private void OnMovement()
    {
        // Långsamare när man strafear eller går bakåt.
        MoveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;
        playerRigidBody.AddForce(movementSpeed * Time.deltaTime * MoveDirection.normalized, ForceMode.Impulse);

        Vector3 flatVelocity = new(playerRigidBody.velocity.x, 0f, playerRigidBody.velocity.z);
        if (flatVelocity.magnitude > movementSpeed)
        {
            Vector3 limitedVelocty = flatVelocity.normalized * movementSpeed;
            playerRigidBody.velocity = new Vector3(limitedVelocty.x, playerRigidBody.velocity.y, limitedVelocty.z);
        }
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
