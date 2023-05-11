using Floor;
using TMPro;
using UnityEngine;

namespace UIScripts
{
    public class UIScore : MonoBehaviour
    {
        [Header("Score panel")] 
        [SerializeField] public TMP_Text text;

        void Update()
        {
            text.text = Scores.ScoreSystem.Score.ToString();
        }
    }
}