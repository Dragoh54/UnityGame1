using Floor;
using UnityEngine;

namespace Menu
{
    public class EndLevel : Pause
    {
        [Header("Finish panel")] public GameObject finishPanel;

        private void Start()
        {
            finishPanel.SetActive(false);
        }

        private void LateUpdate()
        {
            if (RoofGenerating.IsPlaced)
            {
                finishPanel.SetActive(true);
                TurnOffPanels();
            }
        }
    }
}