using UnityEngine;

public class DetectarTirado : MonoBehaviour
{
    public bool tirado = false;
    public float segundosDetectarCaida = 3f;
    public float segundosTranscurridos = 0f;

    // Update is called once per frame
    void Update()
    {
        if (segundosTranscurridos >= segundosDetectarCaida && !tirado)
        {
            // TODO: DECIDIR QUE HACER CUANDO EL BOLO HAYA SIDO TIRADO
            // SE HA DETECTADO QUE EL BOLO HA CAIDO DO SOMETHING
            Debug.Log("BOLO TIRADO");
            tirado = true;
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
