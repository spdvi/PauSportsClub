using UnityEngine;

namespace Bolera.Bolas
{
    public class SpawnerBolas : MonoBehaviour
    {
        public Transform spawnPoint;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("BowlingBall")) 
            {
                other.transform.position = spawnPoint.position;
                other.GetComponent<Rigidbody>().linearVelocity = Vector3.zero; // Detiene el movimiento
                other.GetComponent<Rigidbody>().angularVelocity = Vector3.zero; // Detiene la rotación
            }
        }
    }
}
