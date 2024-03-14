using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private string levelToLoad;
    [SerializeField] private GameObject LoadingScreen;

    public void LoadLevel()
    {
        StartCoroutine(LoadLevelAsync(levelToLoad));
    }

    IEnumerator LoadLevelAsync(string levelToLoad)
    {
        LoadingScreen.SetActive(true);
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad);

        while (!loadOperation.isDone)
        {
            float progressValue = Mathf.Clamp01(loadOperation.progress * 0.9f);
            slider.value = progressValue;
            yield return null;
        }
    }

}
