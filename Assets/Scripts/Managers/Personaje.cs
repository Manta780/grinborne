using System;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    [SerializeField] private float velocidad;
    private Rigidbody2D rig;
    private Animator anim;
    private SpriteRenderer spritePersonaje;

    private bool estaTalando = false;
    private ArbolInteractivo arbolCercano;

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

    private void Update()
    {
        // 🔹 Si presiona E y está cerca de un árbol
        if (Input.GetKeyDown(KeyCode.E) && !estaTalando && arbolCercano != null && arbolCercano.JugadorCerca)
        {
            StartCoroutine(TalarAnimacion());
        }
    }

    private void FixedUpdate()
    {
        if (!estaTalando)
            Mover();
        else
            rig.linearVelocity = Vector2.zero; // Detener movimiento al talar
    }

    private void Mover()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 direccion = new Vector2(horizontal, vertical).normalized;
        rig.linearVelocity = direccion * velocidad;

        anim.SetFloat("Camina", rig.linearVelocity.magnitude);

        if (horizontal > 0) spritePersonaje.flipX = false;
        else if (horizontal < 0) spritePersonaje.flipX = true;

        // Sprint (igual que antes)
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

        if (!estaCorriendo && tiempoActualSprint <= tiempoSprint && Time.time >= tiempoSiguienteSprint)
        {
            tiempoActualSprint += Time.deltaTime;
            if (tiempoActualSprint >= tiempoSprint)
            {
                puedeCorrer = true;
            }
        }
    }

    private System.Collections.IEnumerator TalarAnimacion()
    {
        estaTalando = true;
        anim.SetTrigger("talar");

        // Espera la duración de tu animación (ajusta el tiempo)
        yield return new WaitForSeconds(0.8f);

        estaTalando = false;
        anim.ResetTrigger("talar");
        anim.SetFloat("Camina", 0f); // volver a Idle
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Arbol"))
            arbolCercano = other.GetComponent<ArbolInteractivo>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Arbol"))
            arbolCercano = null;
    }
}
