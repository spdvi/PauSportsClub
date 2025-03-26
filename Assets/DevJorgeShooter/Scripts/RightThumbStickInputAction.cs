using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class RightThumbStickInputAction : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject ObjectToMove;

    public InputActionReference rightThumbStickAction;

    public TextMeshProUGUI YaxisText;
    public TextMeshProUGUI XaxisText;

    public float speed = 5f;




    void OnEnable()
    {
        rightThumbStickAction.action.performed += MoveObject;
        // buttonYPress.action.canceled += CancelarImpulsoCohete;
        
    }

    private void OnDisable()
    {
        rightThumbStickAction.action.performed -= MoveObject;
        // buttonYPress.action.canceled += CancelarImpulsoCohete;
    }

    public void MoveObject(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        YaxisText.text = direction.y.ToString();
        XaxisText.text = direction.x.ToString();

        Vector3 directionToMove = new Vector3(direction.x, 0, direction.y);
        ObjectToMove.transform.Translate(directionToMove * speed * Time.deltaTime);
    }
}
