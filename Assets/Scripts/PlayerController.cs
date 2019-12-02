using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 moveVector = Vector3.zero;

    private CharacterController controller;
    private float verticalVelocity;
    [SerializeField] float gravity = 14.0f;
    [SerializeField] float jumpForce = 100f;
    [SerializeField] float horizontalSpeed;
    [SerializeField] float verticalSpeed;
    bool isGrounded = true;
    //Variables
    [SerializeField] int forceConst;
    Rigidbody playerRB;
    Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessMovement();
        ProcessJump();
     
        print(controller.isGrounded);

    }

    void ProcessMovement()
    {
        /* float verticalThrow = Input.GetAxis("Vertical");
         float horizontalThrow = Input.GetAxis("Horizontal");
         playerRB.AddForce(Vector3.forward * verticalThrow * 100);
         transform.Translate(Vector3.forward * verticalThrow); */
        Vector3 moveVector = Vector3.zero;
        moveVector.x = Input.GetAxis("Horizontal")*horizontalSpeed;
        moveVector.y = verticalVelocity;
        moveVector.z = Input.GetAxis("Vertical")*verticalSpeed;
        controller.Move(moveVector * Time.deltaTime);
        if (moveVector.z > 0 || moveVector.z < 0)
        {
            transform.Translate(Vector3.forward * moveVector.z);
            playerAnimator.SetBool("isWalking", true);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerAnimator.SetBool("isRunning", true);
                playerAnimator.SetBool("isJumping", true);
            }
            else
            {
                playerAnimator.SetBool("isRunning", false);
            }
        }
        else
        {
            playerAnimator.SetBool("isWalking", false);
        }
        if (moveVector.x != 0)
        {
            transform.Rotate(Vector3.up * moveVector.x);
        }
    }

    void ProcessJump()
    {
        if (transform.position.y > 0 && transform.position.y < 1.5f)
        {
            isGrounded = true;
        }
        else {
            isGrounded = false;
            
            print(Input.GetAxis("Jump"));
        }

        //if (Input.GetAxis("Jump") > 0)
       // {
            if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = -gravity * Time.deltaTime;
                playerAnimator.SetBool("isJumping", true);
            playerAnimator.SetBool("isFalling", true);
            print("Jump");
               // playerAnimator.SetBool("isJumping", true);
                verticalVelocity = jumpForce;
            }
            else
            {
           playerAnimator.SetBool("isJumping", false);
            playerAnimator.SetBool("isFalling", false);
            verticalVelocity -= gravity * Time.deltaTime;
            }


        //playerAnimator.SetBool("isJumping", false);
        // }
        //else
        //{

        // }

    }
       
    }


