using System;
using Floor;
using UnityEngine;
using UnityEngine.Serialization;

namespace Menu
{
    public class EndLevel : Pause
    {
        [Header("Finish panel")] public GameObject finishPanel;

        private void Start()
        {
            finishPanel.SetActive(false);
        }

        private void FixedUpdate()
        {
            if (RoofGenerating.IsPlaced)
            {
                finishPanel.SetActive(true);
                TurnOffPanels();
            }
        }
    }
}