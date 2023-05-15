using UnityEngine;
using UnityEngine.SceneManagement;

namespace Levels
{
    public class LevelManager : MonoBehaviour
    {
        [Header("Max level")] 
        public int maxLevel;

        public void LoadLevel(int index)
        {
            SceneManager.LoadScene(index);
            Time.timeScale = 1f;
        }

        public void ResetProgress()
        {
            PlayerPrefs.SetInt("MaxLevel", 1);
            SceneManager.LoadScene("LoadMainMenu");
        }
        
        protected void Save(int level)
        {
            if (level + 1 >= maxLevel)
            {
                PlayerPrefs.SetInt("MaxLevel", level + 1);
            }
        }

        protected void Load()
        {
            maxLevel = PlayerPrefs.GetInt("MaxLevel", maxLevel);
        }
    }
}