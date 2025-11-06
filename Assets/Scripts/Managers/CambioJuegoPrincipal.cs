using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioJuegoPrincipal : MonoBehaviour
{
    public float tiempoDeEspera = 2f; // ⏱ Tiempo en segundos antes de cambiar
    public string nombreEscenaDestino = "Start2D"; // 🎯 Escena a la que cambiará

    void Start()
    {
        // Llama a la función CambiarEscena después de "tiempoDeEspera" segundos
        Invoke("CambiarEscena", tiempoDeEspera);
    }

    void CambiarEscena()
    {
        SceneManager.LoadScene(nombreEscenaDestino);
    }
}
