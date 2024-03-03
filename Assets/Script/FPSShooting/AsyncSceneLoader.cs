using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsyncSceneLoader : MonoBehaviour
{
    [SerializeField] private ProgressBar progress;
    public string sceneName;
    public float fakeDuration;

    private AsyncOperation loadingOperation;
    private float startTime;
    

    public void StartLoadScene()
    {
        gameObject.SetActive(true);
        DontDestroyOnLoad(this);
        startTime = Time.unscaledTime;
        loadingOperation = SceneManager.LoadSceneAsync(sceneName);
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (loadingOperation == null) return;

        float fakeProgress = (Time.unscaledTime - startTime) / fakeDuration;
        float finalProgress = Mathf.Min(fakeProgress, loadingOperation.progress);

        progress.SetProgressValue(finalProgress);

        if (loadingOperation.isDone && finalProgress >= 1f)
        {
            FinishLoading();
        }
    }

    private void FinishLoading()
    {
        Time.timeScale = 1f;
        Destroy(gameObject);
    }
}
