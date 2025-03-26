using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class XButtonPressInputAction : MonoBehaviour
{
    public InputActionReference xButtonReference;
    public TextMeshProUGUI scoreText;
    public int score = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
    }

    private void OnEnable()
    {
        // Se suscribe a el evento de cuando de pulsa y se suelta el boton.
        xButtonReference.action.started += UpdateScore;
        xButtonReference.action.canceled += UpdateScore;
    }

    private void OnDisable()
    {
        // Al deshabilitarse el objeto, se desuscribe al evento. (Para ahorrar recursos)
        xButtonReference.action.started -= UpdateScore;
    }

    private void XButtonReleased(InputAction.CallbackContext context)
    {
        
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
