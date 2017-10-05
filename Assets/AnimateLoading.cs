using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimateLoading : MonoBehaviour {

    const float animateDelay = 0.1f;

    private void Start()
    {
       
    }

    public void StartAnimate ()
    {
        StopAllCoroutines ();
        StartCoroutine (Animate ());
    }

    public void StopAnimate ()
    {
        StopAllCoroutines ();
    }

    IEnumerator Animate ()
    {
        while (true)
        {
            Text loadingText = GetComponent<Text> ();
            loadingText.text = "Loading";
            yield return new WaitForSeconds (animateDelay);
            loadingText.text = "Loading.";
            yield return new WaitForSeconds (animateDelay);
            loadingText.text = "Loading..";
            yield return new WaitForSeconds (animateDelay);
            loadingText.text = "Loading...";
            yield return new WaitForSeconds (0.3f);
        }
    }
}
