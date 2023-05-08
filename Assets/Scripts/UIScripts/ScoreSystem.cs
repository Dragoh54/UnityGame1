using Floor;
using TMPro;
using UnityEngine;

namespace UIScripts
{
    public class ScoreSystem : MonoBehaviour
    {
        [Header("Score panel")] 
        [SerializeField] public TMP_Text text;

        void Update()
        {
            text.text = FloorRespawn._floorCounter.ToString();
        }
    }
}