using UnityEngine;

public class SpawnerInfectados : MonoBehaviour
{
    public GameObject infectadoPrefab;
    public Transform[] spawnPoints;
    public int cantidad = 3;
    public Transform targetJugador; // Jugador, arrástralo desde Unity

    void Start()
    {
        SpawnInfectados();
    }

    void SpawnInfectados()
    {
        for (int i = 0; i < cantidad; i++)
        {
            int index = i;

            if (index >= spawnPoints.Length)
                index = Random.Range(0, spawnPoints.Length);

            // Instanciar infectado
            GameObject nuevoInfectado = Instantiate(
                infectadoPrefab,
                spawnPoints[index].position,
                Quaternion.identity
            );

            // Obtener el MonsterAI y asignar objetivo
            MonsterAI ai = nuevoInfectado.GetComponent<MonsterAI>();
            if (ai != null)
            {
                ai.Initialize(targetJugador);  // <-- ESTA ES LA PARTE QUE FALTABA
            }
        }
    }
}
