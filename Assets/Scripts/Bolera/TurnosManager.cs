using Bolera;
using UnityEngine;
using UnityEngine.Events;

public class TurnosManager : MonoBehaviour
{
    public InstanciarBolos bolos;
    public GameObject[] jugadores;
    
    public int jugadorActual = 0;
    public int turnoActual = 0;
    public int maxTurnos = 10;

    public int tiradas;

    public int bolosTirados = 0;

    void Start()
    {
        DetectarTirado.OnTirar?.AddListener(BoloTirado);
        //Detectar si bola ha llegado suscribiendome al evento que toque.
    }
    public void Tirar()
    {
        
        
        PuntuacionManager jugadorPuntuacion = jugadores[jugadorActual].GetComponent<PuntuacionManager>();
        jugadorPuntuacion.setTirada(turnoActual, bolosTirados);
        
        //Comprobar si puede seguir tirando
        if ( !jugadorPuntuacion.PuedeTirar(turnoActual) )
        {
            PasarTurno();    
        }
        else
        {
            bolos.SpawnPins();
        }

        bolosTirados = 0;




    }

    public void PasarTurno()
    {
        if (jugadorActual == jugadores.Length-1)
        {
            jugadorActual = 0;
            if (turnoActual == maxTurnos)
            {
                //TODO: ACABAR LA PARTIDA
            }
            else
            {
                turnoActual++;    
            }
            
        }
        else
        {
            jugadorActual++;
        }
    }

    public void BoloTirado()
    {
        bolosTirados++;
    }
}
