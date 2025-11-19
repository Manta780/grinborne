using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SleepCinematic : MonoBehaviour
{
    public static SleepCinematic Instance;

    public Image blackScreen;      // pantalla negra
    public Image jumpscareImage;   // imagen del jumpscare

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
        // FADE-IN (cerrar ojos)
        float alpha = 0;

        while (alpha < 1f)
        {
            alpha += Time.deltaTime * fadeSpeed;
            blackScreen.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        // Esperar un momento en negro total
        yield return new WaitForSeconds(0.3f);

        // Mostrar jumpscare
        jumpscareImage.gameObject.SetActive(true);

        // Jumpscare dura un poco
        yield return new WaitForSeconds(1.5f);

        // Aquí puedes cargar la siguiente escena
        // SceneManager.LoadScene("Escena_Del_Nuevo_Protagonista");
    }
}
