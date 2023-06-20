using System;
using UnityEngine;

public class CatAnimator : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement playerMovement;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = FindObjectOfType<PlayerMovement>(); 
    }

    private void FixedUpdate()
    {
        if (playerMovement != null)
        {
            if (playerMovement.movement.magnitude > 0)
            {
                animator.SetBool("isWalking", true);
                animator.SetBool("isIdle", false);
            }
            else
            {
                animator.SetBool("isWalking", false);
                animator.SetBool("isIdle", true);
            }

            if (playerMovement.grounded && playerMovement.isJumping)
            {
                if (playerMovement.rb.velocity.y > 0)
                {
                    animator.SetBool("isJumpingUp", true);
                    animator.SetBool("isJumpingDown", false);
                }
                else
                {
                    animator.SetBool("isJumpingUp", false);
                    animator.SetBool("isJumpingDown", true);
                }

                playerMovement.isJumping = false;
            }
            else
            {
                animator.SetBool("isJumpingUp", false);
                animator.SetBool("isJumpingDown", false);
            }

        }
    }

    private void Update()
    {
        
        if (playerMovement.isShooting)
        {
            print("animatorscriptisShooting");
            animator.SetBool("isShooting", true);
        } else if (!playerMovement.isShooting)
        {
            print("animatorNotSHooting");
            animator.SetBool("isShooting", false);
        }
    }
}