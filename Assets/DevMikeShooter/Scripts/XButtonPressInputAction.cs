using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class XButtonPressInputAction : MonoBehaviour
{
    public InputActionReference xButton;
    public InputActionReference yButton;
    public InputActionReference rightThumbstick;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI yAxisValueText;
    public Rigidbody rb;
    public int score = 0;
    public float yAxisValue = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        xButton.action.started += UpdateScore;
        xButton.action.canceled += XButtonReleased;
        yButton.action.performed += YButtonPressed;
    }
    
    private void OnDisable()
    {
        xButton.action.started -= UpdateScore;
        xButton.action.canceled -= XButtonReleased;
        yButton.action.performed -= YButtonPressed;
    }

    private void YButtonPressed(InputAction.CallbackContext ctx)
    {
        yAxisValue = ctx.ReadValue<float>();
        yAxisValueText.text = "Y Axis: " + yAxisValue.ToString();
        rb.AddForce(Vector3.up * yAxisValue * 200);
    }
    
    private void XButtonReleased(InputAction.CallbackContext context)
    {
        // ...
    }
    
    private void UpdateScore(InputAction.CallbackContext context)
    {
        score++;
        scoreText.text = "Points: " + score;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
