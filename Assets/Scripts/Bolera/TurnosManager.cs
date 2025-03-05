using Bolera;
using UnityEngine;

public class TurnosManager : MonoBehaviour
{
    public InstanciarBolos bolos;
    public GameObject[] jugadores;
    
    public int jugadorActual = 0;
    public int turnoActual = 0;
    public int maxTurnos = 10;

    public int tiradas;

    public void Tirar(int bolosTirados)
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
            //TODO: respawn bolas y bolos
        }
        
        
        
        
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
}
