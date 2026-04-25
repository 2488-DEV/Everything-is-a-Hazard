using UnityEngine;

public class VendingMachine : Hazard
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
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
