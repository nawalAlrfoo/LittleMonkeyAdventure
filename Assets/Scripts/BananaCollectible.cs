using UnityEngine;

public class BananaCollectible : MonoBehaviour
{
    public int pointValue = 1;

    void OnTriggerEnter2D(Collider2D collision)
    {
        // اطبعي اسم الكائن الذي لمس الموزة في الـ Console
        Debug.Log("Collided with: " + collision.gameObject.name + " | Tag: " + collision.tag);

        if (collision.CompareTag("Player"))
        {
            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.AddScore(pointValue);
            }
            Destroy(gameObject);
        }
    }
}