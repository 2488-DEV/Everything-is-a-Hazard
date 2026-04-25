using UnityEngine;

public class DeadArea : MonoBehaviour
{
    public bool isInRange;
    private float timeToWait = 0f;
    private PlayerScript player;
    private Hazard hazard;

    private Transform respawnPoint;

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
            }
        }
    }
}
