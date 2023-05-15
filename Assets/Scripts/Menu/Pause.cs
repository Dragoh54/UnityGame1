using UnityEngine;

namespace Menu
{
    public class Pause : MonoBehaviour
    {
        [Header("Panel")]
        public GameObject pausePanel;
        public GameObject settingsPanel;
        public GameObject gamePanel;

        private void Awake()    
        {
            pausePanel.SetActive(false);
            settingsPanel.SetActive(false);
        }

        private void Update()
        {
            if (Time.timeScale == 0f){
                Return();
            }
            else
            {
                GamePause();
            }
        }

        public void GamePause()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0f;
                pausePanel.SetActive(true);
                gamePanel.SetActive(false);
            }
        }

        public void Return()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0f)
            {
                pausePanel.SetActive(false);
                settingsPanel.SetActive(false);
                gamePanel.SetActive(true);
                Time.timeScale = 1f;
            }
        }
        
        public void Settings()
        {
            pausePanel.SetActive(false);
            settingsPanel.SetActive(true);
        }

        protected void TurnOffPanels()
        {
            pausePanel.SetActive(false);
            settingsPanel.SetActive(false);
            gamePanel.SetActive(false);
        }
    }
}
