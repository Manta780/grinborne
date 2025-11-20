using UnityEngine;

public class UnlockDiaryReading : MonoBehaviour
{
    [Header("Referencia al script del diario")]
    public DiaryInteraction diaryInteraction;

    [Header("Opcional")]
    public bool disableTriggerAfterUse = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("El jugador entró a la cabaña. Diario desbloqueado.");

            if (diaryInteraction != null)
                diaryInteraction.EnableDiary(true);

            if (disableTriggerAfterUse)
                gameObject.SetActive(false);
        }
    }
}
