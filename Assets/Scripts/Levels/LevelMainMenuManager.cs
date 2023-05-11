using UnityEngine;
using UnityEngine.UI;

namespace Levels
{
    public class LevelMainMenuManager : LevelManager
    {
        [Header("Closed levels")] 
        public Button[] closedLvl;
        
        private void Awake()
        {
            Load();
            for (int i = 0; i < closedLvl.Length; i++)
            {
                if (i < maxLevel)
                {
                    closedLvl[i].interactable = true;
                }
                else
                {
                    closedLvl[i].interactable = false;
                }
            }
        }
    }
}