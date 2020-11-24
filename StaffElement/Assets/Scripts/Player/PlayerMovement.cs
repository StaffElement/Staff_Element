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
 
    private Rigidbody2D rb;
    private GameplayInputController inputSystem;
    private bool isGround;
    private float jumpTimeCounter;
    private bool isJumping;

    public bool IsGround { get => isGround; set => isGround = value; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputSystem = GetComponent<GameplayInputController>();

        inputSystem.OnMoveButtonPressed += (inputAxis) => Moving(inputAxis);
        inputSystem.OnJumpButtonReleased += JumpingKeyUp;
        inputSystem.OnJumpButtonPressed += JumpingKeyOn;
    }

    private void Moving(float inputAxis)
    {
        // TODO: Moving Implement Here
        transform.position += new Vector3(inputAxis * moveSpeed * Time.deltaTime, 0, 0);
        OnMoving?.Invoke();
    }

    private void JumpingKeyUp()
    {
        isJumping = false;
    }

    private void JumpingKeyOn()
    {
        // TODO: Jumping Implement Here
        if (IsGround )
        {
            isJumping = true;
            //limit player hold space time
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (isJumping)
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
        OnJumping?.Invoke(); 
    }
}
