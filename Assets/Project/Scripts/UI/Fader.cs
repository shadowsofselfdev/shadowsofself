using System.Collections;
using UnityEngine;

public class Fader : MonoBehaviour
{
    [SerializeField] private float fadeTime = 0.25f;

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
            canvasGroup.blocksRaycasts = false; // Don't block clicks.
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Black to clear
    public Coroutine FadeOut()
    {
        return StartCoroutine(FadeOutRoutine());
    }

    private IEnumerator FadeOutRoutine()
    {
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime / fadeTime;
            yield return null;
        }
    }

    // Clear to black
    public Coroutine FadeIn()
    {
        return StartCoroutine(FadeInRoutine());
    }

    private IEnumerator FadeInRoutine()
    {
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime / fadeTime;
            yield return null;
        }
    }
}

