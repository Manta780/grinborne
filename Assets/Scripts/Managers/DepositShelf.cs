using UnityEngine;

public class DepositShelf : MonoBehaviour
{
    [Header("Interacción")]
    public KeyCode depositKey = KeyCode.E;
    public GameObject interactionUI; // UI visible cuando se puede depositar

    [Header("Cambio de Prefab")]
    public GameObject fullShelfPrefab;

    private bool playerInside = false;
    private bool deposited = false;

    private void Start()
    {
        if (interactionUI != null)
            interactionUI.SetActive(false);
    }

    private void Update()
    {
        if (!playerInside || deposited)
            return;

        // Solo dejar la UI activa si las misiones están completas
        if (interactionUI != null)
            interactionUI.SetActive(QuestManager.Instance.AllMissionsComplete());

        // Solo permite acción si todas las misiones están completas
        if (QuestManager.Instance.AllMissionsComplete() &&
            Input.GetKeyDown(depositKey))
        {
            DepositAction();
        }
    }

    private void DepositAction()
    {
        deposited = true;

        QuestManager.Instance.DepositResources();

        // Ocultar UI
        if (interactionUI != null)
            interactionUI.SetActive(false);

        // Cambiar prefab
        if (fullShelfPrefab != null)
        {
            Instantiate(fullShelfPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !deposited)
        {
            playerInside = true;

            // Mostrar la UI solo si las misiones están completas
            if (interactionUI != null)
                interactionUI.SetActive(QuestManager.Instance.AllMissionsComplete());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;

            if (interactionUI != null)
                interactionUI.SetActive(false);
        }
    }
}
