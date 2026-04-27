using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 moveInput;
    public SpriteRenderer spriteRenderer;
<<<<<<< HEAD

    public DeadArea deadArea;
=======
    public Sprite[] directionSprites;
    
    [Header("Bobbing Settings")]
    public float bobSpeed = 10f;  // ความเร็วในการส่าย
    public float bobAmount = 5f;
    [Header("Audio")]
    public AudioSource walkSource;
    public AudioClip sfx;
>>>>>>> JAMES

    public int deathCount;
    public TextMeshProUGUI deathText;
    public float speed = 5f;

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
            // เช็คว่ากดปุ่มเดินอยู่ไหม (เปรียบเทียบกับ Vector2.zero)
            if (moveInput != Vector2.zero)
            {
<<<<<<< HEAD
            }
            else
            {
            }

            if (moveInput.x != 0)
            {
                spriteRenderer.flipX = moveInput.x < 0;
=======
                // --- ส่วนของเสียงเดิน ---
                if (!walkSource.isPlaying) // ถ้าลำโพงยังไม่ดัง
                {
                    walkSource.clip = sfx; // ใส่แผ่นเสียง
                    walkSource.Play();    // สั่งเล่น
                }
                // ---------------------

                // ส่วนของ Sprite (ที่เจมส์เขียนไว้)
                if (Input.GetAxisRaw("Horizontal") < 0) 
                {
                    spriteRenderer.sprite = directionSprites[0];
                }
                else if (Input.GetAxisRaw("Horizontal") > 0) 
                {
                    spriteRenderer.sprite = directionSprites[1];
                }
                else if (Input.GetAxisRaw("Vertical") < 0) 
                {
                    spriteRenderer.sprite = directionSprites[2];
                }
                else if (Input.GetAxisRaw("Vertical") > 0) 
                {
                    spriteRenderer.sprite = directionSprites[3];
                }

                rb.linearVelocity = moveInput * speed;
                float tilt = Mathf.Sin(Time.time * bobSpeed) * bobAmount;
                transform.rotation = Quaternion.Euler(0, 0, tilt);
            }
            else
            {
                // ถ้าไม่ได้กดเดินเลย ให้หยุดเสียง
                rb.linearVelocity = Vector2.zero;
                if (walkSource.isPlaying) 
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * 10f);
                    walkSource.Stop();
                }
>>>>>>> JAMES
            }
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
<<<<<<< HEAD
            isPlayerRunning = false;
=======
            if (walkSource.isPlaying) 
            {
                walkSource.Stop();
            }
>>>>>>> JAMES
        }
    }
}