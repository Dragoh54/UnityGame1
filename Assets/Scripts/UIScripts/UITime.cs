using System;
using TMPro;
using UnityEngine;

namespace UIScripts
{
    public class UITime : MonoBehaviour
    {
        [Header("UI")] public TMP_Text text;

        private float _startTime;
        private float _elapsedTime;

        private void Start()
        {
            _startTime = Time.time;
        }

        void Update()
        {
            float elapsedTime = Time.time - _startTime;
            int hours = (int)(elapsedTime / 3600) % 60;
            int minutes = (int)(elapsedTime / 60) % 60;
            int seconds = (int)elapsedTime % 60;

            text.text = $"{hours:00}:{minutes:00}:{seconds:00}";
        }
    }
}