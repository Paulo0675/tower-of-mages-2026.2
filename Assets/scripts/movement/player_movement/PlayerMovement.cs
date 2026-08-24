using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float player_speed = 5f;
    private Rigidbody2D rb;
    private Vector2 move_input;
    
    /*
    private Animator animator;
    private bool playing_footsteps = false;
    public float footstep_speed = 0.5f;
    */


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(PauseController.IsGamePaused)
        {
            if(rb.velocity != Vector2.zero)
            {
                rb.velocity = Vector2.zero;
            }
            rb.velocity = Vector2.zero;
            animator.SetBool("isWalking", false);

            StopFootsteps();

            return;
        }
        */

        rb.velocity = move_input * player_speed;

        /*

        animator.SetBool("isWalking", rb.velocity.magnitude> 0);

        if(rb.velocity.magnitude> 0 && !playing_footsteps){
            StartFootsteps();
        }
        else if(rb.velocity.magnitude == 0){
            StopFootsteps();
        }
        */
    }

    

    public void Move(InputAction.CallbackContext context)
    {
        /*
        if (context.canceled)
        {
            StopMovementAnimations();
        }
        */

        move_input = context.ReadValue<Vector2>();

        /*
        animator.SetFloat("InputX", move_input.x);
        animator.SetFloat("InputY", move_input.y);
        */
    }

    /*
    void StopMovementAnimations()
    {
        animator.SetBool("isWalking", false);
        animator.SetFloat("LastInputX", move_input.x);
        animator.SetFloat("LastInputY", move_input.y);
    }

    void StartFootsteps(){
        playing_footsteps = true;
        InvokeRepeating(nameof(PlayFootsteps), 0f, footstep_speed);   
    }

    void StopFootsteps(){
        playing_footsteps = false;
        CancelInvoke(nameof(PlayFootsteps));
    }

    void PlayFootsteps(){
        SoundEffectManager.Play("Footsteps", true);
    }
    */
}
