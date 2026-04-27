using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneSimple : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 1f; // กันค้างถ้าเคย pause
            SceneManager.LoadScene("OuttroVideo");
        }
    }
}