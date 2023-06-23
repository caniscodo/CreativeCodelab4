using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderCollisionTrigger : MonoBehaviour
{   private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("SpiderTriggered");
        }
    }
}
