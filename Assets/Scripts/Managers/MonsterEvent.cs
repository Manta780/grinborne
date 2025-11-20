using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterEvent : MonoBehaviour
{
    public static MonsterEvent Instance;

    [Header("Monstruo")]
    public GameObject monsterPrefab;
    public Transform spawnPoint;

    private GameObject monsterInstance;

    [Header("Jugador")]
    public Transform player;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void SpawnMonsterEvent()
    {
        if (monsterInstance != null) return;

        // Spawnear monstruo
        monsterInstance = Instantiate(monsterPrefab, spawnPoint.position, Quaternion.identity);

        // Activar persecución
        monsterInstance.GetComponent<MonsterAI>().Initialize(player);

        // Actualizar misión
        QuestManager2.Instance.missionText.text = "¡Huye al carro antes de que te alcance!";
    }

    public void PlayerCaught()
    {
        Debug.Log("Jugador atrapado → Jumpscare + Reinicio");

        // Aquí puedes poner animación, sonido, pantalla roja, etc.

        // Reiniciar escena después de 1 segundo
        Invoke(nameof(ReloadScene), 1f);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
