using UnityEngine;
using UnityEngine.Serialization;

namespace Menu
{
    public class Pause : MonoBehaviour
    {
        [FormerlySerializedAs("Pause_Panel")] 
        [Header("Panel")]
        public GameObject pausePanel;
        public GameObject settingsPanel;

        private void Awake()
        {
            pausePanel.SetActive(false);
            settingsPanel.SetActive(false);
        }

        private void Update()
        {
            if (Time.timeScale == 1f)
            {
                GamePause();
            }
            else
            {
                Return();
            }
        }

        public void GamePause()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0f;
                pausePanel.SetActive(true);
            }
        }

        public void Return()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pausePanel.SetActive(false);
                settingsPanel.SetActive(false);
                Time.timeScale = 1f;
            }
        }
        
        public void Settings()
        {
            pausePanel.SetActive(false);
            settingsPanel.SetActive(true);
        }
    }
}
