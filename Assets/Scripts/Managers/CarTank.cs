using UnityEngine;

public class CarTank : MonoBehaviour
{
    public string finalSceneName = "EndGameScene"; // escena que carga cuando escapas
    public float fillDelay = 2f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        if (QuestManager3.Instance.currentStage != QuestManager3.QuestStage.TankCar) return;

        // Simula llenado y luego escapa
        StartCoroutine(FillAndEscape());
    }

    private System.Collections.IEnumerator FillAndEscape()
    {
        // reproducir animacion de llenar
        yield return new WaitForSeconds(fillDelay);
        QuestManager3.Instance.OnCarTanked();

        // Cargar escena final (o hacer fade out)
        UnityEngine.SceneManagement.SceneManager.LoadScene(finalSceneName);
    }
}
