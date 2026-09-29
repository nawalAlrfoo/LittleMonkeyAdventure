using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    [Header("References")]
    public Rigidbody2D rb;
    public Animator animator;

    private bool isGrounded;

    void Update()
    {
        Keyboard kb = Keyboard.current;
        if (kb == null) return;

        float moveX = 0f;

        // التحقق الدقيق والصارم من حالة الأزرار لمنع الحركة التلقائية
        bool isRightPressed = kb.dKey.isPressed || kb.rightArrowKey.isPressed;
        bool isLeftPressed = kb.aKey.isPressed || kb.leftArrowKey.isPressed;

        if (isRightPressed && !isLeftPressed)
        {
            moveX = 1f;
            // الحفاظ على الحجم الحالي وتوجيه القرد لليمين
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (isLeftPressed && !isRightPressed)
        {
            moveX = -1f;
            // الحفاظ على الحجم الحالي وتوجيه القرد لليسار
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
        {
            moveX = 0f; // إيقاف تام وصارم للحركة عند عدم الضغط
        }

        if (rb != null)
        {
            rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);

            if (animator != null)
            {
                animator.SetFloat("Speed", Mathf.Abs(moveX));
            }

            if ((kb.spaceKey.wasPressedThisFrame || kb.wKey.wasPressedThisFrame || kb.upArrowKey.wasPressedThisFrame) && isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

                if (animator != null)
                {
                    animator.SetTrigger("Jump");
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // التحقق من أن الاصطدام يتم مع الأرضية من الأسفل
        foreach (ContactPoint2D hit in collision.contacts)
        {
            if (hit.normal.y > 0.5f)
            {
                isGrounded = true;
                break;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}