using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class XButtonPressInputAction : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score = 0;
    
    public InputActionReference buttonXPress;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        buttonXPress.action.started += UpdateScore;
        buttonXPress.action.canceled += XButtonReleased;
    }

    private void OnDisable()
    {
        buttonXPress.action.started -= UpdateScore;
        buttonXPress.action.canceled -= XButtonReleased;
    }

    private void UpdateScore(InputAction.CallbackContext context)
    {
        score ++;
        scoreText.text = score.ToString();
    }
    private void XButtonReleased(InputAction.CallbackContext context)
    {
        //...
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
