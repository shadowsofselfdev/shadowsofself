using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

/// <summary>
/// Manages the functionality of the main menu UI, such as starting the game or exiting.
/// </summary>
public class MainMenuController : MonoBehaviour
{

    [SerializeField] private float fadeInTime = 2.0f;

    void Start()
    {
        // When the main menu loads, tell the fader to fade in from black.
        if (Fader.instance != null)
        {
            Fader.instance.FadeIn(fadeInTime);
        }
    }

    // --- Public Methods (to be called by UI Buttons) ---

    /// <summary>
    /// Exits the application.
    /// Note: This only works in a built version of the game. In the Unity Editor,
    /// it will stop the Play mode.
    /// </summary>
    public void ExitGame()
    {
        // Add a log that will appear in both the editor and the build's log file.
        Debug.Log("ExitGame() method called.");

        // This is a preprocessor directive. The code inside this block will only be
        // included when the game is being run inside the Unity Editor.
        #if UNITY_EDITOR
            Debug.Log("Running in Editor. Setting isPlaying to false.");
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Debug.Log("Running in a build. Calling Application.Quit().");
            Application.Quit();
        #endif
    }

    /*
    --- Placeholder for Future Functionality ---

    /// <summary>
    /// Loads the main gameplay scene. The scene name must match exactly what is
    /// in the Build Settings.
    /// </summary>
    /// <param name="sceneName">The name of the scene to load.</param>
    public void StartGame(string sceneName)
    {
        // Example: SceneManager.LoadScene(sceneName);
    }
    */
}
