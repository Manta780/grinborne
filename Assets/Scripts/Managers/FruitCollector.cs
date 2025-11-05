using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FruitCollector : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject treeWithoutFruitsPrefab; // Prefab del árbol sin frutas

    [Header("Configuración")]
    public float interactionRadius = 1.5f; // Radio de interacción
    public int pressesToCollect = 5; // Veces que hay que presionar E
    public KeyCode collectKey = KeyCode.E; // Tecla para recolectar
    public GameObject interactionUI; // UI opcional de "Presiona E para recolectar"

    private int currentPresses = 0;
    private bool playerInRange = false;
    private Transform player;
    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;

        if (interactionUI != null)
            interactionUI.SetActive(false);
    }

    private void Update()
    {
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.position);
            playerInRange = distance <= interactionRadius;

            if (interactionUI != null)
                interactionUI.SetActive(playerInRange);

            if (playerInRange && Input.GetKeyDown(collectKey))
            {
                StartCoroutine(ShakeAnimation());
                currentPresses++;

                if (currentPresses >= pressesToCollect)
                {
                    ReplaceWithTreeWithoutFruits();
                }
            }
        }
    }

    private IEnumerator ShakeAnimation()
    {
        // Vibración leve simulando movimiento de ramas
        float duration = 0.2f;
        float magnitude = 0.04f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.position = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = originalPosition;
    }

    private void ReplaceWithTreeWithoutFruits()
    {
        Instantiate(treeWithoutFruitsPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = null;
            playerInRange = false;

            if (interactionUI != null)
                interactionUI.SetActive(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}
