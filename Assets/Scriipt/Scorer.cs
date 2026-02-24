using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scorer : MonoBehaviour
{
    int score = 0;
    public TextMeshProUGUI theScore;
    public float scoreOT = 1f;

    public float rampSpeed = 0.01f;

    float scoreTimer;
    float scorePerSecond = 0f;

    public int life = 3;
    public int amount = 1;

    void Update()
    {
        scorePerSecond += rampSpeed * Time.deltaTime; // ramps up slowly
        scoreTimer += Time.deltaTime * scorePerSecond;

        if (scoreTimer >= 1f)
        {
            int points = Mathf.FloorToInt(scoreTimer);
            scoreTimer -= points;
            score += points;
            theScore.text = "Score: " + score.ToString() + "\nHP: " + life;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("bot"))
        {
            score -= 3;
            Debug.Log("the score is " + score);

            life -= amount;
            theScore.text = "Score: " + score.ToString() + "\nHP: " + life;

            if (life <= 0)
            {
                FreezeGame();
            }
        }
    }

    IEnumerator ScoreAdder()
    {
        
        score++;
        Debug.Log("the score is " + score);

        theScore.text = "Score: " + score.ToString() + "\nHP: " + life;
        yield return new WaitForSeconds(1f);
    }

    void FreezeGame()
    {
        Time.timeScale = 0f;
        Debug.Log("Game Paused - Player Dead");
    }
}
