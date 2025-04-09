using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class XButtonPressInputAction : MonoBehaviour
{

    public InputActionReference xButton;
    public InputActionReference yButton;

    public TextMeshProUGUI scoreText;
    public int score = 0;
    
   

    public float yAxis = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    
    private void OnEnable()
    {
        xButton.action.started += UpdateScore;
        xButton.action.canceled += XButtonReleased;
    
       // yButton.action.performed += Throttle;
    }

    private void OnDisable()
    {
        xButton.action.started -= UpdateScore;
        xButton.action.canceled -= XButtonReleased;
    }

    private void XButtonReleased(InputAction.CallbackContext context)
    {

    }

    private void UpdateScore(InputAction.CallbackContext context)
    {
        score++;
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
