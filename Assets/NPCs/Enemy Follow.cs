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

    private Vector3 lastPosition;

    void Start()
    {
        animator = GetComponent<Animator>();
        lastPosition = transform.position;
    }

    void Update()
    {
        if (!isAlive) return;

        float distance = Vector3.Distance(transform.position, player.position);
        float currentSpeed = 0f;

        if (distance < chaseRange)
        {
            // Rotate to face the player (horizontal only)
            Vector3 lookAt = new Vector3(player.position.x, transform.position.y, player.position.z);
            transform.LookAt(lookAt);

            if (distance > attackRange)
            {
                // Move toward player smoothly
                Vector3 direction = (player.position - transform.position).normalized;
                direction.y = 0f; // prevent floating
                transform.position += direction * speed * Time.deltaTime;

                currentSpeed = speed;
            }

            // Animation parameters
            animator.SetFloat("Speed", currentSpeed); // must match Blend Tree param name
            animator.SetBool("InRange", distance <= attackRange);
        }
        else
        {
            // Out of chase range
            animator.SetFloat("Speed", 0f);
            animator.SetBool("InRange", false);
        }

        lastPosition = transform.position;
    }

    public void Kill()
    {
        if (!isAlive) return;

        isAlive = false;
        animator.SetTrigger("Die");
        Destroy(gameObject, 2f);
    }
}

