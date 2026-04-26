using System.Numerics;
using UnityEngine;
public class CarFront : Hazard

{  
    void Start()
    {
        
    }
    void Update()
    {
        if (timeToWait > 0)
        {  
            player.transform.position = savedPosition;
            player.transform.position += playerOffset;
            
            if (timeToWait >= playerAnimTime && !hasPAnim)
                {
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
        }
    }
}