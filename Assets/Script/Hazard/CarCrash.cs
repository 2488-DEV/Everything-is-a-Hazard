using System.Numerics;
using UnityEngine;
public class CarCrash : Hazard

{  
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (timeToWait > 0)
        {  
            player.transform.position = savedPosition;
            player.transform.position += playerOffset;
            
            if (timeToWait >= playerAnimTime && !hasPAnim)
                {
                    spriteRenderer.enabled = true;
                    playerRenderer.enabled = false;
                    player.transform.rotation = playerRotation;
                    hasPAnim = true;
                }
            if (timeToWait >= hazardAnimTime && !hasAnim)
            {  
                transform.position += hazardOffset;
                transform.rotation = hazardRotation;
                hasAnim = true;
            }
            if (timeToWait >= (delayTime - 0.01))
            {
                spriteRenderer.enabled = false;
            }
        }
    }
}