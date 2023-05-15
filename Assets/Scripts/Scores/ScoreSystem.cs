using System;
using UnityEngine;

namespace Scores
{
    public class ScoreSystem : MonoBehaviour
    {
        [Header("Public score")] 
        public static int Score;
        private int _currentScore;

        private void Awake()
        {
            Score = 0;
            _currentScore = 0;
        }

        private void Update()
        {
            _currentScore = GameObject.FindGameObjectsWithTag("Placed_Floor").Length;
            if (Score < _currentScore)
            {
                Score = _currentScore;
            }
        }
    }
}