using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class RightThumbstickInputAction : MonoBehaviour
{
    public InputActionReference rightThumbstick;
    public Transform moveObjectTransform;
    public TextMeshProUGUI yAxisValueText;

    private void OnEnable()
    {
        rightThumbstick.action.performed += ThumbstickActivated;
    }

    private void OnDisable()
    {
        rightThumbstick.action.performed -= ThumbstickActivated;
    }


    private void ThumbstickActivated(InputAction.CallbackContext ctx)
    {
        Vector2 rightThumbstickValue = ctx.ReadValue<Vector2>();
        yAxisValueText.text = rightThumbstickValue.x.ToString() + ", " + rightThumbstickValue.y.ToString();
        Vector3 moveDirection = new Vector3(rightThumbstickValue.y, 0, rightThumbstickValue.x);
        moveObjectTransform.position += moveDirection;
    }
    
}
