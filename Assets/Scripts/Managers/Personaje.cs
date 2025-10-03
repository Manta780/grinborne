using System;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    [SerializeField] private float velocidad;
    private Rigidbody2D rig;
    private Animator anim;
    private SpriteRenderer spritePersonaje;

    [Header("Sprint")]
    [SerializeField] private float velocidadBase;
    [SerializeField] private float velocidadExtra;
    [SerializeField] private float tiempoSprint;
    private float tiempoActualSprint;
    private float tiempoSiguienteSprint;
    [SerializeField] private float tiempoEntreSprint;

    private bool puedeCorrer = true;

    private bool estaCorriendo = false;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spritePersonaje = GetComponent<SpriteRenderer>();
        tiempoActualSprint = tiempoSprint;
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
        anim.SetFloat("Camina", rig.linearVelocity.magnitude);

        // Voltea el sprite del personaje
        if (horizontal > 0)
        {
            spritePersonaje.flipX = false;
        }
        else if (horizontal < 0)
        {
            spritePersonaje.flipX = true;
        }

        //Entradas para los controles
        if (Input.GetKeyDown(KeyCode.LeftShift) && puedeCorrer)
        {
            velocidad = velocidadExtra;
            estaCorriendo = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            velocidad = velocidadBase;
            estaCorriendo = false;
        }

        //Tiempo que puede aumentar su velocidad
        if (Mathf.Abs(rig.linearVelocity.x) >= 0.1f && estaCorriendo)
        {
            if (tiempoActualSprint > 0)
            {
                tiempoActualSprint -= Time.deltaTime;
            }
            else
            {
                velocidad = velocidadBase;
                estaCorriendo = false;
                puedeCorrer = false;
                tiempoSiguienteSprint = Time.time + tiempoEntreSprint;
            }
        }

        //Recuperacion para capacidad de correr
        if (!estaCorriendo && tiempoActualSprint <= tiempoSprint && Time.time >= tiempoSiguienteSprint)
        {
            tiempoActualSprint += Time.deltaTime;
            if (tiempoActualSprint >= tiempoSprint)
            {
                puedeCorrer = true;
            }
        }
    }
}