using UnityEngine;

public class Personaje : MonoBehaviour
{
    [SerializeField] private float velocidad;
    private Rigidbody2D rig;
    private Animator anim;
    private SpriteRenderer spritePersonaje;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spritePersonaje = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Mover();
    }

    private void Mover()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Normaliza el vector para evitar que la velocidad sea mayor en diagonal
        Vector2 direccion = new Vector2(horizontal, vertical).normalized;

        // Aplica el movimiento al Rigidbody2D
        rig.linearVelocity = direccion * velocidad;

        // Actualiza el Animator con la magnitud de la velocidad para controlar animaciones
        anim.SetFloat("velocidad", rig.linearVelocity.magnitude);

        // Voltea el sprite del personaje
        if (horizontal > 0)
        {
            spritePersonaje.flipX = false;
        }
        else if (horizontal < 0)
        {
            spritePersonaje.flipX = true;
        }
    }
}