using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DiaryUI : MonoBehaviour
{
    public static DiaryUI Instance;

    [Header("UI")]
    public GameObject diaryCanvas;
    public TextMeshProUGUI pageLeft;
    public TextMeshProUGUI pageRight;
    public Button nextButton;
    public Button prevButton;

    private int currentPageIndex = 0;

    // 🔥 Aquí irá la lista de páginas
    private string[] pages;

    private void Awake()
    {
        Instance = this;
        diaryCanvas.SetActive(false);

        // Inicializamos páginas del diario
        pages = DiaryPages.GetPages();
    }

    private void Start()
    {
        nextButton.onClick.AddListener(NextPage);
        prevButton.onClick.AddListener(PrevPage);
    }

    public void OpenDiary()
    {
        currentPageIndex = 0;
        diaryCanvas.SetActive(true);
        UpdatePages();
    }

    public void CloseDiary()
    {
        diaryCanvas.SetActive(false);
    }

    private void UpdatePages()
    {
        pageLeft.text = pages[currentPageIndex];

        int rightIndex = currentPageIndex + 1;

        if (rightIndex < pages.Length)
            pageRight.text = pages[rightIndex];
        else
            pageRight.text = "";

        prevButton.gameObject.SetActive(currentPageIndex > 0);
        nextButton.gameObject.SetActive(rightIndex < pages.Length);
    }

    public void NextPage()
    {
        if (currentPageIndex + 2 < pages.Length)
        {
            currentPageIndex += 2;
            UpdatePages();
        }
    }

    public void PrevPage()
    {
        if (currentPageIndex > 0)
        {
            currentPageIndex -= 2;
            UpdatePages();
        }
    }
}
