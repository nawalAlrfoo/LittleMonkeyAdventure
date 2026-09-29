using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // مهم جداً للتعامل مع صور القلوب

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int score = 0;
    public int lives = 3;
    public int winningScore = 20;

    public TextMeshProUGUI scoreText;

    // استبدلنا نص الأرواح بمصفوفة صور القلوب
    public GameObject[] hearts;

    public GameObject winPanel;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateUI();
        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();

        if (score >= winningScore)
        {
            WinGame();
        }
    }

    public void LoseLife()
    {
        lives--;
        UpdateUI();

        if (lives <= 0)
        {
            GameOver();
        }
    }

    void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Bananas: " + score + " / " + winningScore;
        }

        // تحديث ظهور القلوب بناءً على عدد الأرواح المتبقية
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < lives)
            {
                hearts[i].SetActive(true); // إظهار القلب إذا كان ضمن الأرواح المتبقية
            }
            else
            {
                hearts[i].SetActive(false); // إخفاء القلب إذا خسر روحه
            }
        }
    }

    void WinGame()
    {
        Debug.Log("🎉 مبروك! لقد فزت باللعبة!");
        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }
        Time.timeScale = 0f;
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}