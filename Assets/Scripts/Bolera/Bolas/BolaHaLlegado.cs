using System;
using UnityEngine;
using UnityEngine.Events;

public class BolaHaLlegado : MonoBehaviour
{
    public double contador;
    public double tiempoLimite = 10;
    public static UnityEvent pasarTurno = new UnityEvent();
    
    public bool haTocadoPista = false;
    // Update is called once per frame
    void Update()
    {
        if (haTocadoPista)
        {
            contador += Time.deltaTime;
            if (contador >= tiempoLimite)
            {
                //Llamar para cambiar de turno
                Debug.Log("Se acabo el tiempo, cambio de turno");
                pasarTurno.Invoke();
                contador = 0;
                haTocadoPista = false;
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("PistaBolos"))
        {
            haTocadoPista = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FinalPistaBolos"))
        {
            Debug.Log("Bola ha llegdo, cambio de turno");
            pasarTurno.Invoke();
        }
    }
}
