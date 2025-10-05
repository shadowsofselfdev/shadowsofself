using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controls the splash screen sequence: waits for a set time, then fades out
/// and loads the main menu.
/// </summary>
public class SplashScreenController : MonoBehaviour
{
    [Header("Timings")]
    [SerializeField] private float displayTime = 2.0f;
    [SerializeField] private float fadeTime = 2.0f;

    [Header("Scene Management")]
    [SerializeField] private string sceneToLoad = "MainMenu";

    void Start()
    {
        StartCoroutine(SplashSequence());
    }

    private IEnumerator SplashSequence()
    {
        // Ensure the fader starts transparent for the splash screen to be visible.
        if (Fader.instance != null)
        {
            Fader.instance.GetComponent<CanvasGroup>().alpha = 0;
        }

        // Wait for the specified display time.
        yield return new WaitForSeconds(displayTime);

        // Tell the Fader to fade out.
        yield return Fader.instance.FadeOut(fadeTime);

        // Load the main menu scene.
        SceneManager.LoadScene(sceneToLoad);
    }
}
