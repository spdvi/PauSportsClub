using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonPressInputAction : MonoBehaviour
{
    public InputActionReference xButtonReference;
    public InputActionReference yButtonReference;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI impulseValueText;
    public int score = 0;
    public Rigidbody rocket;
    public float impulseValue = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
    }

    private void OnEnable()
    {
        // Se suscribe a el evento de cuando de pulsa y se suelta el boton.
        xButtonReference.action.started += XButtonPressed;
        xButtonReference.action.canceled += XButtonReleased;
    }

    private void OnDisable()
    {
        // Al deshabilitarse el objeto, se desuscribe al evento. (Para ahorrar recursos)
        //yButtonReference.action.performed -= UpdateScore;
        xButtonReference.action.started -= XButtonPressed;
        xButtonReference.action.canceled -= XButtonReleased;
    }

    private void XButtonReleased(InputAction.CallbackContext context)
    {
        
    }
    
    private void XButtonPressed(InputAction.CallbackContext context)
    {
        impulseValue = context.ReadValue<float>();
        impulseValueText.text = "Y Axis: " + impulseValue.ToString();
        rocket.AddForce(Vector3.up * impulseValue * 600 * Time.deltaTime, ForceMode.Impulse);
    }

    private void UpdateScore(InputAction.CallbackContext context)
    {
        score++;
        scoreText.text = "Puntos: "+ score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
