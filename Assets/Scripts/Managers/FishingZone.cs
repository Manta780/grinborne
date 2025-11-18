using UnityEngine;
using System.Collections;

public class FishingZone : MonoBehaviour
{
    [Header("Configuración de interacción")]
    public KeyCode fishKey = KeyCode.E;
    public GameObject interactionUI;

    [Header("Pesca")]
    public float fishingDuration = 6.783f; 
    private bool canFish = true;
    private bool playerInZone = false;
    private Transform player;
    private Animator playerAnimator;
    private Personaje playerMovement;  // <--- Tu script real
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
            playerMovement.estaPescando = true;

        if (playerAnimator != null)
            playerAnimator.SetTrigger("Pescar");

        yield return new WaitForSeconds(fishingDuration);

        if (playerMovement != null)
            playerMovement.estaPescando = false;

        canFish = true;

        QuestManager.Instance.AddFish();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.transform;
            playerAnimator = player.GetComponent<Animator>();
            playerRb = player.GetComponent<Rigidbody2D>();

            // Aquí obtienes tu script Personaje
            playerMovement = player.GetComponent<Personaje>();

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
}
