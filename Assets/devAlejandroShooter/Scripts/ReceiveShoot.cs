using UnityEngine;

namespace devAlejandroShooter.Scripts
{
    public class ReceiveShoot : MonoBehaviour
    {
        public void HandleShoot()
        {
            Destroy(gameObject);
        }
    }
}
