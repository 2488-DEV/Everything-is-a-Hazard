using UnityEngine;
public class Meteorite : Hazard

{  
    private SpriteRenderer spriteRenderer;
    private GameObject explosionObj;

    public DeadArea deadArea;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Transform exp = transform.Find("Explosion");
    }
    void Update()
    {
        if (timeToWait > 0)
        {  
            if (timeToWait >= playerAnimTime && !hasPAnim)
                {
                    player.transform.position = savedPosition;
                    player.transform.position += playerOffset;
                    player.transform.rotation = playerRotation;
                    hasPAnim = true;
                }
            if (timeToWait >= hazardAnimTime && !hasAnim)
            {  
                actionSource.PlayOneShot(sfx);
                spriteRenderer.enabled = true;
                transform.Find("Explosion").gameObject.SetActive(true);
                transform.position += hazardOffset;
                transform.rotation = hazardRotation;
                hasAnim = true;
            }
            if (timeToWait >= (delayTime - 0.01))
            {
                spriteRenderer.enabled = false;
                transform.Find("Explosion").gameObject.SetActive(false);
            }
        }
    }
}