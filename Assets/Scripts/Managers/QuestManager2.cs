using UnityEngine;
using TMPro;

public class QuestManager2 : MonoBehaviour
{
    public static QuestManager2 Instance;

    [Header("UI")]
    public TextMeshProUGUI missionText;

    [Header("Estados de misión")]
    public bool reachedCabin = false;
    public bool enteredCabin = false;
    public bool diaryRead = false;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        missionText.text = "Explora el bosque y encuentra la cabaña";
    }

    // --------------------------------------------------------------
    // Misión 1: Encontrar cabaña
    // --------------------------------------------------------------
    public void ReachCabin()
    {
        if (reachedCabin) return;

        reachedCabin = true;
        missionText.text = "Entra en la cabaña";
    }

    // --------------------------------------------------------------
    // Misión 2: Entrar a la cabaña
    // --------------------------------------------------------------
    public void EnterCabin()
    {
        if (enteredCabin) return;

        enteredCabin = true;
        missionText.text = "Busca el diario del cazador";
    }

    // --------------------------------------------------------------
    // Misión 3: Leer el diario
    // --------------------------------------------------------------
    public void ReadDiary()
    {
        if (diaryRead) return;

        diaryRead = true;
        missionText.text = "Diario leído";
    }
}
