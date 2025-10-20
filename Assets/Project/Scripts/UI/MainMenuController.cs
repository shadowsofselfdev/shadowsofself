using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private float loadTime = 0.25f;

    void Start()
    {
        Debug.Log("MainMenu::Start");
        StartCoroutine(MainMenuRoutine());
    }

    private IEnumerator MainMenuRoutine()
    {
        yield return new WaitForSeconds(loadTime);
        yield return Fader.instance.FadeOut();
    }

    // --- UI Buttons ---

    public void ExitGame()
    {
        Debug.Log("MainMenu::ExitGame");
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
}
