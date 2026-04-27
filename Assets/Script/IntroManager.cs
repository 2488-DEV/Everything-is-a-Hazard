using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public VideoPlayer introVideo;
    public string nextSceneName = "TestInGame"; // ชื่อ Scene ที่จะไปต่อ

    void Start()
    {
        // สั่งให้ทำงานเมื่อวิดีโอเล่นจนจบ
        introVideo.loopPointReached += LoadNextScene;
    }

    void LoadNextScene(VideoPlayer vp)
    {
        SceneManager.LoadScene(nextSceneName);
    }
}