using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class LaunchCohete : MonoBehaviour
{
    public GameObject Cohete;
    public float impulso = 1f;
    public InputActionReference buttonYPress;

    public Vector3 forceToApply;
    public TextMeshProUGUI buttonYText;

    private void Update()
    {
        // Cohete.GetComponent<Rigidbody>().AddForce(forceToApply * Time.deltaTime);
    }

    void OnEnable()
    {
        buttonYPress.action.performed += ImpulsarCohete;
        // buttonYPress.action.canceled += CancelarImpulsoCohete;
        
    }

    private void OnDisable()
    {
        buttonYPress.action.performed -= ImpulsarCohete;
        // buttonYPress.action.canceled += CancelarImpulsoCohete;
    }

    private void ImpulsarCohete(InputAction.CallbackContext context)
    {
        buttonYText.text = context.ReadValue<float>().ToString("0.00000");
        forceToApply = Vector3.up * context.ReadValue<float>() * impulso;
        Cohete.GetComponent<Rigidbody>().AddForce(forceToApply * Time.deltaTime, ForceMode.Impulse);
        
    }

    private void CancelarImpulsoCohete(InputAction.CallbackContext context)
    {
        forceToApply = Vector3.zero;
    }
}
