using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;   // ← IMPORTANTE para cambiar escenas
using System.Collections;

public class SleepCinematic : MonoBehaviour
{
    public static SleepCinematic Instance;

    [Header("UI")]
    public Image blackScreen;      
    public Image jumpscareImage;   

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip jumpscareSound;

    [Header("Cinemática")]
    public float fadeSpeed = 1f;
    public string nextSceneName = "IntroCinematicScene";   // ← Nombre de la escena destino

    private void Awake()
    {
        Instance = this;
        Debug.Log("SleepCinematic inicializado correctamente");

        blackScreen.color = new Color(0, 0, 0, 0);
        jumpscareImage.gameObject.SetActive(false);
    }

    public void StartSleepSequence()
    {
        StartCoroutine(FadeAndJumpscare());
    }

    IEnumerator FadeAndJumpscare()
    {
        // ---------- FADE-IN NEGRO ----------
        float alpha = 0;

        while (alpha < 1f)
        {
            alpha += Time.deltaTime * fadeSpeed;
            blackScreen.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        // Pausa ligera
        yield return new WaitForSeconds(0.3f);

        // ---------- JUMPSCARE ----------
        jumpscareImage.gameObject.SetActive(true);

        if (audioSource != null && jumpscareSound != null)
            audioSource.PlayOneShot(jumpscareSound);

        // Tiempo del jumpscare
        yield return new WaitForSeconds(1.5f);

        // ---------- 🔥 CARGAR LA SIGUIENTE ESCENA ----------
        SceneManager.LoadScene(nextSceneName);
    }
}
