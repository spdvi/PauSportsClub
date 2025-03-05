using UnityEngine;

namespace Bolera.Bolas
{
    public class SpawnerBolas : MonoBehaviour
    {
        public GameObject[] bolas;              // Array con las 3 bolas específicas
        public Transform[] spawnPoints;         // Array con los 3 puntos de spawn fijos

        private void OnTriggerEnter(Collider other)
        {
            // Verificar si la bola que entró en el trigger es una de las bolas específicas
            for (int i = 0; i < bolas.Length; i++)
            {
                if (other.gameObject == bolas[i])
                {
                    Debug.Log("Bola detectada: " + other.gameObject.name);
                    
                    // Recolocar la bola en su correspondiente punto de spawn
                    other.transform.position = spawnPoints[i].position;
                    other.transform.rotation = Quaternion.identity;  // Resetear la rotación

                    // Resetear velocidades del Rigidbody (si tiene uno)
                    Rigidbody rb = other.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.linearVelocity = Vector3.zero;
                        rb.angularVelocity = Vector3.zero;
                    }

                    Debug.Log("Bola recolocada en Spawn " + (i + 1));
                    break;  // Salir del bucle una vez hemos encontrado la bola
                }
            }
        }
    }
}