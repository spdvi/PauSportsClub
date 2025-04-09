using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class YButton : MonoBehaviour
{
    public float fuerzaMaxima = 5000f;
    public InputActionReference accionAcelerador;
    public TextMeshProUGUI textoValorY;
    public Transform objetoCohete;

    private Rigidbody _rb;
    private float _valorActual;

    private void Awake()
    {
        _rb = objetoCohete.GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        accionAcelerador.action.Enable();
        accionAcelerador.action.performed += ActualizarValor;
        accionAcelerador.action.canceled += ReiniciarValor;
    }

    private void OnDisable()
    {
        accionAcelerador.action.performed -= ActualizarValor;
        accionAcelerador.action.canceled -= ReiniciarValor;
    }

    private void ActualizarValor(InputAction.CallbackContext context)
    {
        _valorActual = context.ReadValue<float>();
        textoValorY.text = $"Y: {_valorActual:F2}"; 
        AplicarFuerza();
    }

    private void ReiniciarValor(InputAction.CallbackContext context)
    {
        _valorActual = 0f;
        textoValorY.text = "Y: 0.00";
    }

    private void AplicarFuerza()
    {
        if (_valorActual > 0.01f)
        {
            Vector3 fuerza = Vector3.up * _valorActual * fuerzaMaxima * Time.fixedDeltaTime;
            _rb.AddForce(fuerza, ForceMode.Impulse);
        }
    }
}