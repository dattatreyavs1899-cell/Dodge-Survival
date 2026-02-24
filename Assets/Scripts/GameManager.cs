using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI Elements")]
    public TextMeshProUGUI scoreText;
    public Image healthBarFill;

    [Header("Score Settings")]
    public float rampSpeed = 0.01f;
    private int score = 0;
    private float scoreTimer;
    private float scorePerSecond = 0f;

    [Header("Health Settings")]
    public int maxHealth = 3;
    private int currentHealth;
    public int damageAmount = 1;

    [Header("Regen Settings")]
    public float delayBeforeRegen = 5f;
    public float regenInterval = 5f;
    public int regenAmount = 1;

    private float timeSinceLastDamage = 0f;
    private float healTimer = 0f;

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
        currentHealth = maxHealth;
        UpdateUI();
    }

    void Update()
    {
        scorePerSecond += rampSpeed * Time.deltaTime;
        scoreTimer += Time.deltaTime * scorePerSecond;

        if (scoreTimer >= 1f)
        {
            int points = Mathf.FloorToInt(scoreTimer);
            scoreTimer -= points;
            score += points;

            UpdateUI();
        }

        if (currentHealth < maxHealth && currentHealth > 0)
        {
            timeSinceLastDamage += Time.deltaTime;

            if (timeSinceLastDamage >= delayBeforeRegen)
            {
                healTimer += Time.deltaTime;

                if (healTimer >= regenInterval)
                {
                    Heal(regenAmount);
                    healTimer = 0f;
                }
            }
        }
    }

    private void UpdateUI()
    {
        scoreText.text = "Score: " + score.ToString();

        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = (float)currentHealth / maxHealth;
        }
    }

    void FreezeGame()
    {
        Time.timeScale = 0f;

        if (InGameUIManager.instance != null)
        {
            InGameUIManager.instance.ShowGameOverScreen(score);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        score -= 3;
        if(score<0)
            score = 0;

        timeSinceLastDamage = 0f;
        healTimer = 0f;

        UpdateUI();

        if (currentHealth <= 0)
        {
            FreezeGame();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UpdateUI();
    }
}