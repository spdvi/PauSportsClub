using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace Bolera
{
    public class InstanciarBolos : MonoBehaviour
    {
        public GameObject boloPrefab;
        public Transform spawnPoint;
        public float spacing = 0.2f;
        
        private List<GameObject> spawnedPins = new List<GameObject>();
        void Start()
        {
            SpawnPins();
        }

        public void SpawnPins()
        { 
            ClearPins();
            int rows = 4; // Número de filas
            for (int row = 0; row < rows; row++)
            {
                for (int i = 0; i <= row; i++) // La cantidad de bolos aumenta en cada fila
                {
                    // Calcular posición en triángulo
                    float xOffset = (i - row / 2.0f) * spacing; // Centrar en X
                    float zOffset = row * spacing; // Desplazar en Z
                    Vector3 boloPosition = spawnPoint.position + new Vector3(xOffset, 0, zOffset);
                    
                    GameObject pin = Instantiate(boloPrefab, boloPosition, Quaternion.Euler(0, 0, 0));
                    
                    spawnedPins.Add(pin);
                }
            }
        }

        void ClearPins()
        {
            foreach (GameObject pin in spawnPoint)
            {
                Destroy(pin);
            }

            spawnedPins.Clear();
        }
    }
}
