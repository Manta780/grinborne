using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    [Header("Objetivos de la misión")]
    public int goalFruit = 20;
    public int goalWood = 5;
    public int goalFish = 5;
    public int goalTraps = 3;

    [Header("Progreso actual")]
    public int currentFruit = 0;
    public int currentWood = 0;
    public int currentFish = 0;
    public int currentTraps = 0;

    [Header("UI (TextMeshPro)")]
    public TextMeshProUGUI fruitText;
    public TextMeshProUGUI woodText;
    public TextMeshProUGUI fishText;
    public TextMeshProUGUI trapText;
    public TextMeshProUGUI depositText;

    [Header("Control de misiones")]
    public bool fruitDone = false;
    public bool woodDone = false;
    public bool fishDone = false;
    public bool trapDone = false;

    [Header("Estantería final")]
    public GameObject shelfEmpty;
    public GameObject shelfFull;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        UpdateUI();
        shelfFull.SetActive(false);
        depositText.gameObject.SetActive(false);
    }

    // ------------------------------
    // SUMAR PROGRESO
    // ------------------------------

    public void AddFruit()
    {
        if (fruitDone) return;

        currentFruit++;
        if (currentFruit >= goalFruit)
            fruitDone = true;

        UpdateUI();
    }

    public void AddWood()
    {
        if (woodDone) return;

        currentWood++;
        if (currentWood >= goalWood)
            woodDone = true;

        UpdateUI();
    }

    public void AddFish()
    {
        if (fishDone) return;

        currentFish++;
        if (currentFish >= goalFish)
            fishDone = true;

        UpdateUI();
    }

    public void AddTrap()
    {
        if (trapDone) return;

        currentTraps++;
        if (currentTraps >= goalTraps)
            trapDone = true;

        UpdateUI();
    }

    // ------------------------------
    // UI
    // ------------------------------
    private void UpdateUI()
    {
        fruitText.text = $"Frutas: {currentFruit}/{goalFruit}";
        woodText.text = $"Madera: {currentWood}/{goalWood}";
        fishText.text = $"Pescas: {currentFish}/{goalFish}";
        trapText.text = $"Trampas: {currentTraps}/{goalTraps}";

        if (AllMissionsComplete())
            ActivateDepositMission();
    }

    public bool AllMissionsComplete()
    {
        return fruitDone && woodDone && fishDone && trapDone;
    }

    // ------------------------------
    // MISIÓN FINAL
    // ------------------------------
    private void ActivateDepositMission()
    {
        depositText.gameObject.SetActive(true);
        depositText.text = "Deposita los recursos en la estantería";
        shelfEmpty.SetActive(true);
    }

    public void DepositResources()
    {
        shelfEmpty.SetActive(false);
        shelfFull.SetActive(true);

        depositText.text = "¡Misión completada!";
    }
}
