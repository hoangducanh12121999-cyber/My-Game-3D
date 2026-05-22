using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class PlayerMotionController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform cameraTranform;
    private CharacterController characterController;
    private Animator animator;
    private Vector2 moveInput;
    public float gravity = -9.81f;
    private Vector3 velocity;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void Update()
    {
        Move();
        Animate();
    }
    
    private void Move()
    {
        Vector3 forward = cameraTranform.forward;
        Vector3 right = cameraTranform.right;
        forward.y = 0f;
        right.y = 0f;
        forward = forward.normalized;
        right = right.normalized;

        Vector3 moveDir = (forward * moveInput.y + right * moveInput.x).normalized;
        if (characterController.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(moveDir * moveSpeed * Time.deltaTime);
        characterController.Move(velocity * Time.deltaTime);
        
        
    }

    private void Animate()
    {
        animator.SetFloat("Horizontal", moveInput.x);
        animator.SetFloat("Vertical", moveInput.y);
    }

}
