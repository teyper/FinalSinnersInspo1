using UnityEngine;
using UnityEngine.SceneManagement;

public class Locket : MonoBehaviour
{
    public float rotationSpeed = 30f; // degrees per second
    private bool triggered = false;

    void Update()
    {
        // Slowly rotate the locket around the Y-axis
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;
        if (other.CompareTag("Player"))
        {
            triggered = true;

            Debug.Log("Player picked up the locket. Showing mission complete...");

            // Show mission complete message
            GameManager gm = FindObjectOfType<GameManager>();
            if (gm != null)
            {
                gm.ShowMissionComplete();
            }

            // Load splash screen after a short delay
            Invoke("LoadSplashScene", 2f);
        }
    }

    void LoadSplashScene()
    {
        SceneManager.LoadScene(0); // Use your actual splash scene name or index
    }
}
