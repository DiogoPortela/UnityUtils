using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Slider loadingSlider;

    public void StartGame()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadScene(int sceneIndex)
    {
        var sceneLoadOperation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        while (!sceneLoadOperation.isDone)
        {
            loadingSlider.value = Mathf.Clamp01(sceneLoadOperation.progress / 0.9f);
            yield return null;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
