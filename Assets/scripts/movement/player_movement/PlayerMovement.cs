using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float player_speed = 5f;

    private Rigidbody2D rb;
    private Vector2 move_input;

    private Animator animator;

    private Vector2 last_direction = Vector2.down;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = move_input * player_speed;

        bool isWalking = move_input != Vector2.zero;

        animator.SetBool("isWalking", isWalking);

        if (isWalking)
        {
            animator.SetFloat("InputX", move_input.x);
            animator.SetFloat("InputY", move_input.y);

            last_direction = move_input;
        }

        animator.SetFloat("LastInputX", last_direction.x);
        animator.SetFloat("LastInputY", last_direction.y);
    }


    public void Move(InputAction.CallbackContext context)
    {
        move_input = context.ReadValue<Vector2>();
    }
}