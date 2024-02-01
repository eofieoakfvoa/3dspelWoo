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
    protected int movementSpeed = 10;
    protected float horizontalMovement;
    protected float verticalMovement;
    private Vector3 MoveDirection;
    private int stepUpHeight;


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
            playerRigidBody.drag = 0.5f;
        }
        else
        {
            isGrounded = false;
            playerRigidBody.drag = 0f;
        }
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            OnJump();
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
        // Långsamare när man strafear eller går bakåt.
        if (MovementMode == 1)
        {
            MoveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;
            playerRigidBody.AddForce(movementSpeed * Time.deltaTime * MoveDirection.normalized, ForceMode.Impulse);

            Vector3 flatVelocity = new(playerRigidBody.velocity.x, 0f, playerRigidBody.velocity.z);
            if (flatVelocity.magnitude > movementSpeed)
            {
                Vector3 limitedVelocty = flatVelocity.normalized * movementSpeed;
                playerRigidBody.velocity = new Vector3(limitedVelocty.x, playerRigidBody.velocity.y, limitedVelocty.z);
            }

        }
        //Mode två ska vara att cameran har ingen påvärkan på movementen, förns man klickar på höger klick och då blir W hållet där man kollar
        if (MovementMode == 2)
        {
            
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
