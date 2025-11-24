using UnityEngine;
using TMPro;

public class QuestManager3 : MonoBehaviour
{
    public static QuestManager3 Instance;

    public enum QuestStage
    {
        None,
        ExploreField,          // Explora el terreno y ve el pueblo
        ReadNote,              // Leer la nota junto al cadáver
        EnterFisherHouse,      // Entrar cabaña del pescador
        TalkSurvivor,          // Dialogar con el superviviente
        DecisionMade,          // Decisión tomada (sacrificio o escape)
        TakeGasCan,            // Agarrar galón de gasolina
        EscapeThroughWindow,   // Escapar por ventana
        TankCar,               // Llenar el carro
        FinalEscape,           // Escapar definitivamente
        PlayerDead             // Muerto (pantalla de muerte)
    }

    [Header("UI")]
    public TextMeshProUGUI missionText;

    [Header("Estado")]
    public QuestStage currentStage = QuestStage.None;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        StartExploreStage();
    }

    // ---------- Helpers para cambiar misión ----------
    public void SetMissionText(string text)
    {
        if (missionText != null)
            missionText.text = text;
    }

    public void StartExploreStage()
    {
        currentStage = QuestStage.ExploreField;
        SetMissionText("Explora el terreno baldío y localiza el pueblo");
    }

    public void ReachTown()
    {
        if (currentStage != QuestStage.ExploreField) return;

        StartReadNoteStage();
    }

    public void StartReadNoteStage()
    {
        if (currentStage != QuestStage.ExploreField) return;
        currentStage = QuestStage.ReadNote;
        SetMissionText("Investiga qué ocurrió en el pueblo (lee la nota)");
    }

    public void StartEnterFisherStage()
    {
        if (currentStage != QuestStage.ReadNote) return;
        currentStage = QuestStage.EnterFisherHouse;
        SetMissionText("Entra a la cabaña del pescador");
    }

    public void StartTalkSurvivorStage()
    {
        if (currentStage != QuestStage.EnterFisherHouse) return;
        currentStage = QuestStage.TalkSurvivor;
        SetMissionText("Habla con el superviviente");
    }

    public void StartDecisionStage()
    {
        if (currentStage != QuestStage.TalkSurvivor) return;
        currentStage = QuestStage.DecisionMade;
        SetMissionText("Decide: Sacrificarte o escapar (elige)");
    }

    // Si el jugador decide sacrificarse:
    public void PlayerSacrifice()
    {
        currentStage = QuestStage.PlayerDead;
        SetMissionText("Has muerto");
        // Aquí puedes abrir pantalla de muerte
    }

    // Si el jugador decide escapar:
    public void PlayerChoosesEscape()
    {
        currentStage = QuestStage.TakeGasCan;
        SetMissionText("Toma el galón de gasolina");
    }

    public void OnGasTaken()
    {
        if (currentStage != QuestStage.TakeGasCan) return;
        currentStage = QuestStage.EscapeThroughWindow;
        SetMissionText("Escapa por la ventana hacia el coche");
    }

    public void OnWindowEscaped()
    {
        if (currentStage != QuestStage.EscapeThroughWindow) return;
        currentStage = QuestStage.TankCar;
        SetMissionText("Ve al coche y llena el tanque");
    }

    public void OnCarTanked()
    {
        if (currentStage != QuestStage.TankCar) return;
        currentStage = QuestStage.FinalEscape;
        SetMissionText("¡Arranca y escapa del pueblo!");
    }

    // Método sencillo para forzar la pantalla de "Has muerto" o reinicio
    public void ShowPlayerDeath()
    {
        currentStage = QuestStage.PlayerDead;
        SetMissionText("Has muerto");
    }
}
