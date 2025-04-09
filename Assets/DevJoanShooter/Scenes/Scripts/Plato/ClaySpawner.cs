using UnityEngine;
using UnityEngine.InputSystem;

public class ClaySpawner : MonoBehaviour
{

    public GameObject clayPrefab;
    public Transform spawnPoint;
    public float launchForce = 10f;

    
    public InputActionProperty spawnAction;  // Asignás esto desde el editor

    private void OnEnable()
    {
        spawnAction.action.Enable();
    }

    private void OnDisable()
    {
        spawnAction.action.Disable();
    }

    void Update()
    {
        if (spawnAction.action.WasPressedThisFrame())
        {
            SpawnClay();
        }
    }

    void SpawnClay()
    {
        GameObject clay = Instantiate(clayPrefab, spawnPoint.position, spawnPoint.rotation);

        Rigidbody rb = clay.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = spawnPoint.forward * launchForce;
        }
    }
} 