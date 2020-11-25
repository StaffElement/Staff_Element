using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameplayInputController))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0f;
    [SerializeField]
    private float jumpForce = 0f;
    [SerializeField]
    public float jumpTime = 0f;
 
    private Rigidbody2D rb;
    private GameplayInputController gameplayInput;
    private bool isGround;
    private float jumpTimeCounter;
    private bool isMoving;
    private bool isJumping;

    public bool IsGround { get => isGround; set => isGround = value; }
    public bool IsMoving { get => isMoving; set => isMoving = value; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameplayInput = GetComponent<GameplayInputController>();

        gameplayInput.OnMoveButtonPressed += (inputAxis) => Moving(inputAxis);
        gameplayInput.OnJumpButtonPressed += JumpingKeyOn;
        gameplayInput.OnJumpButtonReleased += JumpingKeyUp;
    }

    private void Moving(float inputAxis)
    {
        // TODO: Moving Implement Here
        transform.position += new Vector3(inputAxis * moveSpeed * Time.deltaTime, 0, 0);

        if (inputAxis > 0)
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        else
            transform.eulerAngles = new Vector3(0f, 180f, 0f);

        isMoving = true;
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
    }
}
