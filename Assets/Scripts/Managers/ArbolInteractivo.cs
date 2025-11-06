using UnityEngine;

public class ArbolInteractivo : MonoBehaviour
{
    private bool jugadorCerca = false;

    public bool JugadorCerca => jugadorCerca;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
        }
    }
}
