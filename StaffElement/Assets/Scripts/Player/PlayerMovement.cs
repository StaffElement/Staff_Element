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

    [SerializeField]
    private float moveSpeed = 0f;
    [SerializeField]
    private float jumpForce = 0f;
    [SerializeField]
    public float jumpTime = 0f;
    [SerializeField]
    private float checkRadius = 0f;
    [SerializeField]
    private Transform feetPosition;
    [SerializeField]
    private LayerMask whatisground;

    private Rigidbody2D rb;
    private GameplayInputController inputSystem;
    private bool isGround;
    private float jumpTimeCounter;
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

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(feetPosition.position, checkRadius);
    }

    private void Jumping(float inputAxis)
    {
        // TODO: Jumping Implement Here
        isGround = Physics2D.OverlapCircle(feetPosition.position, checkRadius, whatisground);
        if (isGround && inputAxis >= 0)
        {
            isJumping = true;
            //limit player hold space time
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (inputAxis == 1 && isJumping)
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

        if (inputAxis == 0)
        {
            isJumping = false;
        }

        OnJumping?.Invoke(); 
    }
}
