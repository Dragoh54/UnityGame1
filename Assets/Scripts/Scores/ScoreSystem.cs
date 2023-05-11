using System;
using UnityEngine;

namespace Scores
{
    public class ScoreSystem : MonoBehaviour
    {
        [Header("Public score")] 
        public static int Score;

        private void Update()
        {
            Score = GameObject.FindGameObjectsWithTag("Placed_Floor").Length;
        }
    }
}