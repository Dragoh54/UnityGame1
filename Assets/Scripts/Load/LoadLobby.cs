using System;
using System.Collections;
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
            StartCoroutine(LoadSceneCor());
        }

        IEnumerator LoadSceneCor()
        {
            yield return new WaitForSeconds(1f);
            _asyncOperation = SceneManager.LoadSceneAsync(SceneID);
            while (!_asyncOperation.isDone)
            {
                float progress = _asyncOperation.progress / 9f;
                LoadBar.fillAmount = progress;
                BarText.text = "Load... " + string.Format("{0:0}%", progress * 100f);
                yield return 0;
            }
        }
    }
}