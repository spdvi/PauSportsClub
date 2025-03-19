using UnityEngine;

public class BolleraSoundController : MonoBehaviour
{
    public string targetTag = "BowlingBall"; // Tag del objeto con el que colisionará
    public AudioClip collisionSound; // Sonido a reproducir
    private AudioSource audioSource;

    void Start()
    {
        // Busca el AudioSource en este objeto o sus hijos
        audioSource = GetComponent<AudioSource>();

        // Si no se encuentra, intenta agregarlo automáticamente
        if (audioSource == null)
        {
            Debug.LogWarning($"No se encontró un AudioSource en {gameObject.name}. Se agregará uno automáticamente.");
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            if (audioSource != null && collisionSound != null)
            {
                audioSource.PlayOneShot(collisionSound);
            }
            else
            {
                Debug.LogError($"Falta asignar el AudioClip en {gameObject.name}.");
            }
        }
    }
}
