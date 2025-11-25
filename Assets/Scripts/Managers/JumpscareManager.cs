using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpscareManager : MonoBehaviour
{
    public static JumpscareManager Instance;
    public GameObject jumpscarePanel;
    public AudioSource jumpscareAudio;
    public float afterDelay = 2f;
    public string deathSceneName = "Creditos"; // donde reintentar

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        if (jumpscarePanel != null) jumpscarePanel.SetActive(false);
    }

    public void PlayFinalSacrifice()
    {
        if (jumpscarePanel != null) jumpscarePanel.SetActive(true);
        if (jumpscareAudio != null) jumpscareAudio.Play();

        Invoke(nameof(ShowDeathScreen), afterDelay);
    }

    private void ShowDeathScreen()
    {
        // Cargar pantalla de muerte o scene
        SceneManager.LoadScene(deathSceneName);
    }
}
