using System;
using System.Collections;
using Floor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Load
{
    public class LoadLobby : MonoBehaviour
    {
        private AsyncOperation _asyncOperation;
        public Image LoadBar;
        public TMP_Text BarText;
        public int SceneID;

        private void Start()
        {
            RoofGenerating.IsPlaced = false;
            Time.timeScale = 1f;
            StartCoroutine(LoadSceneCor());
        }

        IEnumerator LoadSceneCor()
        {
            yield return new WaitForSeconds(1f);
            _asyncOperation = SceneManager.LoadSceneAsync(SceneID);
            while (!_asyncOperation.isDone)
            {
                float progress = _asyncOperation.progress;
                LoadBar.fillAmount = progress + 0.1f;
                print(progress);
                BarText.text = "Loading... " + string.Format("{0:0}%", progress / 9f * 1000f);
                yield return 0;
            }
        }
    }
}