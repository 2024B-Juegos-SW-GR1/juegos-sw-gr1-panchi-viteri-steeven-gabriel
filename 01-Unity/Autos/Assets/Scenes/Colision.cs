using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Colision: MonoBehaviour
{
    [SerializeField] private float destroyDelay = 0.5f;
    private bool hasPackage;
    private SpriteRenderer _spriteRenderer;
    
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
            Debug.Log("GOLPEEEE");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entrando a trigger");
        if(other.tag == "Paquete" && hasPackage != true)
        {
            Debug.Log("Paquete Recogido");
            hasPackage = true;
            Destroy(other.gameObject,destroyDelay);
        }
        if(other.tag == "Cliente" && hasPackage == true)
        {
            Debug.Log("Paquete Entregado");
            hasPackage = false;

            _spriteRenderer.color = Color.green;
        }
       
    }
}
