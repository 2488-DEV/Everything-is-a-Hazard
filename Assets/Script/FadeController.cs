using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeController : MonoBehaviour
{
    public CanvasGroup fadeGroup;
    public float fadeDuration = 1.5f;

    void Start()
    {
        fadeGroup.alpha = 1f;
        fadeGroup.gameObject.SetActive(true);
        StartFadeOut();
    }

    // ฟังก์ชันสำหรับสั่งให้ "จางหายไป" (โชว์เกม)
    public void StartFadeOut()
    {
        StopAllCoroutines(); // หยุด Fade เก่าก่อนถ้ามันทำงานค้างอยู่
        StartCoroutine(DoFade(1f, 0f));
    }

    // ฟังก์ชันสำหรับสั่งให้ "มืดลง" (ปิดเกม/ตาย)
    public void StartFadeIn()
    {
        StopAllCoroutines();
        fadeGroup.gameObject.SetActive(true); // เปิด Object ขึ้นมาก่อน
        StartCoroutine(DoFade(0f, 1f));
    }

    // Coroutine กลางที่คุมทั้งเข้าและออก
    IEnumerator DoFade(float startAlpha, float endAlpha)
    {
        float currentTime = 0f;
        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            fadeGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, currentTime / fadeDuration);
            yield return null;
        }

        fadeGroup.alpha = endAlpha;
        
        // ถ้าจางหายจนหมดแล้ว ให้ปิด Object ไปเลยเพื่อไม่ให้ขวางเมาส์
        if (endAlpha == 0) fadeGroup.gameObject.SetActive(false);
    }
}