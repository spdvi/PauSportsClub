using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public bool isGrabbed = false;

    public TextMeshProUGUI text;

    public int tiros = 0;

    public float gunRange = 5f;
    public Transform gunCannon;
    public LineRenderer lineRenderer;

    public InputActionReference shootAction;
    void OnEnable()
    {
        shootAction.action.performed += Disparo;
        
    }

    private void OnDisable()
    {
        shootAction.action.performed -= Disparo;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DrawRayCast();
    }

    public void DrawRayCast()
    {
        // Debug.DrawLine(gunCannon.position, gunCannon.position + (Vector3.forward * gunRange), Color.magenta );
        lineRenderer.enabled = isGrabbed;
        // if (lineRenderer.enabled)
        // {
        //     lineRenderer.SetPosition(0, gunCannon.position);    
        //     lineRenderer.SetPosition(1, gunCannon.position + (Vector3.forward * gunRange) );    
        // }
    }
    
    public void Grab()
    {
        isGrabbed = true;
    }

    public void Release()
    {
        isGrabbed = false;
    }

    public void Disparo(InputAction.CallbackContext context)
    {
        
        RaycastHit hit;
        if (Physics.Raycast(gunCannon.position, transform.TransformDirection(Vector3.forward) * gunRange, out hit) )
        {
            RecieveShoot target = hit.collider.gameObject.GetComponent<RecieveShoot>();

            if (target != null)
            {
                tiros++;
                text.text = tiros.ToString();
                target.RecieveShot();
            }
        }
    }
}
