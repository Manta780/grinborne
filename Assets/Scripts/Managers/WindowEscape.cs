using UnityEngine;

public class WindowEscape : MonoBehaviour
{
    [Header("Teletransporte")]
    public Transform exitSpawnPoint;   // Spawn exterior

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (QuestManager3.Instance.currentStage == QuestManager3.QuestStage.EscapeThroughWindow)
        {
            // Avanza misión
            QuestManager3.Instance.OnWindowEscaped();

            // Teleport
            if (exitSpawnPoint != null)
                other.transform.position = exitSpawnPoint.position;

            // 🔥 ACTIVAR MONSTRUOS
            MonsterEvent2.Instance.SpawnMonsterEvent();
        }
    }
}
