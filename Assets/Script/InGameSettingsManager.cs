using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections; // อย่าลืมใส่บรรทัดนี้เพื่อใช้ Coroutine นะกวัก!

public class InGameSettingsManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject settingPanel;

    [Header("Audio Mixer")]
    public AudioMixer myMixer;

    [Header("BGM Settings")]
    public AudioSource bgmSource;
    public Slider bgmSlider;
    private float maxBgmVolume = 0.5f;

    [Header("SFX Settings")]
    public Slider sfxSlider;
    public AudioSource sfxSource;

    void Start()
    {
        float savedBgm = PlayerPrefs.GetFloat("BGMVolume", 0.5f);
        if (bgmSlider != null)
        {
            bgmSlider.value = savedBgm / maxBgmVolume;
            bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        }
        SetBGMVolume(bgmSlider != null ? bgmSlider.value : (savedBgm / maxBgmVolume));

        float savedSfx = PlayerPrefs.GetFloat("SFXVolume", 0.8f);
        if (sfxSlider != null)
        {
            sfxSlider.value = savedSfx;
            sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        }
        SetSFXVolume(sfxSlider != null ? sfxSlider.value : savedSfx);

        if (settingPanel != null) settingPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleSetting();
        }
    }

    // ฟังก์ชันสำหรับเปิด/ปิด Setting (ใช้กับ ESC และปุ่มปิดได้เลย)
    public void ToggleSetting()
    {
        if (settingPanel != null)
        {
            bool willBeActive = !settingPanel.activeSelf;
            settingPanel.SetActive(willBeActive);

            // ถ้าเปิดหน้าจอให้หยุดเวลา (0), ถ้าปิดหน้าจอให้เวลาเดินต่อ (1)
            Time.timeScale = willBeActive ? 0f : 1f;
        }
    }

    // ฟังก์ชันนี้ไว้ลากใส่ปุ่ม Close (รูปกากบาท) โดยเฉพาะ
    public void CloseSetting()
    {
        if (settingPanel != null) settingPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    // --- ส่วนการกลับหน้าเมนูแบบดีเลย์ 2 วิกวัก ---
    public void BackToMenuWithDelay(string menuSceneName)
    {
        StartCoroutine(DelayMenuLoad(menuSceneName));
    }

    private IEnumerator DelayMenuLoad(string menuSceneName)
    {
        // สำคัญ: ต้องรีเซ็ต TimeScale เป็น 1 ก่อน ไม่งั้น Coroutine จะไม่ทำงานหรือฉากใหม่จะค้าง!
        Time.timeScale = 1f;

        Debug.Log("กำลังกลับหน้าเมนูใน 2 วินาทีกวัก...");
        yield return new WaitForSeconds(2.0f);

        SceneManager.LoadScene(menuSceneName);
    }

    public void PlayButtonSound(AudioClip clip)
    {
        if (sfxSource != null && clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }

    public void SetBGMVolume(float sliderValue)
    {
        float finalVolume = sliderValue * maxBgmVolume;
        if (myMixer != null)
        {
            float dB = Mathf.Log10(Mathf.Clamp(finalVolume, 0.0001f, 1f)) * 20;
            myMixer.SetFloat("MusicVol", dB);
        }
        if (bgmSource != null) bgmSource.volume = finalVolume;
        PlayerPrefs.SetFloat("BGMVolume", finalVolume);
    }

    public void SetSFXVolume(float sliderValue)
    {
        if (myMixer != null)
        {
            float dB = Mathf.Log10(Mathf.Clamp(sliderValue, 0.0001f, 1f)) * 20;
            myMixer.SetFloat("SFXVol", dB);
        }
        PlayerPrefs.SetFloat("SFXVolume", sliderValue);
    }
}