using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Audio Source")]
    public AudioSource effectsSource; // لتشغيل الأصوات القصيرة (الموز، الخسارة)
    public AudioSource musicSource;   // لموسيقى الخلفية

    [Header("Audio Clips")]
    public AudioClip bananaClip;
    public AudioClip hurtClip;
    public AudioClip winClip;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ليبقى الصوت مستمراً بين المشاهد إذا أردنا
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBananaSound()
    {
        if (bananaClip != null)
        {
            effectsSource.PlayOneShot(bananaClip);
        }
    }

    public void PlayHurtSound()
    {
        if (hurtClip != null)
        {
            effectsSource.PlayOneShot(hurtClip);
        }
    }

    public void PlayWinSound()
    {
        if (winClip != null)
        {
            effectsSource.PlayOneShot(winClip);
        }
    }
}