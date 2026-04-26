using System.Numerics;
using UnityEngine;
public class Bear : Hazard

{  
    public bool isSound = false;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (timeToWait > 0)
        {  
            spriteRenderer.enabled = true;
            player.transform.position = savedPosition;
            player.transform.position += playerOffset;
            if (!isSound)
            {
                actionSource.PlayOneShot(sfx);
                isSound = true;
            }
            if (timeToWait >= playerAnimTime && !hasPAnim)
                {
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
                isSound = false;
                actionSource.Stop();
            }
        }
    }
}