using UnityEngine;
using TMPro;

public class DiaryUI : MonoBehaviour
{
    public static DiaryUI Instance;

    public GameObject diaryPanel;       // El panel del libro
    public TextMeshProUGUI diaryText;   // Texto dentro del libro
    public string fullDiaryText;        // Aquí pondrás el texto que me pases

    private bool isOpen = false;

    private void Awake()
    {
        Instance = this;
        diaryPanel.SetActive(false);
    }

    private void Update()
    {
        if (isOpen && Input.GetKeyDown(KeyCode.E))
        {
            CloseDiary();
        }
    }

    public void OpenDiary()
    {
        diaryPanel.SetActive(true);
        diaryText.text = fullDiaryText;
        isOpen = true;

        Time.timeScale = 0f; // congelar jugador
    }

    public void CloseDiary()
    {
        diaryPanel.SetActive(false);
        isOpen = false;

        Time.timeScale = 1f; // descongelar jugador
    }
}
