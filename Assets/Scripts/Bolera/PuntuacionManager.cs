using UnityEngine;

public class PuntuacionManager : MonoBehaviour
{
    
    public int[][] turnos = new int[10][];//[10][2]

    public  int[] puntuacionTurnos = new int[10];//10

    public int puntuacionTotal;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CalcularPuntuacion()
    {
        for(int index = 0;index < turnos.Length; index++){
            //Caso dos tiradas normales
            if(!EsPleno(index) && EsSemiPleno(index))
            {
                puntuacionTurnos[index] = SumarPuntosTurno(index);
                //Caso pleno
            }else if( EsPleno(index) )
            {
                puntuacionTurnos[index] = CalcularPleno(index);
            //Caso SemiPleno
            }else
            {
                puntuacionTurnos[index] = CalcularSemiPleno(index);
            }
        }
    }

    
    public int CalcularPleno(int index)
    {
        return CalcularPlenoOSemiPleno(index, false);
    }
    
    public int CalcularSemiPleno(int index)
    {
        return CalcularPlenoOSemiPleno(index, false);
    }
    
    public int CalcularPlenoOSemiPleno(int index, bool esPleno)
    {
        int total = 0;
        int turnosAContar = (esPleno) ? 2 : 1;
        
        for (int i = 0; i <= turnosAContar; i++)
        {
            int tmp = index + i;

            if (tmp == index)
            {
                total += SumarPuntosTurno(index);
            }else if (!EsPleno(tmp) && !EsSemiPleno(tmp))
            {
                total += SumarPuntosTurno(tmp);
            }else if( EsPleno(tmp) )
            {
                total += CalcularPleno(tmp);
            }
            else
            {
                total += CalcularSemiPleno(tmp);
            }
        }

        return total;
    }

    public bool EsPleno(int index)
    {
       return turnos[index][0] == 10; 
    }
    public bool EsSemiPleno(int index)
    {
        return !EsPleno(index) && SumarPuntosTurno(index) == 10;
    }
    public int SumarPuntosTurno( int index){
        return turnos[index][0] + turnos[index][1];
    }
}
