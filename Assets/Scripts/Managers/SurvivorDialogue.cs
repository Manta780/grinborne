using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SurvivorDialogue : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI dialogueTextUI;
    public TextMeshProUGUI speakerNameText;        
    public GameObject dialoguePanel;
    public Button nextButton;

    [Header("Diálogo")]
    public string[] lines;                         
    public string[] speakerNames;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip doorSound;   
    public int doorSoundIndex = 13; 

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

            if (speakerNames != null && speakerNames.Length > index)
                speakerNameText.text = speakerNames[index];
            else
                speakerNameText.text = "";

            // SONIDO AQUÍ
            if (index == doorSoundIndex && doorSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(doorSound);
            }
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

        QuestManager3.Instance.StartDecisionStage();
    }
}
