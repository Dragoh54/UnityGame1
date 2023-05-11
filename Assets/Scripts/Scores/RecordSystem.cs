using GameOver;
using TMPro;
using UnityEngine;

namespace Scores
{
    public class RecordSystem : MonoBehaviour
    {
        [Header("Record")] 
        private int _record;

        [Header("UI")] 
        [SerializeField] public TMP_Text text;

        private void Awake()
        {
            Load();
            text.text = _record.ToString();
        }

        private void Update()
        {
            if (Endgame.IsGameOver)
            {
                CheckRecord();
            }
        }

        private void CheckRecord()
        {
            if (_record < ScoreSystem.Score)
            {
                Save(ScoreSystem.Score);
            }
        }

        private void Save(int record)
        {
            PlayerPrefs.SetInt("Record", record);
        }

        private void Load()
        {
            _record = PlayerPrefs.GetInt("Record", _record);
        }
    }
}