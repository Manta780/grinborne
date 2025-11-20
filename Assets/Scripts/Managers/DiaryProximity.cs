using UnityEngine;

public class DiaryProximity : MonoBehaviour
{
    public DiaryInteraction diaryInteraction;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            diaryInteraction.SetNearDiary(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            diaryInteraction.SetNearDiary(false);
        }
    }
}
