using UnityEngine;

public class TrafficLight : Hazard
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
            float progress = 1f - (timeToWait / delayTime);

        // แก้ตรงนี้: เริ่มจาก 0 ไปหา 90
            float currentZ = Mathf.Lerp(90f, 00f, progress);

            transform.rotation = Quaternion.Euler(0, 0, currentZ);
            if (timeToWait >= delayTime)
            {
                ResetState();
            }
        }
    }
}
