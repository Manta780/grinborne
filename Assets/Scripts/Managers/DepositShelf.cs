using UnityEngine;

public class DepositShelf : MonoBehaviour
{
    public KeyCode depositKey = KeyCode.E;

    private bool playerInside = false;

    private void Update()
    {
        if (playerInside && Input.GetKeyDown(depositKey) && QuestManager.Instance.AllMissionsComplete())
        {
            QuestManager.Instance.DepositResources();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInside = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInside = false;
    }
}
