﻿using System.Collections;


using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{
    #region Variables
    #region Input Vars
    float horizontalInput, verticalInput;

    bool jumping = false;

    [Range(1, 100)]
    [SerializeField]
    float jumpPower = 50;
    #endregion Input Vars

    #region Physics Vars
    float gravity;

    bool grounded;

    float accelerationTimeGrounded, accelerationTimeAirborne;

    [Range(1, 100)]
    [SerializeField]
    float groundedTraction = 50, airialTraction = 20;

    [Range(1, 300)]
    [SerializeField]
    float fallSpeed = 100;
    #endregion Physics Vars

    #region Speed Vars
    [Range(0.1f, 100f)]
    [SerializeField]
    float speed;
    #endregion Speed Vars
    #endregion Variables

    [HideInInspector] public Vector2 velocity;
    Controller2D controller;

    private void Start()
    {
        controller = GetComponent<Controller2D>();
    }

    private void Update()
    {
        BasicMovement();
        DetectJumping();
        ColPhysChecks();

        if(velocity.y > 0) print(velocity);
    }

    private void BasicMovement()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        velocity.x = input.x * speed;
    }

    void DetectJumping()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (controller.collisions.below && !jumping)
            {
                jumping = true;
                velocity.y = jumpPower;
            }
        }
    }

    void ColPhysChecks()
    {
        grounded = controller.collisions.below;

        gravity = -fallSpeed * 2f;
        accelerationTimeGrounded = 1f / groundedTraction;
        accelerationTimeAirborne = 1f / airialTraction;

        velocity.y += gravity * Time.deltaTime;

        if (controller.collisions.isAirborne()) jumping = false;

        if ((controller.collisions.below && !jumping) ||
            controller.collisions.above)
        {
            velocity.y = 0;
        }
        
        controller.Move(velocity * Time.deltaTime);
    }
}
