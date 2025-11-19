using UnityEngine;

public class BedSleep : MonoBehaviour
{
    private bool inside = false;

    private void Update()
    {
        if (inside &&
            Input.GetKeyDown(KeyCode.E) &&
            QuestManager.Instance.sleepMissionActive)
        {
            QuestManager.Instance.CompleteSleepMission();

            // 🔥 Activar canvas de cinemática
            SleepCinematic.Instance.gameObject.SetActive(true);

            SleepCinematic.Instance.StartSleepSequence();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            inside = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            inside = false;
    }
}
