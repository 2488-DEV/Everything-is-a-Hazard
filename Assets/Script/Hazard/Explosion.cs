using UnityEngine;
public class Explosion : Hazard

{  
    private SpriteRenderer spriteRenderer;
    private GameObject explosionObj;
    
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
                transform.Find("Explosion").gameObject.SetActive(true);
                transform.position += hazardOffset;
                transform.rotation = hazardRotation;
                hasAnim = true;
            }
            if (timeToWait >= (delayTime - 0.01))
            {
                transform.Find("Explosion").gameObject.SetActive(false);
            }
        }
    }
}