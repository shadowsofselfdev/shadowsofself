using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// A singleton component that handles fading the screen to/from black.
/// It persists between scenes.
/// </summary>
public class Fader : MonoBehaviour
{
    public static Fader instance;

    private CanvasGroup canvasGroup;

    void Awake()
    {
        // Singleton pattern: Ensure only one instance of the Fader exists.
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            canvasGroup = GetComponent<CanvasGroup>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Fades the screen from black to clear.
    /// </summary>
    /// <param name="time">The duration of the fade in seconds.</param>
    public Coroutine FadeIn(float time)
    {
        return StartCoroutine(FadeInRoutine(time));
    }

    /// <summary>
    /// Fades the screen from clear to black.
    /// </summary>
    /// <param name="time">The duration of the fade in seconds.</param>
    public Coroutine FadeOut(float time)
    {
        return StartCoroutine(FadeOutRoutine(time));
    }

    private IEnumerator FadeInRoutine(float time)
    {
        // Loop until the alpha is 0 (fully transparent).
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime / time;
            yield return null;
        }

        // Once visible, disable raycast blocking so UI beneath can be clicked.
        canvasGroup.blocksRaycasts = false;
    }

    private IEnumerator FadeOutRoutine(float time)
    {
        // Before fading out, enable raycast blocking to prevent clicks during transition.
        canvasGroup.blocksRaycasts = true;

        // Loop until the alpha is 1 (fully opaque).
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime / time;
            yield return null;
        }
    }
}

