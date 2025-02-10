using UnityEngine;
using UnityEngine.SceneManagement;

namespace Main_Room
{
    public class MainRoomManager : MonoBehaviour
    {
        // Método para cargar la escena de Bowling
        public void LoadBowlingScene()
        {
            SceneManager.LoadScene("BowlingScene"); 
        }

        // Método para cargar la escena de Shooter
        public void LoadShooterScene()
        {
            SceneManager.LoadScene("ShooterScene"); 
        }
    }
}
