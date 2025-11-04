using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TreeChop : MonoBehaviour
{
    public GameObject stumpPrefab;
    public float interactionRadius = 1.5f;
    public int hitsToChop = 5;
    public KeyCode chopKey = KeyCode.E;
    public GameObject interactionUI;

    private int currentHits = 0;
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

            if (playerInRange && Input.GetKeyDown(chopKey))
            {
                StartCoroutine(ChopAnimation());
                currentHits++;

                if (currentHits >= hitsToChop)
                {
                    ChopDownTree();
                }
            }
        }
    }

    private IEnumerator ChopAnimation()
    {
        float duration = 0.2f;
        float magnitude = 0.05f;
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

    private void ChopDownTree()
    {
        Instantiate(stumpPrefab, transform.position, transform.rotation);
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
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}
