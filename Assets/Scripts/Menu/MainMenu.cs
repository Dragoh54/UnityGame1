using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MainMenu : MonoBehaviour
    {
        public void Menu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu");
        }

        public void StartGame()
        {
            SceneManager.LoadScene("BuildScene");
        }

        public void Exit() { 
            Application.Quit(); 
        }
    }
}
