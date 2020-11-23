using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameplayInputController))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public event Action OnMoving;
    public event Action OnJumping;
    public Transform feetpos;
    public float checkRadius;
    public LayerMask whatisground;
   

    [SerializeField]
    private float moveSpeed = 0f;
    [SerializeField]
    private float jumpForce = 0f;

    private Rigidbody2D rb;
    private GameplayInputController inputSystem;
    private bool isGround;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputSystem = GetComponent<GameplayInputController>();

        inputSystem.OnMoveButtonPressed += (inputAxis) => Moving(inputAxis);
        inputSystem.OnJumpButtonPressed += (inputAxis) => Jumping(inputAxis);
    }

    private void Moving(float inputAxis)
    {
        // TODO: Moving Implement Here
        transform.position += new Vector3(inputAxis * moveSpeed * Time.deltaTime, 0, 0);
        OnMoving?.Invoke();
    }

    private void Jumping(float inputAxis)
    {
        // TODO: Jumping Implement Here
        isGround = Physics2D.OverlapCircle(feetpos.position, checkRadius, whatisground);
        if (isGround==true && inputAxis == 1)
        {
            isJumping = true;
            //limit player hold space time
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (inputAxis == 1 && isJumping==true)
        {
            //check jumpTimeCounter less 0 or larger 0
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if(inputAxis == 0)
        {
            isJumping = false;
        }

        OnJumping?.Invoke(); 
    }
}
