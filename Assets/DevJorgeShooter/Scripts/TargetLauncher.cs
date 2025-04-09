using UnityEngine;
using UnityEngine.InputSystem;


public class TargetLauncher : MonoBehaviour
{
    
    public Transform startPoint;
    
    public Vector3 direction; 
    
    public InputActionReference launchAction;
    public GameObject targetPrefab;
    public float launchStrength = 2000f;
    
    void OnEnable()
    {
        launchAction.action.performed += LaunchTarget;
        
    }
    
    private void OnDisable()
    {
        launchAction.action.performed -= LaunchTarget;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direction = startPoint.up;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void LaunchTarget(InputAction.CallbackContext context)
    {
        GameObject target = Instantiate(targetPrefab, startPoint.position, targetPrefab.transform.rotation);
        
        target.GetComponent<Rigidbody>().AddForce(startPoint.up * launchStrength * Time.deltaTime, ForceMode.Impulse);
        
    }
}
