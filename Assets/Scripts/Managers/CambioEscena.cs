using UnityEngine;

public class CambioEscena : MonoBehaviour
{
    [Header("Punto de destino (arrastra el InteriorSpawnPoint)")]
    public Transform puntoDestino;

    [Header("Tag del jugador")]
    public string tagJugador = "Player";

    [Header("Sonido de puerta (arrastra el clip y el AudioSource)")]
    public AudioSource audioSource;     // Fuente de sonido (el AudioSource del objeto puerta)
    public AudioClip sonidoPuertaAbierta;  // Clip de sonido de abrir puerta

    private bool enProceso = false;  // Evita múltiples activaciones

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!enProceso && other.CompareTag(tagJugador))
        {
            enProceso = true;

            // Reproducir sonido
            if (audioSource != null && sonidoPuertaAbierta != null)
                audioSource.PlayOneShot(sonidoPuertaAbierta);

            // Teletransportar al jugador
            other.transform.position = puntoDestino.position;
            Debug.Log("Jugador teletransportado a: " + puntoDestino.position);

            // Evitar que se active varias veces seguidas
            Invoke(nameof(ResetTP), 0.5f);
        }
    }

    private void ResetTP()
    {
        enProceso = false;
    }
}
