using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // สำคัญมากสำหรับโหลดฉากกวัก!

public class MainMenuControl : MonoBehaviour
{
    [Header("Panels")]
    public GameObject settingPanel;
    public GameObject informationPanel;
    public GameObject howToPlayPanel;

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
        // --- 1. จัดการระบบ BGM ---
        float savedBgm = PlayerPrefs.GetFloat("BGMVolume", 0.5f);
        if (bgmSlider != null)
        {
            bgmSlider.value = savedBgm / maxBgmVolume;
            bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        }
        SetBGMVolume(bgmSlider != null ? bgmSlider.value : 1f);

        // --- 2. จัดการระบบ SFX ---
        float savedSfx = PlayerPrefs.GetFloat("SFXVolume", 0.8f);
        if (sfxSlider != null)
        {
            sfxSlider.value = savedSfx;
            sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        }
        SetSFXVolume(sfxSlider != null ? sfxSlider.value : 0.8f);

        CloseAllPanels();
        AudioListener.volume = 1.0f;
    }

    // --- ฟังก์ชันโหลด Scene แบบพิมพ์ชื่อเอาเองใน Unity กวัก! ---
    public void LoadTargetScene(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("นายลืมพิมพ์ชื่อ Scene ในช่อง OnClick หรือเปล่ากวัก?!");
        }
    }

    public void PlayCustomSound(AudioClip clip)
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

    // --- ระบบจัดการหน้าจอ (ตัด LevelSelect ออกแล้วกวัก!) ---
    public void OpenSetting()
    {
        CloseAllPanels();
        if (settingPanel != null) settingPanel.SetActive(true);
    }

    public void OpenInformation() // เพิ่มฟังก์ชันเปิด Info ให้ด้วยกวัก
    {
        CloseAllPanels();
        if (informationPanel != null) informationPanel.SetActive(true);
    }

    public void OpenHowToPlay() // เพิ่มฟังก์ชันเปิด HowToPlay ให้ด้วยกวัก
    {
        CloseAllPanels();
        if (howToPlayPanel != null) howToPlayPanel.SetActive(true);
    }

    public void CloseAllPanels()
    {
        if (settingPanel != null) settingPanel.SetActive(false);
        if (informationPanel != null) informationPanel.SetActive(false);
        if (howToPlayPanel != null) howToPlayPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("กวัก! ออกเกมแล้วนะนาย");
    }
}