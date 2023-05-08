using System;
using Floor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace GameOver
{
    public class Endgame : MonoBehaviour
    {
        [FormerlySerializedAs("GameOverTag")]
        [Header("Game Objects")]
        [SerializeField] public string gameOverTag;
        
        [FormerlySerializedAs("GameOverPanel")] 
        public GameObject gameOverPanel;
        
        private GameObject _loseTarget;

        private void Awake()
        {
            gameOverTag ??= "Lose";
            gameOverPanel.SetActive(false);
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
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1f;
            }
        }
    }
}
