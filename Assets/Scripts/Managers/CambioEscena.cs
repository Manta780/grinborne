using UnityEngine;

public class CambioEscena : MonoBehaviour
{
    [Header("Punto de destino (arrastra el InteriorSpawnPoint)")]
    public Transform puntoDestino;

    [Header("Tag del jugador")]
    public string tagJugador = "Player";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(tagJugador))
        {
            other.transform.position = puntoDestino.position;
            Debug.Log("Jugador teletransportado a: " + puntoDestino.position);
        }
    }
}
