using UnityEngine;

public class SonidoPasos : MonoBehaviour
{
    public AudioSource audioSource; // arrastra aquí el AudioSource del jugador
    public AudioClip pasoClip;      // arrastra aquí el sonido de paso

    // Esta función la llamará el evento de animación
    public void ReproducirPaso()
    {
        if (pasoClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(pasoClip);
        }
    }

}
