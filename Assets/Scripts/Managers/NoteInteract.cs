using UnityEngine;

public class NoteInteract : MonoBehaviour
{
    [Header("UI Note")]
    public NoteUI noteUI; // arrastra el objeto NoteUI de la escena (prefab / canvas)
    public string noteText; // también puedes llenar desde el inspector

    private bool playerInside = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        playerInside = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        playerInside = false;
    }

    private void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            if (noteUI != null)
            {
                noteUI.OpenNote(noteText);
                // marcar que se leyó la nota: pasa a la siguiente misión
                QuestManager3.Instance.StartEnterFisherStage();
            }
        }
    }
}
