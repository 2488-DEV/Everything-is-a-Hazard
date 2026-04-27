using UnityEngine;

public class DeadArea : MonoBehaviour
{
    public bool isInRange;
    private float timeToWait = 0f;
    private PlayerScript player;
    private Hazard hazard;
    private Transform respawnPoint;
    public FadeController fadeController;

    [Header("Audio")]
    public AudioSource actionSource;
    public AudioClip sfx;
    void Start()
    {
        hazard = GetComponentInParent<Hazard>();
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.GetComponent<PlayerScript>();
        }

        if (respawnPoint == null)
        {
            GameObject respawnObj = GameObject.Find("RespawnPoint");
            if (respawnObj != null)
            {
                respawnPoint = respawnObj.transform;
            }
        }
    }
    void Update()
    {
        if (timeToWait > 0)
        {
            timeToWait -= Time.deltaTime;
            hazard.timeToWait += Time.deltaTime;

            Debug.Log("เวลาที่เหลือ: " + timeToWait.ToString("f2"));

            if (timeToWait <= 0)
            {
                timeToWait = 0;
                hazard.timeToWait = 0;
                Debug.Log("ครบเวลาแล้ว!");
                player.isControlLocked = false;
                player.transform.position = respawnPoint.position;
                player.transform.rotation = Quaternion.Euler(0f , 0f , 0f);
                hazard.ResetState();
                hazard.hasAnim = false;
                hazard.hasPAnim = false;
                player.deathCount += 1;
                player.UpdateDeathCount();
                hazard.playerRenderer.enabled = true;
                actionSource.PlayOneShot(sfx);
                player.spriteRenderer.sprite = player.directionSprites[2];
                fadeController.fadeGroup.alpha = 1f;
                fadeController.fadeGroup.gameObject.SetActive(true);
                fadeController.StartFadeOut();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (player != null) {
                player.isControlLocked = true; 
                timeToWait = hazard.delayTime;
                char firstLetter = transform.parent.name[0];
                string pName = transform.parent.name;
                if (firstLetter == 'L') 
                {
                    player.spriteRenderer.sprite = player.directionSprites[1];
                }
                else if (firstLetter == 'R') 
                {
                    player.spriteRenderer.sprite = player.directionSprites[0];
                }
                else if (pName.Contains("Up"))
                {
                    player.spriteRenderer.sprite = player.directionSprites[2];
                }
                else if (pName.Contains("Down"))
                {
                    player.spriteRenderer.sprite = player.directionSprites[3];
                }
            }
        }
    }
}
