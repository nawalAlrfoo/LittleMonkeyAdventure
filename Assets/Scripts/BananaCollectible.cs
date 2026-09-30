using UnityEngine;

public class BananaCollectible : MonoBehaviour
{
    public int pointValue = 1;

   
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.AddScore(1);
            }

            // تشغيل صوت الموزة
            if (SoundManager.Instance != null)
            {
                SoundManager.Instance.PlayBananaSound();
            }

            Destroy(gameObject);
        }
    }
}