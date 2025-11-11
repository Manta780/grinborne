using UnityEngine;
using System.Collections;

public class FishingZone : MonoBehaviour
{
    [Header("Configuración de interacción")]
    public KeyCode fishKey = KeyCode.E;
    public GameObject interactionUI; // Asigna aquí el texto o ícono "Presiona E para pescar"

    [Header("Pesca")]
    public float fishingCooldown = 1.082f; // Duración de la animación o tiempo entre pescas
    private bool canFish = true;
    private bool playerInZone = false;
    private Transform player;

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
        // 👉 Aquí puedes activar la animación del personaje
        // Ejemplo: player.GetComponent<Animator>().SetTrigger("Pescar");

        // Espera el tiempo que dura la animación o cooldown
        yield return new WaitForSeconds(fishingCooldown);

        // Aquí podrías añadir lógica de éxito o ítem obtenido
        Debug.Log("✅ Pesca completada (podrías obtener un pez)");

        canFish = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.transform;
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
