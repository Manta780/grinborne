using UnityEngine;
using UnityEngine.UI;

public class DecisionPanel : MonoBehaviour
{
    public GameObject panel; // panel con dos botones
    public Button sacrificeButton;
    public Button escapeButton;

    private void Awake()
    {
        if (panel != null) panel.SetActive(false);
        if (sacrificeButton != null) sacrificeButton.onClick.AddListener(OnSacrifice);
        if (escapeButton != null) escapeButton.onClick.AddListener(OnEscape);
    }

    public void Show()
    {
        if (panel != null) panel.SetActive(true);
    }

    public void Hide()
    {
        if (panel != null) panel.SetActive(false);
    }

    private void OnSacrifice()
    {
        // activar jumpscare y mostrar pantalla de muerte
        QuestManager3.Instance.PlayerSacrifice();
        // asumiendo que tienes un JumpscareManager que muestra la imagen/sonido y luego carga escena
        JumpscareManager.Instance.PlayFinalSacrifice();
    }

    private void OnEscape()
    {
        Hide();
        QuestManager3.Instance.PlayerChoosesEscape();
        // activar galón en la escena (habilitar prefab interactable)
        GasCan.Instance.EnablePickUp();
    }
}
