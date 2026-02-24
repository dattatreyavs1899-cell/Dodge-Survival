using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InGameUIManager : MonoBehaviour
{
    public static InGameUIManager instance;

    [Header("Game Over UI")]
    public GameObject gameOverPanel;
    public TextMeshProUGUI finalScoreText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    public void ShowGameOverScreen(int finalScore)
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            finalScoreText.text = "Final Score: " + finalScore.ToString();

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }


    public void RetryButton()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("MainMenu");
    }
}