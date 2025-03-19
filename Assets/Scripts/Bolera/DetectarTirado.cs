using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class DetectarTirado : MonoBehaviour
{
    public bool tirado = false;
    public float segundosDetectarCaida = 3f;
    public float segundosTranscurridos = 0f;

    public static UnityEvent OnTirar = new UnityEvent();
    void Update()
    {
        if (segundosTranscurridos >= segundosDetectarCaida && !tirado)
        {
            Debug.Log("BOLO TIRADO");
            tirado = true;
            OnTirar.Invoke();
            Destroy(gameObject);
        }
        if ( DetectarCaido())
        {
            segundosTranscurridos += Time.deltaTime;  
        }
        else
        {
            segundosTranscurridos = 0;
        }
        
    }

    public bool DetectarCaido()
    {
        float angleX = this.transform.rotation.eulerAngles.x;
        float angleZ = this.transform.rotation.eulerAngles.z;
        
        angleX %= 360;
        if (angleX > 180)
        {
            angleX = angleX - 360;
        }
        angleZ %= 360;
        if (angleZ > 180)
        {
            angleZ = angleZ - 360;
        }
            
        
        // Debug.Log(angle);
        
        float maxAngle = 45f;
        float minAngle = -45f;
        return (angleX < minAngle || angleX > maxAngle) || (angleZ < minAngle || angleZ > maxAngle);
        // this.transform.localRotation.x;
        // return true;
    }
}
