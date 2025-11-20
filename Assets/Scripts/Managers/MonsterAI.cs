using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterAI : MonoBehaviour
{
    [Header("IA")]
    public float speed = 3f;
    private Transform player;

    [Header("Animator")]
    private Animator anim;

    [Header("Jumpscare")]
    [SerializeField] private GameObject jumpscareUI;
    [SerializeField] private AudioSource scareSound;
    [SerializeField] private float restartDelay = 2f;

    private bool hasActivated = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // ------------------------------------------------------------
    // Inicializar IA
    // ------------------------------------------------------------
    public void Initialize(Transform target)
    {
        player = target;
    }

    private void Update()
    {
        if (player == null || hasActivated) return;

        // Mover hacia el jugador
        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
        );

        // Activar animación de caminar
        if (anim != null)
            anim.SetBool("isWalking", true);

        // Voltear sprite
        if (player.position.x < transform.position.x)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);
    }

    // ------------------------------------------------------------
    // Detección del jugador + jumpscare
    // ------------------------------------------------------------
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasActivated) return;

        if (other.CompareTag("Player"))
        {
            hasActivated = true;

            // Apagar animación de caminar
            if (anim != null)
                anim.SetBool("isWalking", false);

            // Activar jumpscare
            if (jumpscareUI != null)
                jumpscareUI.SetActive(true);

            if (scareSound != null)
                scareSound.Play();

            Invoke(nameof(RestartScene), restartDelay);
        }
    }

    private void RestartScene()
    {
        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.name);
    }
}
