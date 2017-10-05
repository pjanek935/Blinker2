using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    [SerializeField] AnimateLoading animateLoading;

    [SerializeField] GameObject loadingCanvas;

    private static SceneLoader instance;

    const float loadingFadeTime = 0.5f;

    public static SceneLoader Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SceneLoader ();
            }

            return instance;
        }
    }

    private void Start()
    {
        instance = this;
        LoadMainMenu ();
    }

    public void LoadMainMenu (CanvasGroup prevCanvas = null)
    {
        StartCoroutine (LoadScene (2, prevCanvas));
    }

	public void LoadTutorial (CanvasGroup prevCanvas)
    {
        StartCoroutine (LoadScene (1, prevCanvas));
    }

    IEnumerator LoadScene(int sceneNumber, CanvasGroup prevCanvas)
    {
        if (prevCanvas != null)
        {
            prevCanvas.alpha = 0;
            prevCanvas.blocksRaycasts = false;
            prevCanvas.interactable = false;
        }
        FadeInLoading ();
        AsyncOperation async = SceneManager.LoadSceneAsync (sceneNumber, LoadSceneMode.Additive);
        yield return async;
        FadeOutLoading ();
    }

    void FadeInLoading()
    {
        iTween.Stop (gameObject);

        Hashtable iTweenHashtable = iTween.Hash (
            "from", loadingCanvas.GetComponent<CanvasGroup> ().alpha,
            "to", 1f,
            "time", loadingFadeTime,
            "onupdatetarget", gameObject,
            "onupdate", "setAlpha");

        iTween.ValueTo (gameObject, iTweenHashtable);

        animateLoading.StartAnimate ();

        loadingCanvas.GetComponent<CanvasGroup> ().interactable = true;
        loadingCanvas.GetComponent<CanvasGroup> ().blocksRaycasts = true;
    }

    void FadeOutLoading()
    {
        iTween.Stop (gameObject);

        Hashtable iTweenHashtable = iTween.Hash (
             "from", loadingCanvas.GetComponent<CanvasGroup> ().alpha,
             "to", 0f,
             "time", loadingFadeTime,
             "onupdatetarget", gameObject,
             "onupdate", "setAlpha",
             "oncompletetarget", gameObject,
             "oncomplete", "stopAnimate");

        iTween.ValueTo (gameObject, iTweenHashtable);

        loadingCanvas.GetComponent<CanvasGroup> ().interactable = false;
        loadingCanvas.GetComponent<CanvasGroup> ().blocksRaycasts = false;
    }

    void setAlpha (float alpha)
    {
        loadingCanvas.GetComponent<CanvasGroup> ().alpha = alpha;
    }

    void stopAnimate()
    {
        animateLoading.StopAnimate ();
    }
}
