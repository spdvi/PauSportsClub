using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
     public InputActionProperty triggerAction;

    
    public float rayDistance = 50f;
    public LayerMask hitLayers;
    public Transform shootOrigin;

    private LineRenderer lineRenderer;

    private void OnEnable()
    {
        triggerAction.action.Enable();
    }

    private void OnDisable()
    {
        triggerAction.action.Disable();
    }

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.enabled = true;
    }

    private void Update()
    {
        UpdateLaser();

        if (triggerAction.action.WasPressedThisFrame())
        {
            TryShoot();
        }
    }

    private void UpdateLaser()
    {
        Ray ray = new Ray(shootOrigin.position, shootOrigin.forward);
        Vector3 endPoint = shootOrigin.position + shootOrigin.forward * rayDistance;

        if (Physics.Raycast(ray, out RaycastHit hit, rayDistance, hitLayers))
        {
            endPoint = hit.point;
        }

        lineRenderer.SetPosition(0, shootOrigin.position);
        lineRenderer.SetPosition(1, endPoint);
    }

    private void TryShoot()
    {
        Ray ray = new Ray(shootOrigin.position, shootOrigin.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, rayDistance, hitLayers))
        {
            ReceiveShoot target = hit.collider.GetComponent<ReceiveShoot>();
            if (target != null)
            {
                target.HandleShoot();
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (shootOrigin != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(shootOrigin.position, shootOrigin.forward * rayDistance);
        }
    }
}
