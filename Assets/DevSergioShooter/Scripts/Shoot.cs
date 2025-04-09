using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Shoot : MonoBehaviour
{
    public InputActionReference action;
    public TextMeshProUGUI text;
    public int puntos = 0;
    
    public float range = 100f;
    public Transform gun;
    public bool gunGrabbed = false;
    
    private LineRenderer lineRenderer;
    void OnEnable()
    {
        action.action.performed += ShootRaycast;
        
    }
    void OnDisable()
    {
        action.action.performed -= ShootRaycast;
    }
    

    // Update is called once per frame
    void Update()
    {
        if (action.action.WasPressedThisFrame())
        {
            ShootRaycast();
        }
    }

    public void ShootRaycast(InputAction.CallbackContext context)
    {
        Ray ray = new Ray(gun.position, gun.forward);
        RaycastHit hit;
        if (Physics.Raycast(gun.position, transform.TransformDirection(Vector3.forward) * range, out hit) )
        {
            ReceiveShoot target = hit.collider.gameObject.GetComponent<ReceiveShoot>();

            if (target != null)
            {
                puntos++;
                text.text = puntos.ToString();
                target.HandleShoot();
            }
        }
    }
}
