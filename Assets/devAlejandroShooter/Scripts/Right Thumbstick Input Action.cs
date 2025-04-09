using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace devAlejandroShooter.Scripts
{
    public class RightThumbstickInputAction : MonoBehaviour
    {
        public InputActionReference rightThumbstick;
        public Transform moveObjectTransform;
        public TextMeshProUGUI yAxisValueText;
        public float moveSpeed = 2f; // Ajusta la velocidad del movimiento

        private void Start()
        {
            rightThumbstick.action.performed += ThumbstickActivated;
        }

        private void ThumbstickActivated(InputAction.CallbackContext ctx)
        {
            Vector2 rightThumbstickValue = ctx.ReadValue<Vector2>();
            yAxisValueText.text = rightThumbstickValue.x.ToString("F2") + ", " + rightThumbstickValue.y.ToString("F2");

            Vector3 moveDirection = new Vector3(rightThumbstickValue.x, 0, rightThumbstickValue.y);
            moveObjectTransform.position += moveDirection * moveSpeed * Time.deltaTime;
        }

        private void OnDisable()
        {
            rightThumbstick.action.performed -= ThumbstickActivated;
        }
    }
}