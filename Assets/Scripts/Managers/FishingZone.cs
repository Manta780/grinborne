using UnityEngine;
using System.Collections;

public class FishingZone : MonoBehaviour
{
    [Header("Configuración de interacción")]
    public KeyCode fishKey = KeyCode.E;
    public GameObject interactionUI; // Texto o ícono "Presiona E para pescar"

    [Header("Pesca")]
    public float fishingDuration = 6.783f; // Duración exacta de la animación de pesca
    private bool canFish = true;
    private bool playerInZone = false;
    private Transform player;
    private Animator playerAnimator;
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

        Debug.Log("🎣 Iniciando animación de pesca...");

        // ✅ Bloquear movimiento temporalmente (si el jugador tiene Rigidbody2D)
        if (playerRb != null)
            playerRb.linearVelocity = Vector2.zero;

        var playerMovement = player.GetComponent<MonoBehaviour>();
        if (playerMovement != null)
            playerMovement.enabled = false; // Desactiva el script de movimiento si lo tienes

        // ✅ Activar animación "Pescar" (asegúrate de tener el trigger 'Pescar' en el Animator)
        if (playerAnimator != null)
            playerAnimator.SetTrigger("Pescar");

        // ⏱ Espera la duración de la animación antes de liberar el movimiento
        yield return new WaitForSeconds(fishingDuration);

        Debug.Log("✅ Pesca completada (podrías obtener un pez aquí)");

        // ✅ Reactivar movimiento
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
            playerInZone = true;

            if (interactionUI != null)
                interactionUI.SetActive(true);

            Debug.Log("Entraste a zona de pesca");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = null;
            playerAnimator = null;
            playerRb = null;
            playerInZone = false;

            if (interactionUI != null)
                interactionUI.SetActive(false);

            Debug.Log("Saliste de la zona de pesca");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0f, 0.6f, 1f, 0.4f);
        Gizmos.DrawWireCube(transform.position, GetComponent<Collider2D>().bounds.size);
    }
}
