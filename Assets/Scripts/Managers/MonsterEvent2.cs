using UnityEngine;

public class MonsterEvent2 : MonoBehaviour
{
    public static MonsterEvent2 Instance;

    [Header("Infectados")]
    public GameObject infectadoPrefab;
    public Transform[] spawnPoints;  // Lugares donde aparecerán los infectados
    public int cantidad = 3;

    [Header("Jugador")]
    public Transform player;

    private bool eventTriggered = false;  // Evita que aparezcan dos veces

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    // ------------------------------------------------------------
    //   MÉTODO LLAMADO DESDE WindowEscape
    // ------------------------------------------------------------
    public void SpawnMonsterEvent()
    {
        if (eventTriggered) return;  
        eventTriggered = true;

        // Mensaje de misión
        QuestManager3.Instance.SetMissionText("¡Corre al coche antes de que los infectados te alcancen!");

        // ------------------------------------------------------------
        //    SPAWNEAR VARIOS INFECTADOS
        // ------------------------------------------------------------
        for (int i = 0; i < cantidad; i++)
        {
            int index = i;

            // Si hay más infectados que spawnpoints → usar random
            if (index >= spawnPoints.Length)
                index = Random.Range(0, spawnPoints.Length);

            // Instanciar infectado
            GameObject infectado = Instantiate(
                infectadoPrefab,
                spawnPoints[index].position,
                Quaternion.identity
            );

            // Activar IA
            MonsterAI ai = infectado.GetComponent<MonsterAI>();
            if (ai != null)
                ai.Initialize(player);
        }
    }
}
