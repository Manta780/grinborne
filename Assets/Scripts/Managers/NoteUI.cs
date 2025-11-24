using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NoteUI : MonoBehaviour
{
    public GameObject noteCanvas;       // raíz del canvas del note
    public Image noteImage;             // imagen de la nota (assign image sprite)
    public TextMeshProUGUI noteTextUI;  // texto dentro de la nota
    public KeyCode closeKey = KeyCode.Escape;

    private bool isOpen = false;

    private void Awake()
    {
        if (noteCanvas != null) noteCanvas.SetActive(false);
    }

    private void Update()
    {
        if (!isOpen) return;

        if (Input.GetKeyDown(closeKey))
        {
            CloseNote();
        }
    }

    // call to open note and fill text
    public void OpenNote(string text)
    {
        if (noteCanvas != null)
            noteCanvas.SetActive(true);

        if (noteTextUI != null)
            noteTextUI.text = text;

        // Si quieres asignar la imagen del usuario subida:
        // nota: te dejo la ruta del archivo que subiste, úsala para crear Sprite en Unity
        // Ruta del archivo (local): /mnt/data/A_pixel_art_digital_illustration_in_horror_theme_f.png
        // IMPORTANTE: debes importar ese archivo en tu proyecto como Sprite y arrastrarlo al campo noteImage.
        isOpen = true;

        // bloquear movimiento del jugador si usas Time.timeScale:
        // Time.timeScale = 0f;  // si tu movimiento depende de timeScale. Si no, mejor desactivar script de movimiento.
    }

    public void CloseNote()
    {
        if (noteCanvas != null)
            noteCanvas.SetActive(false);

        isOpen = false;

        //Time.timeScale = 1f;

        // Al cerrar la nota se desbloquea la posibilidad de entrar a la cabaña
        // (en NoteInteract ya cambiamos misión; si quieres bloqueo extra, hazlo desde aquí o desde la puerta trigger)
    }
}
