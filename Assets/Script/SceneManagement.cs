using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager_2 : MonoBehaviour
{
    public GameObject pausePanel; // ลาก UI Panel มาวางตรงนี้

    private bool isPaused = false;

    void Start()
    {
        if (pausePanel != null)
            pausePanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (pausePanel != null)
            pausePanel.SetActive(isPaused);

        Time.timeScale = isPaused ? 0f : 1f;
    }

    public void ResumeGame()
    {
        isPaused = false;

        if (pausePanel != null)
            pausePanel.SetActive(false);

        Time.timeScale = 1f;
    }

    public void BackToMenu(string sceneName)
    {
        Time.timeScale = 1f; // สำคัญมาก กันเกมค้าง
        SceneManager.LoadScene(sceneName);
    }
}