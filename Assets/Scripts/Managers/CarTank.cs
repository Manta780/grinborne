using UnityEngine;
using UnityEngine.UI; // Necesario si usas UI.Text
using TMPro;          // Necesario si usas TextMeshPro

public class CarTank : MonoBehaviour
{
    [Header("Final Scene")]
    public string finalSceneName = "EndGameScene";
    public float fillDelay = 2f;

    [Header("UI")]
    public GameObject UIMessage; 
    // Arrastra aquí un texto tipo:
    // "Presiona E para tanquear el carro"

    private bool playerInside = false;
    private bool alreadyTanking = false;

    private void Start()
    {
        if (UIMessage != null)
            UIMessage.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        if (QuestManager3.Instance.currentStage != QuestManager3.QuestStage.TankCar) return;

        playerInside = true;

        // Mostrar UI
        if (UIMessage != null)
            UIMessage.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        playerInside = false;

        // Ocultar UI
        if (UIMessage != null)
            UIMessage.SetActive(false);
    }

    private void Update()
    {
        if (!playerInside) return;
        if (alreadyTanking) return;

        // Detectar la tecla E
        if (Input.GetKeyDown(KeyCode.E))
        {
            alreadyTanking = true;

            if (UIMessage != null)
                UIMessage.SetActive(false);

            StartCoroutine(FillAndEscape());
        }
    }

    private System.Collections.IEnumerator FillAndEscape()
    {
        // Aquí podrías poner animación de tanquear
        yield return new WaitForSeconds(fillDelay);

        QuestManager3.Instance.OnCarTanked();

        UnityEngine.SceneManagement.SceneManager.LoadScene(finalSceneName);
    }
}
