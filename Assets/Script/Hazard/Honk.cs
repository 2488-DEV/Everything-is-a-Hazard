using System.Numerics;
using UnityEngine;
public class Honk : Hazard

{  
    private GameObject lightObj;
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
                    player.transform.rotation = playerRotation;
                    hasPAnim = true;
                }
            if (timeToWait >= hazardAnimTime && !hasAnim)
            {  
                actionSource.PlayOneShot(sfx);
                transform.Find("Light1").gameObject.SetActive(true);
                transform.Find("Light2").gameObject.SetActive(true);
                transform.position += hazardOffset;
                transform.rotation = hazardRotation;
                hasAnim = true;
            }
            if (timeToWait >= (delayTime - 0.01))
            {
                transform.Find("Light1").gameObject.SetActive(false);
                transform.Find("Light2").gameObject.SetActive(false);
            }
        }
    }
}