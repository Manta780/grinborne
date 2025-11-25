using UnityEngine;

public class GasCan : MonoBehaviour
{
    public static GasCan Instance;
    public GameObject gasCanObject; // prefab o gameobject del galon en la escena
    private bool canBePicked = false;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        if (gasCanObject != null) gasCanObject.SetActive(false);
    }

    public void EnablePickUp()
    {
        canBePicked = true;
        if (gasCanObject != null) gasCanObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!canBePicked) return;
        if (!other.CompareTag("Player")) return;

        // El jugador toma la gasolina
        gameObject.SetActive(false);
        canBePicked = false;
        QuestManager3.Instance.OnGasTaken();
    }
}
