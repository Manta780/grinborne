using UnityEngine;

public class TriggerPueblo : MonoBehaviour
{
    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggered) return;

        if (collision.CompareTag("Player"))
        {
            triggered = true;
            QuestManager3.Instance.ReachTown(); // ← Avanza misión
        }
    }
}
