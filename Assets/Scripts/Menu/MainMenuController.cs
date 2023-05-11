using System;
using UnityEngine;

namespace Menu
{
    public class MainMenuController : MonoBehaviour
    {
        [Header("Panel")] 
        public GameObject mainPanel;
        public GameObject settingsPanel;
        public GameObject levelsPanel;
        //levels
        
        private void Awake()
        {
            mainPanel.SetActive(true);
            settingsPanel.SetActive(false);
            levelsPanel.SetActive(false);
        }

        private void Update()
        {
            ReturnToMain(settingsPanel);
            ReturnToMain(levelsPanel);
        }

        public void Settings()
        {
            mainPanel.SetActive(false);
            settingsPanel.SetActive(true);
        }

        public void Levels()
        {
            mainPanel.SetActive(false);
            levelsPanel.SetActive(true);
        }
        
        private void ReturnToMain(GameObject currentPanel)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                currentPanel.SetActive(false);
                mainPanel.SetActive(true);
            }
        }
    }
}