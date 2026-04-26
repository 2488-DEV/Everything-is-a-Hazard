using UnityEngine;

public class Template : Hazard
{
    void Start()
    {

    }

    void Update()
    {
        if (timeToWait > 0)
        {   
            if (timeToWait >= delayTime)
            {
                ResetState();
            }
        }
    }
}
