using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables
    Rigidbody playerRB;
    Animator playerAnimator;
    float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessMovement();
        ProcessJump();
    }

    void ProcessMovement()
    {
        float verticalThrow = Input.GetAxis("Vertical");
        float horizontalThrow = Input.GetAxis("Horizontal");
        //playerRB.AddForce(Vector3.forward * verticalThrow * 100);
        transform.Translate(Vector3.forward * verticalThrow);
        if(verticalThrow > 0 || verticalThrow <0)
        {
            transform.Translate(Vector3.forward * verticalThrow);
            playerAnimator.SetBool("isWalking", true);
            speed += 0.5f;
            playerAnimator.SetFloat("runSpeed", speed);
        }
        else
        {
            speed = 1.0f;
            playerAnimator.SetFloat("runSpeed", speed);
            playerAnimator.SetBool("isWalking", false);
        }
        if (horizontalThrow != 0)
        {
            transform.Rotate(Vector3.up * horizontalThrow);
        }
    }

    void ProcessJump()
    {
        print(Input.GetAxis("Jump"));
        if(Input.GetAxis("Jump") > 0)
        {
            playerAnimator.SetBool("isJumping", true);
        }
        else
        {
            playerAnimator.SetBool("isJumping", false);
        }
    }
}
