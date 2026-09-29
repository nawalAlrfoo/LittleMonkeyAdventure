using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public Transform respawnPoint;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.LoseLife();
            }

            if (respawnPoint != null)
            {
                collision.transform.position = respawnPoint.position;

                // طريقة آمنة 100% لا تستخدم التنسيق القديم ولا تسبب CS0411
                if (collision.TryGetComponent(out Rigidbody2D rb))
                {
                    rb.linearVelocity = Vector2.zero;
                }
            }
        }
    }
}