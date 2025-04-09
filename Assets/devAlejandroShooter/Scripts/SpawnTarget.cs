using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using Random = UnityEngine.Random;

namespace devAlejandroShooter.Scripts
{
    public class SpawnTarget : MonoBehaviour
    {
        public GameObject targetPrefab;
        public Transform playerTransform;

        public float spawnRadius = 2f;
        public float spawnHeightOffset = 0f;
        public float launchForce = 10f;

        public InputActionReference xButton;

        private void Start()
        {
            xButton.action.started += Spawn;
            xButton.action.Enable(); 
        }

        private void Spawn(InputAction.CallbackContext context)
        {
            Vector3 forward = playerTransform.forward;
            Vector3 spawnOrigin = playerTransform.position;

            
            float angleRange = 30f;
            float angle = Random.Range(-angleRange, angleRange);

           
            Vector3 direction = Quaternion.Euler(0, angle, 0) * forward;
            direction.Normalize();

            
            float minDistance = 5f;
            float maxDistance = 8f;
            float distance = Random.Range(minDistance, maxDistance);

            Vector3 spawnPos = spawnOrigin + direction * distance;
            spawnPos.y += spawnHeightOffset;

            GameObject newTarget = Instantiate(targetPrefab, spawnPos, Quaternion.identity);

            
            Rigidbody rb = newTarget.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(Vector3.up * launchForce, ForceMode.Impulse);
            }
        }

        private void OnDisable()
        {
            xButton.action.started -= Spawn;
        }

        private void OnDestroy()
        {
            xButton.action.started -= Spawn;
        }
    }
}
