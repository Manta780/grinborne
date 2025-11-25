using UnityEngine;

public class SurvivorTrigger : MonoBehaviour
{
    public SurvivorDialogue dialogue;  
    private bool playerInside = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        // Solo deja hablar si la misión lo permite
        if (QuestManager3.Instance.currentStage == QuestManager3.QuestStage.TalkSurvivor)
        {
            playerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        playerInside = false;
    }

    private void Update()
    {
        if (playerInside &&
            QuestManager3.Instance.currentStage == QuestManager3.QuestStage.TalkSurvivor)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogue.StartDialogue();
            }
        }
    }
}
