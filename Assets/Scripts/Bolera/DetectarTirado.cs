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
        float angle = this.transform.rotation.eulerAngles.x;
        
        angle %= 360;
        if (angle > 180)
        {
            angle = angle - 360;
        }
            
        
        // Debug.Log(angle);
        
        float maxXangle = -45f;
        float minXangle = -135f;
        return (angle < minXangle || angle > maxXangle);
        // this.transform.localRotation.x;
        // return true;
    }
}
