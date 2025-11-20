using UnityEngine;

public class DiaryInteraction : MonoBehaviour
{
    private bool canReadDiary = false;
    private bool diaryOpen = false;

    public void EnableDiary(bool state)
    {
        canReadDiary = state;
        Debug.Log("Lectura del diario: " + (state ? "Activada" : "Desactivada"));
    }

    private void Update()
    {
        // Abrir diario con E
        if (canReadDiary && !diaryOpen && Input.GetKeyDown(KeyCode.E))
        {
            AbrirDiario();
        }

        // Cerrar diario con ESC
        if (diaryOpen && Input.GetKeyDown(KeyCode.Escape))
        {
            CerrarDiario();
        }
    }

    void AbrirDiario()
    {
        if (DiaryUI.Instance != null)
        {
            DiaryUI.Instance.OpenDiary();
            diaryOpen = true;
            Debug.Log("📖 Diario abierto.");
        }
        else
        {
            Debug.LogError("❌ No hay instancia de DiaryUI en la escena.");
        }
    }

    void CerrarDiario()
    {
        if (DiaryUI.Instance != null)
        {
            DiaryUI.Instance.CloseDiary();
            diaryOpen = false;
            Debug.Log("📕 Diario cerrado.");
        }
    }
}
