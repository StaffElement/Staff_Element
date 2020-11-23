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

    private Rigidbody2D rb;
    private GameplayInputController inputSystem;

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
        OnJumping?.Invoke();
    }
}
