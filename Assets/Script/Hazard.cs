using UnityEngine;

public class Hazard : MonoBehaviour
{
    public float delayTime = 2.0f;
    [HideInInspector] public float timeToWait = 0;
    [HideInInspector] public Vector3 savedPosition;
    [HideInInspector] public Quaternion savedRotation;

    [Header("Goal State")]
    public Vector3 goalPos;
    public Quaternion goatRot;

    // ฟังก์ชันสำหรับสั่งให้ Hazard บันทึกตำแหน่งปัจจุบันของตัวเอง
    void Awake()
    {
        SaveCurrentState();
    }
    public void SaveCurrentState()
    {
        savedPosition = transform.position;
        savedRotation = transform.rotation;
        Debug.Log($"{gameObject.name} บันทึกตำแหน่งและองศาแล้ว!");
    }

    public void ResetState()
    {
        transform.position = savedPosition;
        transform.rotation = savedRotation;
        Debug.Log($"{gameObject.name} รีเซ็ตตำแหน่งแล้ว!");
    }
}