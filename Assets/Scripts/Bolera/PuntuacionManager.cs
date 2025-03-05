using System.Collections.Generic;
using UnityEngine;

public class PuntuacionManager : MonoBehaviour
{
    
  

    private int totalTurnos = 10;
    public int puntuacionTotal = 0;
    public List<List<int>> puntos = new List<List<int>>();
    public List<List<int>> puntosMostrados = new List<List<int>>();

    public bool PuedeTirar(int turnoActual)
    {
        
        if (turnoActual + 1 == totalTurnos)
        {
            //Es el ultimo turno
            if (puntos[turnoActual].Count <= 1)
            {
                //Ha tirado menos de dos veces
                return true;
            }
            else
            {
                if (EsPleno(turnoActual) && puntos[turnoActual].Count <= 3)
                {
                    return true;
                }else if (EsSemiPleno(turnoActual) && puntos[turnoActual].Count <= 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
        }
        else
        {
            if (puntos[turnoActual].Count <= 1)
            {
                //Ha tirado menos de dos veces
                return !EsPleno(turnoActual);
            }
            return true;
        }
    }

    public void setTirada(int turnoActual, int bolosTirados)
    {
        puntos[turnoActual].Add(bolosTirados);
        CalcularPuntuacion();
        // Debug.Log("Puntuacion Total: " + puntuacionTotal);
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < totalTurnos; i++)
        {
            puntos.Add( new List<int>() );
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CalcularPuntuacion()
    {
        puntuacionTotal = 0;
        puntosMostrados = puntos;
        for (int turno = 0; turno < puntosMostrados.Count; turno++)
        {
            for (int tirada = 0; tirada < puntosMostrados[turno].Count; tirada++)
            {
                //Caso dos tiradas normales
                if(!EsPleno(turno) && !EsSemiPleno(turno))
                {
                    puntuacionTotal += SumarPuntosTurno(turno);
                    //Caso pleno
                }else if( EsPleno(turno) )
                {
                    puntuacionTotal += CalcularPlenoOSemiPleno(turno, tirada);
                //Caso SemiPleno
                }else
                {
                    puntuacionTotal += CalcularPlenoOSemiPleno(turno, tirada);
                }
                break;
            }
        }
    }

    
    // public int CalcularPleno(int turno, int tirada)
    // {
    //     return CalcularPlenoOSemiPleno(turno, tirada, true);
    // }
    //
    // public int CalcularSemiPleno(int turno, int tirada)
    // {
    //     return CalcularPlenoOSemiPleno(turno, tirada, false);
    // }
    
    // public int CalcularPlenoOSemiPleno(int turno, int tirada, bool esPleno)
    public int CalcularPlenoOSemiPleno(int turno, int tirada)
    {
        int total = 0;
        int turnosAContar = 3;
        // int turnosAContar = (esPleno) ? 3 : 2;
        
        int i = 0;
        while (i < turnosAContar)
        {
            for (int x = turno; x < puntos.Count; x++ )
            {
                for (int y = tirada; y < puntos[x].Count; y++)
                {
                    if ( i < turnosAContar )
                    {
                        total += puntos[x][y];
                        i++;
                    }
                    
                }
            }

            break;
        }
        

        return total;
    }

    public bool EsPleno(int turno)
    {
        if (puntos[turno].Count > 0)
        {
            return puntos[turno][0] == 10;     
        }
        else
        {
            return false;
        }
        
    }
    public bool EsSemiPleno(int turno)
    {
        return !EsPleno(turno) && SumarPuntosTurno(turno) == 10;
    }
    public int SumarPuntosTurno( int turno){

        if (puntos[turno].Count == 0)
        {
            return 0;
        }else
        {
            int totalTurno = 0;
            foreach (int tirada in puntos[turno])
            {
                totalTurno += tirada;
            }

            return totalTurno;
        }
    }
}
