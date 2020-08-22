using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingObject : MonoBehaviour
{
    public TMP_Text PercentText;
    public Slider slider;


    private int _currentPercent;
    public int CurrentPercent
    {
        get => _currentPercent;
        set
        {
            _currentPercent = value;
            slider.value = value;
            PercentText.text = value.ToString() + "%";
        }
    }

    private void Start()
    {
        slider.maxValue = 100;
        StartCoroutine(LoadScene(1));
    }

    private IEnumerator LoadScene(int indexOfScene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(indexOfScene);
        while (!operation.isDone)
        {
            float progress = operation.progress / 0.9f;
            CurrentPercent = (int)(progress * slider.maxValue);
            Debug.Log(CurrentPercent);
            yield return null;
        }
    }

}
