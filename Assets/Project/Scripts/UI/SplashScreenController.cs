using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenController : MonoBehaviour
{
    [SerializeField] private float loadTime = 0.25f;
    [SerializeField] private float displayTime = 1.0f;

    [SerializeField] private string sceneToLoad = "MainMenu";

    void Start()
    {
        Debug.Log("SplashScreen::Start");
        StartCoroutine(SplashSequence());
    }

    private IEnumerator SplashSequence()
    {
        Fader.instance.GetComponent<CanvasGroup>().alpha = 1;
        yield return new WaitForSeconds(loadTime);
        yield return Fader.instance.FadeOut();
        yield return new WaitForSeconds(displayTime);
        yield return Fader.instance.FadeIn();
        SceneManager.LoadScene(sceneToLoad);
    }
}
