using UnityEngine;

public class AmbientInitializer : MonoBehaviour
{
    public AudioSource ambientSource;
    public AudioClip ambientClip;

    [Header("¿El jugador comienza fuera de la casa?")]
    public bool jugadorEmpiezaAfuera = true;

    void Start()
    {
        if (ambientSource == null) return;

        if (jugadorEmpiezaAfuera)
        {
            // Encender sonido ambiente de bosque
            ambientSource.clip = ambientClip;
            ambientSource.loop = true;
            ambientSource.Play();
        }
        else
        {
            // Apagar sonido
            ambientSource.Stop();
        }
    }
}