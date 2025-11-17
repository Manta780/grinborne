using UnityEngine;

public class TrapZone : MonoBehaviour
{
    [Header("Zona de Trampa")]
    public Color highlightColor = new Color(1f, 1f, 0f, 0.3f); 
    private SpriteRenderer highlight;

    [Header("UI")]
    public GameObject interactionUI;

    [Header("Prefab de la trampa")]
    public GameObject trapPrefab;
    public Transform trapSpawnPoint;

    private bool playerInside = false;
    private bool trapPlaced = false;

    private void Start()
    {
        highlight = GetComponentInChildren<SpriteRenderer>();
        if (highlight != null)
            highlight.color = new Color(highlightColor.r, highlightColor.g, highlightColor.b, 0f);

        if (interactionUI != null)
            interactionUI.SetActive(false);
    }

    private void Update()
    {
        if (!playerInside || trapPlaced) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            PlaceTrap();
        }
    }

    private void PlaceTrap()
    {
        trapPlaced = true;

        // Instanciar trampa
        Instantiate(trapPrefab, trapSpawnPoint.position, Quaternion.identity);
        QuestManager.Instance.AddTrap();


        // Ocultar highlight
        if (highlight != null)
            highlight.gameObject.SetActive(false);

        // Quitar UI
        if (interactionUI != null)
            interactionUI.SetActive(false);

        // Desactivar collider para que no vuelva a interactuar
        GetComponent<Collider2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!trapPlaced && other.CompareTag("Player"))
        {
            playerInside = true;

            if (highlight != null)
                highlight.color = highlightColor;

            if (interactionUI != null)
                interactionUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;

            if (!trapPlaced && highlight != null)
                highlight.color = new Color(highlightColor.r, highlightColor.g, highlightColor.b, 0f);

            if (interactionUI != null)
                interactionUI.SetActive(false);
        }
    }
}
