using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    private GameplayInputController gameplayInput;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        gameplayInput = GetComponentInParent<GameplayInputController>();
    }

    private void Update()
    {
        animator.SetBool("OnMoving", gameplayInput.IsMoveKeyPressed);
    }
}
