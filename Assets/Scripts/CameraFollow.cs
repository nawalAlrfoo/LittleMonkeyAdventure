using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // القرد (Player)
    public float smoothSpeed = 0.125f; // سرعة سلاسة الحركة
    public Vector3 offset; // المسافة بين الكاميرا والقرد

    void LateUpdate()
    {
        if (target != null)
        {
            // الموقع المستهدف للكاميرا مع الحفاظ على موقع الـ Z ثابت
            Vector3 desiredPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, -10f);

            // التحرك بسلاسة نحو الموقع المطلوب
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}