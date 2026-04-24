using UnityEngine;

public class DeadArea : MonoBehaviour
{
    public bool isInRange;

    private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Player"))
    {
        // สั่งหยุด Player ตัวที่เข้ามาเหยียบโดยตรง
        var player = other.GetComponent<PlayerScript>(); // เปลี่ยนชื่อสคริปต์ให้ตรงกับของคุณ
        if (player != null) {
            player.isControlLocked = true; 
        }
        SpriteRenderer parentRenderer = transform.parent.GetComponent<SpriteRenderer>();
        if (parentRenderer != null)
        {
            parentRenderer.enabled = false; // ปิดการวาดภาพ (หายตัว)
        }
    }
}

private void OnTriggerExit2D(Collider2D other)
{
    if (other.CompareTag("Player"))
    {
        var player = other.GetComponent<PlayerScript>();
        if (player != null) {
            player.isControlLocked = true;
        }
        
    }
}
}
