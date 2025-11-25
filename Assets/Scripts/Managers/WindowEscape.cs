using UnityEngine;

public class WindowEscape : MonoBehaviour
{
    [Header("Teletransporte")]
    public Transform exitSpawnPoint;   // <-- Asigna aquí el spawn exterior en el inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (QuestManager3.Instance.currentStage == QuestManager3.QuestStage.EscapeThroughWindow)
        {
            // Avanza misión
            QuestManager3.Instance.OnWindowEscaped();

            // TELETRANSPORTA al jugador
            if (exitSpawnPoint != null)
            {
                other.transform.position = exitSpawnPoint.position;
            }
            else
            {
                Debug.LogWarning("No se asignó exitSpawnPoint en WindowEscape.");
            }
        }
    }
}
