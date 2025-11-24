using UnityEngine;

public class HouseEnterTrigger : MonoBehaviour
{
    // Este trigger solo permitirá avanzar a la misión de hablar con el superviviente
    // si QuestManager3 está en la etapa EnterFisherHouse (o posterior).

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (QuestManager3.Instance.currentStage == QuestManager3.QuestStage.EnterFisherHouse ||
            QuestManager3.Instance.currentStage == QuestManager3.QuestStage.TalkSurvivor)
        {
            // Avanzar a la misión de dialogo con el superviviente
            QuestManager3.Instance.StartTalkSurvivorStage();
        }
    }
}
