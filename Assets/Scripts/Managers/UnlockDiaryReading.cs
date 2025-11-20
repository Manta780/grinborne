using UnityEngine;

public class UnlockDiaryReading : MonoBehaviour
{
    [Header("Referencia al script del diario")]
    public DiaryInteraction diaryInteraction; // Script que controla leer el diario

    [Header("Opcional")]
    public bool disableTriggerAfterUse = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("El jugador entró a la cabaña. Diario desbloqueado.");

            // Activa la lectura del diario
            if (diaryInteraction != null)
                diaryInteraction.EnableDiary(true);

            // Desactiva el trigger si solo debe funcionar una vez
            if (disableTriggerAfterUse)
                gameObject.SetActive(false);
        }
    }
}
