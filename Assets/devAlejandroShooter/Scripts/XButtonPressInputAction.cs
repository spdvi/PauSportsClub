using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace devAlejandroShooter.Scripts
{
    public class XButtonPressInputAction : MonoBehaviour
    {
        public InputActionReference xButton;
        public InputActionReference yButton;

        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI inputYAxisValue;

        public int score = 0;

        public GameObject rocket;
        private Rigidbody rocketRB;
        public float force = 10f;

        private void Awake()
        {
            if (rocket != null)
                rocketRB = rocket.GetComponent<Rigidbody>();
            else
                Debug.LogError("Rocket no está asignado en el Inspector.");
        }

        private void Start()
        {
            xButton.action.started += UpdateScore;
            yButton.action.performed += YButtonPressed;  
        }

        private void UpdateScore(InputAction.CallbackContext context)
        {
            scoreText.text = "Points: " + (++score);
        }

        private void YButtonPressed(InputAction.CallbackContext context)
        {
            float forceValue = context.ReadValue<float>();
            inputYAxisValue.text = "AxisY Value: " + forceValue;

            if (rocketRB != null)
            {
                rocketRB.AddForce(Vector3.up * forceValue * force, ForceMode.Impulse);
            }
            else
            {
                Debug.LogWarning("No se encontró el Rigidbody en el cohete.");
            }
        }

        private void OnDisable()
        {
            xButton.action.started -= UpdateScore;
            yButton.action.performed -= YButtonPressed;
        }

        private void OnDestroy()
        {
            xButton.action.started -= UpdateScore;
            yButton.action.performed -= YButtonPressed;
        }
    }
}