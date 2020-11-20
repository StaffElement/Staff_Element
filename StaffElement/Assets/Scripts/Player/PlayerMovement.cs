using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputSystem))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public event Action OnMoving;
    public event Action OnJumping;

    [SerializeField]
    private float moveSpeed = 0f;
    [SerializeField]
    private float jumpForce = 0f;

    private Rigidbody2D rb;
    private InputSystem inputSystem;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputSystem = GetComponent<InputSystem>();

        inputSystem.OnMoveButtonPressed += (inputAxis) => Moving(inputAxis);
        inputSystem.OnJumpButtonPressed += (inputAxis) => Jumping(inputAxis);
    }

    private void Moving(float inputAxis)
    {
        // TODO: Moving Implement Here
        OnMoving?.Invoke();
    }

    private void Jumping(float inputAxis)
    {
        // TODO: Jumping Implement Here
        OnJumping?.Invoke();
    }
}
