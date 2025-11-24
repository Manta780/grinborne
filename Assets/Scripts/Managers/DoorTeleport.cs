using UnityEngine;

public class DoorTeleport : MonoBehaviour
{
    [Header("Referencia al punto donde aparecerá el jugador")]
    public Transform destinationPoint;

    [Header("Opcional: Necesitas que esto solo funcione en cierto estado de misión?")]
    public bool requiresMissionStage = false;
    public QuestManager3.QuestStage requiredStage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        // Si requiere misión específica
        if (requiresMissionStage)
        {
            if (QuestManager3.Instance.currentStage != requiredStage)
                return; // No teletransportar aún
        }

        // Teletransportar al jugador
        collision.transform.position = destinationPoint.position;
    }
}
