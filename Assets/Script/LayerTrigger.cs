using UnityEngine;

public class SimpleLayer : MonoBehaviour
{
    public int orderRight = 2;   // อยู่ด้านขวา = อยู่หน้า
    public int orderLeft = 0;    // อยู่ด้านซ้าย = อยู่หลัง

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // ถ้า player อยู่ "ขวา" ของ trigger
            if (collision.transform.position.x > transform.position.x)
            {
                SetOrderInLayer(collision.gameObject, orderRight);
            }
            else // อยู่ซ้าย
            {
                SetOrderInLayer(collision.gameObject, orderLeft);
            }
        }
    }

    void SetOrderInLayer(GameObject obj, int order)
    {
        SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.sortingOrder = order;
        }
    }
}