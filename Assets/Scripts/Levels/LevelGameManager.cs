using System;
using Floor;
using UnityEngine;

namespace Levels
{
    public class LevelGameManager : LevelManager
    {
        [Header("Current level")] 
        public int currentLevel;
        
        private void FixedUpdate()
        {
            if (RoofGenerating.IsPlaced)
            {
                Time.timeScale = 0f;
                Save(currentLevel);
            }
        }
    }
}