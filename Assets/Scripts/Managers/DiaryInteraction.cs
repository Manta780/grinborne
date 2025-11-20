using UnityEngine;

public class DiaryInteraction : MonoBehaviour
{
    private bool canReadDiary = false;

    public void EnableDiary(bool state)
    {
        canReadDiary = state;
        Debug.Log("Lectura del diario: " + (state ? "Activada" : "Desactivada"));
    }

    private void Update()
    {
        if (canReadDiary && Input.GetKeyDown(KeyCode.E))
        {
            AbrirDiario();
        }
    }

    void AbrirDiario()
    {
        Debug.Log("Mostrando páginas del diario...");
        // Aquí pones tu UI, animación, etc.
    }
}
