using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayInputController : MonoBehaviour
{
    public event Action<float> OnMoveButtonPressed; 
    public event Action OnJumpButtonPressed;
    public event Action OnJumpButtonReleased;
    public event Action OnLeftClick;
    public event Action OnRightClick;

    private void Update()
    {
        // Left Click event:
        if (Input.GetMouseButtonDown(0)) OnLeftClick?.Invoke();

        // Right Click event:
        if (Input.GetMouseButtonDown(2)) OnRightClick?.Invoke();

        // Moving event:
        if (Input.GetAxis("Horizontal") != 0) OnMoveButtonPressed?.Invoke(Input.GetAxis("Horizontal"));

        // Jumping event:
        // GetkeyUp
        // It is not guaranteed that Input.GetKeyDown() or Input.GetKeyUp() will return true in FixedUpdate() even if the player actually done an action. Docs says:
        // You need to call this function from the Update function, since the state gets reset each frame.It will not return true until the user has released the key and pressed it again.
        if (Input.GetKeyUp(KeyCode.Space)) OnJumpButtonReleased?.Invoke();
        if (Input.GetKey(KeyCode.Space)) OnJumpButtonPressed?.Invoke();
    }

}
