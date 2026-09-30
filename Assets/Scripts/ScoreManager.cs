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



    void UpdateUI()
    {
        // تحديث عداد النقاط إذا كان موجوداً
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }

        // تحديث صور القلوب بطريقة آمنة
        for (int i = 0; i < hearts.Length; i++)
        {
            if (hearts[i] != null)
            {
                if (i < lives)
                {
                    hearts[i].SetActive(true); // إظهار القلب إذا كان عدد الأرواح يكفي
                }
                else
                {
                    hearts[i].SetActive(false); // إخفاء القلب إذا تم خسارته
                }
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
    public void LoseLife()
    {
        lives--;
        UpdateUI();

        // تشغيل صوت خسارة القلب
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.PlayHurtSound();
        }

        if (lives <= 0)
        {
            GameOver();
        }
    }
}