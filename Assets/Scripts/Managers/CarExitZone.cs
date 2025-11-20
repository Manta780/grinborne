using UnityEngine;
using UnityEngine.SceneManagement;

public class CarExitZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && QuestManager2.Instance.diaryRead)
        {
            Debug.Log("Jugador escapó → Final del juego");
            SceneManager.LoadScene("FinalScene"); // o el nombre que tengas
        }
    }
}
