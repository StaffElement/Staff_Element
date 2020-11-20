using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public event Action<float> OnMoveButtonPressed; 
    public event Action<float> OnJumpButtonPressed;
    public event Action OnLeftClick;
    public event Action OnRightClick;

    private void Update()
    {
        // Left Click event:
        if (Input.GetMouseButtonDown(0)) OnLeftClick?.Invoke();

        // Right Click event:
        if (Input.GetMouseButtonDown(2)) OnRightClick?.Invoke();
    }

    private void FixedUpdate()
    {
        // Moving event:
        if (Input.GetAxis("Horizontal") != 0) OnMoveButtonPressed?.Invoke(Input.GetAxis("Horizontal"));

        // Jumping event:
        if (Input.GetAxis("Jump") != 0) OnJumpButtonPressed?.Invoke(Input.GetAxis("Horizontal"));
    }
}
