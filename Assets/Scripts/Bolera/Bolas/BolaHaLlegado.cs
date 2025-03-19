using System;
using UnityEngine;
using UnityEngine.Events;

public class BolaHaLlegado : MonoBehaviour
{
    public double contador;
    public double tiempoLimite = 10;
    public static UnityEvent pasarTurno = new UnityEvent();

    // Update is called once per frame
    void Update()
    {
        contador += Time.deltaTime;
        if (contador >= tiempoLimite)
        {
            //Llamar para cambiar de turno
            Debug.Log("Se acabo el tiempo, cambio de turno");
            pasarTurno.Invoke();
            contador = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BowlingBall"))
        {
            Debug.Log("Bola ha llegdo, cambio de turno");
            pasarTurno.Invoke();
        }
    }
}
