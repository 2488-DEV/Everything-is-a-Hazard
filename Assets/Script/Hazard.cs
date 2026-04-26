using UnityEngine;
public class Hazard : MonoBehaviour
{
    public float delayTime = 2.0f;
    [HideInInspector] public bool hasAnim;
    [HideInInspector] public bool hasPAnim;
    [HideInInspector] public PlayerScript player;
    [HideInInspector] public SpriteRenderer playerRenderer;
    [HideInInspector] public float timeToWait = 0;
    [HideInInspector] public Vector3 savedPosition;
    [HideInInspector] public Quaternion savedRotation;

    [Header("Audio")]
    public AudioSource actionSource;
    public AudioClip sfx;

    [Header("Hazard Object")]
    public Vector3 hazardOffset;
    public Quaternion hazardRotation;
    public float hazardAnimTime = 1.0f;
   
    [Header("Player Object")]
    public Vector3 playerOffset;
    public Quaternion playerRotation;
    public float playerAnimTime = 1.0f;
    private void OnValidate()

    {
        // ถ้า animTime มากกว่า delayTime ให้เซตให้เท่ากับ delayTime
        if (hazardAnimTime > delayTime)
        {
            hazardAnimTime = delayTime;
        }
        if (hazardAnimTime < 0)
        {
            hazardAnimTime = 0;
        }
        if (playerAnimTime < 0)
        {
            playerAnimTime = 0;
        }
        if (delayTime < 0)
        {
            delayTime = 0;
        }
    }
    // ฟังก์ชันสำหรับสั่งให้ Hazard บันทึกตำแหน่งปัจจุบันของตัวเอง
    void Awake()
    {
        SaveCurrentState();
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.GetComponent<PlayerScript>();
            playerRenderer = playerObj.GetComponent<SpriteRenderer>();
        }

    }
    public void SaveCurrentState()
    {
        savedPosition = transform.position;
        savedRotation = transform.rotation;
        Debug.Log($"{gameObject.name} บันทึกตำแหน่งและองศาแล้ว!");
    }
    public void ResetState()
    {
        transform.position = savedPosition;
        transform.rotation = savedRotation;
        Debug.Log($"{gameObject.name} รีเซ็ตตำแหน่งแล้ว!");
    }
}