using System;
using Floor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace GameOver
{
    public class Endgame : MonoBehaviour
    {
        [Header("Game Objects")]
        [SerializeField] public string gameOverTag;
        public GameObject gameOverPanel;
        private GameObject _loseTarget;

        [Header("is GameOver")]
        public static bool IsGameOver;

        private void Awake()
        {
            gameOverTag ??= "Lose";
            gameOverPanel.SetActive(false);
            IsGameOver = false;
        }

        private void Update()
        {
            _loseTarget = GameObject.FindGameObjectWithTag(gameOverTag);

            if (_loseTarget != null)
            {
                GameOver();
            }
        }

        private void GameOver()
        {
            Time.timeScale = 0f;
            gameOverPanel.SetActive(true);
            IsGameOver = true;
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1f;
            }
        }
    }
}
