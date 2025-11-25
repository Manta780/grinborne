using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SurvivorDialogue : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI dialogueTextUI;
    public TextMeshProUGUI speakerNameText;        // <-- Namebox
    public GameObject dialoguePanel;
    public Button nextButton;

    [Header("Diálogo")]
    public string[] lines;                         // Líneas normales
    public string[] speakerNames;                  // <-- SOLO nombres, mismo tamaño que lines[]

    private int index = 0;
    private bool isOpen = false;

    private void Awake()
    {
        if (dialoguePanel != null) dialoguePanel.SetActive(false);
        if (nextButton != null) nextButton.onClick.AddListener(NextLine);
    }

    public void StartDialogue()
    {
        index = 0;
        dialoguePanel.SetActive(true);
        isOpen = true;
        ShowLine();
    }

    private void Update()
    {
        if (!isOpen) return;

        if (Input.GetKeyDown(KeyCode.E))
            NextLine();
    }

    private void ShowLine()
    {
        if (index < lines.Length)
        {
            dialogueTextUI.text = lines[index];

            // Actualizar Namebox
            if (speakerNames != null && speakerNames.Length > index)
                speakerNameText.text = speakerNames[index];
            else
                speakerNameText.text = ""; // por si acaso
        }
        else
        {
            EndDialogue();
        }
    }

    private void NextLine()
    {
        index++;
        ShowLine();
    }

    private void EndDialogue()
    {
        isOpen = false;
        dialoguePanel.SetActive(false);

        // Pasar a etapa de decisiones
        QuestManager3.Instance.StartDecisionStage();
    }
}
