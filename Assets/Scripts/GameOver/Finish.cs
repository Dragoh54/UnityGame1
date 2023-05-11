using Floor;
using Scores;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace GameOver
{
    public class Finish : MonoBehaviour
    {
        [Header("Goal")] 
        public int goal;

        [Header("UI")] [SerializeField] 
        public TMP_Text text;

        [Header("GameObject")]
        public GameObject floorSpawner;

        private void Awake()
        {
            text.text = goal.ToString();
            floorSpawner.GetComponent<RoofGenerating>().enabled = false;
        }
        
        void Update()
        {
            StopFloorSpawner();
        }

        private void StopFloorSpawner()
        {
            if (goal == ScoreSystem.Score)
            {
                floorSpawner.GetComponent<FloorRespawn>().enabled = false;
                floorSpawner.GetComponent<RoofGenerating>().enabled = true;
            }
        }
    }
}