using UnityEngine;

public class GateOpen : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;

    public AudioClip OpenS;
    public AudioClip CloseS;

    private bool isOpen = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isOpen && other.CompareTag("Player"))
        {
            animator.Play("InDoorsOpen"); // ✅ match your animation name
            PlaySound(OpenS);
            isOpen = true;
            Debug.Log("Player entered: doors opening.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isOpen && other.CompareTag("Player"))
        {
            animator.Play("InDoorsClose"); // ✅ match your animation name
            PlaySound(CloseS);
            isOpen = false;
            Debug.Log("Player exited: doors closing.");
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.Stop();
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}

    

   /* public void OnPowerUp1()
    {
        animator.Play("InDoorOpen");
        Debug.Log("yes!");

    }*/




