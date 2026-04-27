using UnityEngine;
using TMPro;
using System.Collections;

public class VNDialogue : MonoBehaviour
{
    public GameObject dialogueBox;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI contentText;

    [Header("Audio Settings")]
    public AudioSource audioSource;
    public AudioClip typingSound;
    public AudioClip nextClickSound;

    [Header("Text Settings")]
    [TextArea(3, 10)]
    public string[] sentences;
    public float typingSpeed = 0.04f;

    [Header("Trigger Settings")]
    public bool playOnStart = true; // ตั้งเป็น true ไว้เลยกวัก!
    private bool hasPlayed = false;
    private Coroutine typingCoroutine;

    private int index;
    private bool isTyping;

    void Start()
    {
        // รีเซ็ตค่าใหม่ทุกครั้งที่เริ่ม Scene กวัก!
        index = 0;
        isTyping = false;

        if (playOnStart)
        {
            StartConversation();
        }
        else
        {
            if (dialogueBox != null) dialogueBox.SetActive(false);
        }
    }

    public void StartConversation()
    {
        if (sentences == null || sentences.Length == 0) return;

        hasPlayed = true;
        index = 0;

        if (dialogueBox != null) dialogueBox.SetActive(true); // เปิดกล่องคำพูดกวัก!

        if (typingCoroutine != null) StopCoroutine(typingCoroutine);
        typingCoroutine = StartCoroutine(TypeText(sentences[index]));
    }

    // --- ส่วนการทำงานหลักเหมือนเดิมแต่เช็ค Error ให้ละเอียดขึ้นกวัก ---

    void Update()
    {
        if (dialogueBox != null && dialogueBox.activeInHierarchy && Input.GetKeyDown(KeyCode.Space))
        {
            if (isTyping)
            {
                FinishLineImmediately();
            }
            else
            {
                if (nextClickSound != null && audioSource != null)
                {
                    audioSource.PlayOneShot(nextClickSound);
                }
                NextSentence();
            }
        }
    }

    IEnumerator TypeText(string line)
    {
        isTyping = true;
        contentText.text = "";

        foreach (char letter in line.ToCharArray())
        {
            if (dialogueBox == null || !dialogueBox.activeInHierarchy) yield break;

            contentText.text += letter;

            if (letter != ' ' && typingSound != null && audioSource != null)
            {
                if (!audioSource.isPlaying) audioSource.PlayOneShot(typingSound);
            }
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }

    void FinishLineImmediately()
    {
        if (typingCoroutine != null) StopCoroutine(typingCoroutine);
        if (index < sentences.Length) contentText.text = sentences[index];
        isTyping = false;
    }

    void NextSentence()
    {
        if (index < sentences.Length - 1)
        {
            index++;
            if (typingCoroutine != null) StopCoroutine(typingCoroutine);
            typingCoroutine = StartCoroutine(TypeText(sentences[index]));
        }
        else
        {
            if (dialogueBox != null) dialogueBox.SetActive(false);
            Debug.Log("จบการสนทนาแล้วนาย!");
        }
    }

    public void StartTriggerDialogue(string name, string[] newSentences)
    {
        if (nameText != null) nameText.text = name;
        sentences = newSentences;
        StartConversation();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasPlayed)
        {
            StartConversation();
            BoxCollider2D col = GetComponent<BoxCollider2D>();
            if (col != null) col.enabled = false;
        }
    }
}