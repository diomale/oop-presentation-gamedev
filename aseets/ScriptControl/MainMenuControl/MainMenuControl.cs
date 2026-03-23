using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;

    // Function to load a specific scene by its name
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Example function to start the game, loading the first level
    public void StartGame()
    {
        // Replace "Level_1" with your actual first scene name
        SceneManager.LoadScene(sceneToLoad);
    }

    // Function to quit the application
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is quitting..."); // Only visible in the Editor
    }

    // Function to continue the game from the last saved scene
    public void ContinueGame()
    {
        if (PlayerPrefs.HasKey("SavedScene"))
        {
            string lastScene = PlayerPrefs.GetString("SavedScene");
            SceneManager.LoadScene(lastScene);
        }
        else
        {
            // If no save exists, start a new game
            StartGame();
        }
    }
}
