using UnityEngine;

public class TrafficLight : Hazard
{  
    void Start()
    {
        
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
                transform.position += hazardOffset;
                transform.rotation = hazardRotation;
                hasAnim = true;
            }
        }
    }
}