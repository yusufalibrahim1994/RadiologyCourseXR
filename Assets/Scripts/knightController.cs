﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knightController : MonoBehaviour
{
    [SerializeField] float speed = 4;
    [SerializeField] float rotSpeed = 80;
    [SerializeField] float gravity = 8;
    [SerializeField] float rot = 0f;

    Vector3 moveDir = Vector3.zero;

    CharacterController controller;
    Animator anim;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
        GetInput();
    }

    void Movement()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.W))
            {
                if(anim.GetBool("attacking") == true)
                {
                    return;
                }
                else if(anim.GetBool("attacking") == false)
                {
                    anim.SetBool("running", true);
                    anim.SetInteger("walkingCondition", 1);
                    moveDir = new Vector3(0, 0, 1);
                    moveDir *= speed;
                    moveDir = transform.TransformDirection(moveDir);
                }
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                anim.SetBool("running", false);
                anim.SetInteger("walkingCondition", 0);
                moveDir = new Vector3(0, 0, 0);
            }
        }
        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
    }

    void GetInput()
    {
        if(controller.isGrounded)
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(anim.GetBool("running") == true)
                {
                    anim.SetBool("running", false);
                    anim.SetInteger("walkingCondition", 0);
                }
                if (anim.GetBool("running") == false)
                {
                    Attacking();
                }
            }
        }
    }
    void Attacking()
    {
        StartCoroutine(AttackRoutine());
    }
    IEnumerator AttackRoutine()
    {
        anim.SetBool("attacking", true);
        anim.SetInteger("walkingCondition", 2);
        yield return new WaitForSeconds(1);
        anim.SetInteger("walkingCondition", 0);
        anim.SetBool("attacking", false);
    }
}