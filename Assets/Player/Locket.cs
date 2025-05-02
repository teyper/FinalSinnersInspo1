using UnityEngine;
using UnityEngine.SceneManagement;

public class LocketPickup : MonoBehaviour
{
    public float rotationSpeed = 30f; // degrees per second

    void Update()
    {
        // Slowly rotate the locket around the Y-axis
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player picked up the locket. Loading Scene 1...");
            SceneManager.LoadScene(1); // Or LoadScene("Scene1")
        }
    }
}
