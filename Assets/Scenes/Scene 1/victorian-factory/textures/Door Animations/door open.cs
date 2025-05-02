using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dooropen : MonoBehaviour
{
    Animator animator;
    AudioSource audioSource;


   public AudioClip OpenS;
    public AudioClip CloseS; 


    // Start is called before the first frame update
    public void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    
    private void OnTriggerEnter(Collider other)
    {
        animator.Play("Door Open");
        if (OpenS != null)
        {
            audioSource.Stop();
            audioSource.clip = OpenS;
            audioSource.Play();
        }
        Debug.Log("Trigger entered by you.");


    }

    private void OnTriggerExit(Collider other)
    {
        animator.Play("DoorClose");
        if (CloseS != null)
        {
            audioSource.Stop();
            audioSource.clip = CloseS;
            audioSource.Play();
        }

        Debug.Log("Trigger exited by you.");


    }
}