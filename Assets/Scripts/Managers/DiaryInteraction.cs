using UnityEngine;

public class DiaryInteraction : MonoBehaviour
{
    private bool canReadDiary = false;
    private bool diaryOpen = false;
    private bool isNearDiary = false;

    [Header("Sonido al cerrar el diario")]
    public AudioSource audioSource;     // AudioSource para reproducir efectos
    public AudioClip closeDiarySound;   // Sonido al cerrar

    public void EnableDiary(bool state)
    {
        canReadDiary = state;
        Debug.Log("Lectura del diario: " + (state ? "Activada" : "Desactivada"));
    }

    public void SetNearDiary(bool state)
    {
        isNearDiary = state;
    }

    private void Update()
    {
        if (canReadDiary && isNearDiary && !diaryOpen && Input.GetKeyDown(KeyCode.E))
        {
            AbrirDiario();
        }

        if (diaryOpen && Input.GetKeyDown(KeyCode.Escape))
        {
            CerrarDiario();
        }
    }

    void AbrirDiario()
    {
        DiaryUI.Instance.OpenDiary();
        diaryOpen = true;
    }

    void CerrarDiario()
    {
        DiaryUI.Instance.CloseDiary();
        diaryOpen = false;

        // ▶️ Reproducir sonido al cerrar el diario
        if (audioSource && closeDiarySound)
        {
            audioSource.PlayOneShot(closeDiarySound);
        }

        // 🔥 Activar evento del monstruo SOLO la primera vez
        if (!QuestManager2.Instance.diaryRead)
        {
            QuestManager2.Instance.ReadDiary();
            MonsterEvent.Instance.SpawnMonsterEvent();
        }
    }
}
