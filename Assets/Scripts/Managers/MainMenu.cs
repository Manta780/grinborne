using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("Start2D"); // Cambia por tu escena inicial
    }

    public void LoadGame()
    {
        Debug.Log("Cargar partida (a implementar)");
        // Aquí luego puedes cargar datos de guardado
    }

    public void OpenSettings()
    {
        Debug.Log("Abrir ajustes");
        // Aquí puedes abrir un panel de Settings
    }

    public void ExitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
