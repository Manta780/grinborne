using UnityEngine;

public class CambioEscena : MonoBehaviour
{
    [Header("Punto de destino (arrastra el InteriorSpawnPoint)")]
    public Transform puntoDestino;

    [Header("Tag del jugador")]
    public string tagJugador = "Player";

    [Header("Sonidos de puerta")]
    public AudioSource audioSource;           // SfxAudio
    public AudioClip sonidoPuertaAbierta;     // abrir puerta
    public AudioClip sonidoPuertaCerrada;     // cerrar puerta

    [Header("Sonido de ambiente")]
    public AudioSource ambientSource;         // AmbientAudio
    public AudioClip ambientClip;             // sonido del bosque

    [Header("Configuración de esta puerta")]
    public bool entrandoCasa; // true = entrando, false = saliendo

    private bool enProceso = false;  // evita múltiples activaciones

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!enProceso && other.CompareTag(tagJugador))
        {
            enProceso = true;

            // --- SONIDOS ---
            if (entrandoCasa)
            {
                // Abrir puerta
                if (audioSource && sonidoPuertaAbierta)
                    audioSource.PlayOneShot(sonidoPuertaAbierta);

                // Apagar sonido del bosque al entrar
                if (ambientSource)
                    ambientSource.Stop();
            }
            else
            {
                // Cerrar puerta
                if (audioSource && sonidoPuertaCerrada)
                    audioSource.PlayOneShot(sonidoPuertaCerrada);

                // Encender sonido del bosque al salir
                if (ambientSource && ambientClip)
                {
                    ambientSource.clip = ambientClip;
                    ambientSource.loop = true;
                    ambientSource.Play();
                }
            }

            // --- TELETRANSPORTAR ---
            other.transform.position = puntoDestino.position;

            // Reset
            Invoke(nameof(ResetTP), 0.4f);
        }
    }

    private void ResetTP()
    {
        enProceso = false;
    }
}
