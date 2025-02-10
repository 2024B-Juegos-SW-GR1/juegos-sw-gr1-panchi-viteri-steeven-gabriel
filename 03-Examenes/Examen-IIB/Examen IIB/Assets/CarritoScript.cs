using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarritoScript : MonoBehaviour
{
    [SerializeField] private float steerSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpHeight = 0.2f;
    [SerializeField] private float jumpDuration = 0.4f;
    private bool isJumping = false;
    [SerializeField] private float velocidadRapido = 30f;
    [SerializeField] private float velocidadLento = 50f;
    private float originalSteerSpeed;  // Para almacenar la velocidad de dirección original
    private bool isLosingControl = false;  // Nuevo estado para perder control


    void Start()
    {
        originalSteerSpeed = steerSpeed;  // Guardar la velocidad de dirección original

    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        if (isLosingControl)
        {
            // Hacer que el control de dirección sea errático
            steerAmount *= Random.Range(-2f, 2f);  //Factor aleatorio para perder control
        }
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            StartCoroutine(Jump());
        }
    }

    IEnumerator Jump()
    {
        isJumping = true;
        // Ignore collision with the "Obstaculos" layer
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Carrito"), LayerMask.NameToLayer("Obstaculos"), true);

        float originalScale = transform.localScale.y;
        float scaleIncrement = jumpHeight / jumpDuration * Time.deltaTime;

        while (transform.localScale.y < originalScale + jumpHeight)
        {
            transform.localScale += new Vector3(0, scaleIncrement, 0);
            yield return null;
        }

        yield return new WaitForSeconds(0.1f);

        while (transform.localScale.y > originalScale)
        {
            transform.localScale -= new Vector3(0, scaleIncrement, 0);
            yield return null;
        }

        transform.localScale = new Vector3(transform.localScale.x, originalScale, transform.localScale.z);

        // Re-enable collision with the "Obstaculos" layer
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Carrito"), LayerMask.NameToLayer("Obstaculos"), false);
        isJumping = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Rapido")
        {
            Debug.Log("Ir rapido!");
            moveSpeed = velocidadRapido;
        }
        else if (other.tag == "Lento")
        {
            Debug.Log("Ir Lento!");
            moveSpeed = velocidadLento;
        }
        else if (other.tag == "Charco")
        {
            Debug.Log("¡Sobre charco de aceite! Perdiendo control...");
            StartCoroutine(LoseControl());
        }

    }
    IEnumerator LoseControl()
    {
        isLosingControl = true;
        yield return new WaitForSeconds(2f);  // Controla el carrito erráticamente por 2 segundos
        isLosingControl = false;
        Debug.Log("Control restaurado.");
    }
}
