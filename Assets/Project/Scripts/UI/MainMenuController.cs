using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

/// <summary>
/// Manages the functionality of the main menu UI, such as starting the game or exiting.
/// </summary>
public class MainMenuController : MonoBehaviour
{
    // --- Public Methods (to be called by UI Buttons) ---

    /// <summary>
    /// Exits the application.
    /// Note: This only works in a built version of the game. In the Unity Editor,
    /// it will stop the Play mode.
    /// </summary>
    public void ExitGame()
    {
        // This is a preprocessor directive. The code inside this block will only be
        // included when the game is being run inside the Unity Editor.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
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
