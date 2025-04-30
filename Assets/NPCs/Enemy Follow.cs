using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed = 2.5f;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private float chaseRange = 10f;

    private Animator animator;
    private bool isAlive = true;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isAlive) return;

        float distance = Vector3.Distance(transform.position, player.position);
        float moveSpeed = 0f;

        if (distance < chaseRange)
        {
            // Look at the player horizontally
            Vector3 lookAt = new Vector3(player.position.x, transform.position.y, player.position.z);
            transform.LookAt(lookAt);

            if (distance > attackRange)
            {
                moveSpeed = speed;
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }

            // Animation parameters
            animator.SetFloat("Speed", moveSpeed);
            animator.SetBool("InRange", distance <= attackRange);
        }
        else
        {
            // Out of chase range
            animator.SetFloat("Speed", 0f);
            animator.SetBool("InRange", false);
        }
    }

    public void Kill()
    {
        if (!isAlive) return;

        isAlive = false;
        animator.SetTrigger("Die"); // Optional: if you have a death anim
        Destroy(gameObject, 2f);    // Let the animation play before destroying
    }
}
