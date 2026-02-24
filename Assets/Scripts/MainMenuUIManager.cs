using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUIManager : MonoBehaviour
{
    [Header("Menu Buttons")]
    public Button playButton;
    public Button quitButton;

    [Header("Scene Settings")]
    public string gameSceneName = "GameScene";

    void Start()
    {
        if (playButton != null)
        {
            playButton.onClick.AddListener(PlayGame);
        }
        else
        {
            Debug.LogWarning("Play Button is not assigned in the MainMenuUIManager!");
        }

        if (quitButton != null)
        {
            quitButton.onClick.AddListener(QuitGame);
        }
        else
        {
            Debug.LogWarning("Quit Button is not assigned in the MainMenuUIManager!");
        }
    }

    private void PlayGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(gameSceneName);
    }

    private void QuitGame()
    {
        Debug.Log("Quitting Game...");

        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}