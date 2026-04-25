using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 moveInput;
    public SpriteRenderer spriteRenderer;
    //public Animator animator;

    public DeadArea deadArea;

    public int deathCount;
    public TextMeshProUGUI deathText;
    public float speed = 5f;
    public float sprint = 3f;

    public bool isPlayerRunning = false;
    public bool isControlLocked = false;

    public void UpdateDeathCount() {
        deathText.text = deathCount + "x";
    }
    void Start()
    {
        deathText.text = deathCount + "x";
    }

    void Update()
    {   

        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput = moveInput.normalized;

        if (!isControlLocked)
        {
            if (Input.GetKey(KeyCode.LeftShift) && moveInput != Vector2.zero)
            {
                rb.linearVelocity = moveInput * speed * sprint;
                isPlayerRunning = true;

            }
            else
            {
                rb.linearVelocity = moveInput * speed;
                isPlayerRunning = false;
            }

            // Animation Logic
            if (moveInput != Vector2.zero)
            {
                //animator.SetBool("IsRunning", true);
            }
            else
            {
                //animator.SetBool("IsRunning", false);
            }

            if (moveInput.x != 0)
            {
                spriteRenderer.flipX = moveInput.x < 0;
            }
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
            isPlayerRunning = false;
            //animator.SetBool("IsRunning", false);
        }
    }
}