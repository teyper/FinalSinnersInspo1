using UnityEngine;
using UnityEngine.Playables;

public class TimelineTrigger : MonoBehaviour
{
    public PlayableDirector director;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && director != null)
        {
            director.Play();
            gameObject.SetActive(false); // optional: disables trigger after use
        }
    }
}

