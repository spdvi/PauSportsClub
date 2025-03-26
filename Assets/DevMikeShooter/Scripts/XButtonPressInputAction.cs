using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class XButtonPressInputAction : MonoBehaviour
{
    public InputActionReference xButton;
    public TextMeshProUGUI scoreText;
    public int score = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        xButton.action.started += UpdateScore;
        xButton.action.canceled += XButtonReleased;
    }
    
    private void OnDisable()
    {
        xButton.action.started -= UpdateScore;
        xButton.action.canceled -= XButtonReleased;
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
