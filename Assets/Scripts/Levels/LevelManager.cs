using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Levels
{
    public class LevelManager : MonoBehaviour
    {
        [Header("Max level")] 
        public int maxLevel;

        public void LoadLevel(int index)
        {
            SceneManager.LoadScene(index);
        }

        public void ResetProgress()
        {
            maxLevel = 1;
            PlayerPrefs.SetInt("MaxLevel", maxLevel);
            SceneManager.LoadScene("LoadMainMenu");
        }
        
        protected void Save(int level)
        {
            if (level >= maxLevel)
            {
                PlayerPrefs.SetInt("MaxLevel", level);
            }
        }

        protected void Load()
        {
            maxLevel = PlayerPrefs.GetInt("MaxLevel", maxLevel);
        }
    }
}