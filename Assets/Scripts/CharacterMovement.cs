using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  

public class CharacterMovement : MonoBehaviour
{

    public Vector3 gravity =Vector3.zero;
    public Vector3 playerVelocity;
    public bool groundedPlayer;
    Vector3 move;
    private float jumpHeight = 1f;
    private float gravityValue = -9.81f;
    private CharacterController controller;
    private Animator animator;
    private float walkSpeed = 5;
    private float runSpeed = 8; 

    Rigidbody m_rigidBody;
    public GameObject respawnPoint;

    public float speed = 2;

    public float mouseSensitivity = 100.0f;
    public Transform playerBody;

    private float jumpPower    = 5f;
    
    private int FlipHash = Animator.StringToHash("FLIP");

    public int score;
    public Text MyText;
    // Vector3 gravity = Vector3.zero;

    private bool abilityDoubleJump;
    public bool AbilityDoubleJump { get => abilityDoubleJump; set { abilityDoubleJump = value; Debug.Log("got") ; } }
 
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        m_rigidBody = GetComponent<Rigidbody>();
        respawnPoint = GameObject.FindGameObjectWithTag("Respawn");

    }

    public void Update()
    {
       ProcessMovement();
       UpdateAnimator();

        // Rotate the player's body based on the horizontal mouse movement
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        playerBody.Rotate(Vector3.up * mouseX);

        // Rotate the camera based on the vertical mouse movement
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        transform.Rotate(-mouseY, 0, 0);
       
    }

    public void RespawnPlayer()
    {
        transform.position = respawnPoint.transform.position;
    }

    void UpdateAnimator()
    {
        if (move.magnitude == 0.0f)
        {
            animator.SetFloat("CharacterSpeed",0.0f);
        }
        else if (move.magnitude > 0.0f)
        {
             if (Input.GetButton("Fire3"))// Left shift
            {
                animator.SetFloat("CharacterSpeed",1.0f);
            }
            else
            {
                animator.SetFloat("CharacterSpeed",0.5f);
            }

        }
        
    }

    void ProcessMovement()
    { 
        // Moving the character foward according to the speed
        float speed = GetMovementSpeed();

        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // Turning the character
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
        // Making sure we dont have a Y velocity if we are grounded
        // controller.isGrounded tells you if a character is grounded ( IE Touches the ground)
        groundedPlayer = controller.isGrounded;
        
        if (groundedPlayer)
        {
            if (Input.GetButtonDown("Jump") &&groundedPlayer )
            {
                gravity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);

            }else if(Input.GetKeyDown(KeyCode.Space) && animator.GetCurrentAnimatorStateInfo(0).IsName("Jump") && abilityDoubleJump)
            {
                abilityDoubleJump = false;
                gravity = Vector3.up * jumpPower ;
                animator.SetTrigger(FlipHash);
                EffectManager.instance.JumpEffect(transform.position + Vector3.up *  0.3f); 
            }else if(groundedPlayer)
            {
                // Dont apply gravity if grounded and not jumping
                gravity.y = -1.0f;
            }
            else 
            {
                // Since there is no physics applied on character controller we have this       applies to reapply gravity if the character is falling ( IE Not grounded )
                gravity.y += gravityValue * Time.deltaTime;
            }
        }
        else 
        {
            // Since there is no physics applied on character controller we have this applies to reapply gravity
            gravity.y += gravityValue * Time.deltaTime;
        }  
        playerVelocity = gravity * Time.deltaTime + move * Time.deltaTime * speed;
        controller.Move(playerVelocity);
    }

    float GetMovementSpeed()
    {
        if (Input.GetButton("Fire3"))// Left shift
        {
            return runSpeed;
        }
        else
        {
            return walkSpeed;
        }
    }  
}