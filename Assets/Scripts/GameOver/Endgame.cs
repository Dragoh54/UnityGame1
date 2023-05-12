using System;
using Floor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

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
        
        private float nt = 0f;

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
                ChangeColor();
            }
        }

        private void GameOver()
        {
            gameOverPanel.SetActive(true);
            GameObject.FindGameObjectWithTag("Spawner").GetComponentInChildren<FloorRespawn>().enabled = false;
            IsGameOver = true;
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("LoadBuildScene");
                Time.timeScale = 1f;
            }
        }

        private void ChangeColor()
        {
            nt += Time.deltaTime;
            gameOverPanel.GetComponent<Image>().color = new Color(0f,0f,0f, nt * 0.5f);
        }
    }
}
