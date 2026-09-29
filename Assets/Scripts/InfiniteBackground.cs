using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public Transform cam;
    [Range(0f, 1f)]
    public float parallaxEffect = 0.5f;

    // ربط مباشر من الـ Inspector بدون أي أخطاء بحث برمجية
    public SpriteRenderer spriteRenderer;

    private float length;
    private float startPos;
    public 
    void Start()
    {
        startPos = transform.position.x;

        if (spriteRenderer != null && spriteRenderer.sprite != null)
        {
            length = spriteRenderer.bounds.size.x;
        }
        else
        {
            length = 20f;
        }

        if (cam == null && Camera.main != null)
        {
            cam = Camera.main.transform;
        }
    }

    void LateUpdate()
    {
        if (cam == null) return;

        float temp = (cam.position.x * (1 - parallaxEffect));
        float dist = (cam.position.x * parallaxEffect);

        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        if (length > 0f)
        {
            if (temp > startPos + length)
            {
                startPos += length;
            }
            else if (temp < startPos - length)
            {
                startPos -= length;
            }
        }
    }
}