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
    private AudioSource hissAudio;
    private bool isAlive = true;
    private bool hasHissed = false;

    private Vector3 lastPosition;

    void Start()
    {
        animator = GetComponent<Animator>();
        lastPosition = transform.position;
        hissAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!isAlive) return;

        float distance = Vector3.Distance(transform.position, player.position);
        float currentSpeed = 0f;

        if (distance < chaseRange)
        {
            // Play hiss once when player enters chase range
            if (!hasHissed)
            {
                if (hissAudio != null && !hissAudio.isPlaying)
                {
                    hissAudio.Play();
                    hasHissed = true;
                }
            }

            // Rotate to face the player
            Vector3 lookAt = new Vector3(player.position.x, transform.position.y, player.position.z);
            transform.LookAt(lookAt);

            if (distance > attackRange)
            {
                Vector3 direction = (player.position - transform.position).normalized;
                direction.y = 0f;
                transform.position += direction * speed * Time.deltaTime;
                currentSpeed = speed;
            }

            animator.SetFloat("Speed", currentSpeed);
            animator.SetBool("InRange", distance <= attackRange);
        }
        else
        {
            animator.SetFloat("Speed", 0f);
            animator.SetBool("InRange", false);
            hasHissed = false; // Reset so it can hiss again next time player re-enters
        }

        lastPosition = transform.position;
    }

    public void Kill()
    {
        if (!isAlive) return;

        isAlive = false;
        animator.SetTrigger("Die");

        // Add points
        GameManager gm = FindObjectOfType<GameManager>();
        if (gm != null)
        {
            gm.AddPoints(1); // or more if needed
        }

        Destroy(gameObject, 2f);
    }

}

