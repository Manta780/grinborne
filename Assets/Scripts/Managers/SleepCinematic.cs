using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SleepCinematic : MonoBehaviour
{
    public static SleepCinematic Instance;

    [Header("UI")]
    public Image blackScreen;      
    public Image jumpscareImage;   

    [Header("Audio")]
    public AudioSource audioSource;        // arrastras un AudioSource aquí
    public AudioClip jumpscareSound;       // arrastras sonido de jumpscare

    public float fadeSpeed = 1f;

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
        // FADE-IN
        float alpha = 0;

        while (alpha < 1f)
        {
            alpha += Time.deltaTime * fadeSpeed;
            blackScreen.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        // pequeña pausa
        yield return new WaitForSeconds(0.3f);

        // ----------🔥 AQUÍ APARECE EL JUMPSCARE ----------
        jumpscareImage.gameObject.SetActive(true);

        if (audioSource != null && jumpscareSound != null)
            audioSource.PlayOneShot(jumpscareSound); // 🔥 Sonido del jumpscare

        // esperar
        yield return new WaitForSeconds(1.5f);
    }
}
