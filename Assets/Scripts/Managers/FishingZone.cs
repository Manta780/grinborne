using UnityEngine;
using System.Collections;

public class FishingZone : MonoBehaviour
{
    [Header("Configuración de interacción")]
    public KeyCode fishKey = KeyCode.E;
    public GameObject interactionUI;

    [Header("Pesca")]
    public float fishingDuration = 6.783f; // duración exacta de la animación
    private bool canFish = true;
    private bool playerInZone = false;
    private Transform player;
    private Animator playerAnimator;
    private MonoBehaviour playerMovement;
    private Rigidbody2D playerRb;

    private void Start()
    {
        if (interactionUI != null)
            interactionUI.SetActive(false);
    }

    private void Update()
    {
        if (playerInZone && canFish && Input.GetKeyDown(fishKey))
        {
            StartCoroutine(FishAction());
        }
    }

    private IEnumerator FishAction()
    {
        canFish = false;

        if (playerRb != null)
            playerRb.linearVelocity = Vector2.zero;

        if (playerMovement != null)
            playerMovement.enabled = false;

        if (playerAnimator != null)
            playerAnimator.SetTrigger("Pescar");

        // Espera la duración exacta de la animación
        yield return new WaitForSeconds(fishingDuration);

        // Regresa automáticamente a idle y habilita movimiento
        if (playerMovement != null)
            playerMovement.enabled = true;

        canFish = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.transform;
            playerAnimator = player.GetComponent<Animator>();
            playerRb = player.GetComponent<Rigidbody2D>();

            // busca automáticamente tu script de movimiento
            playerMovement = player.GetComponent<MonoBehaviour>();

            playerInZone = true;
            if (interactionUI != null)
                interactionUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = null;
            playerAnimator = null;
            playerRb = null;
            playerMovement = null;
            playerInZone = false;

            if (interactionUI != null)
                interactionUI.SetActive(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0f, 0.6f, 1f, 0.4f);
        Gizmos.DrawWireCube(transform.position, GetComponent<Collider2D>().bounds.size);
    }
}
