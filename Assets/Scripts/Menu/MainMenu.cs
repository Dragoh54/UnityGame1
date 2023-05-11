using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MainMenu : MonoBehaviour
    {
        public void Menu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("LoadMainMenu");
        }

        public void StartGame()
        {
            SceneManager.LoadScene("LoadBuildScene");
        }

        public void Exit() { 
            Application.Quit(); 
        }
    }
}
