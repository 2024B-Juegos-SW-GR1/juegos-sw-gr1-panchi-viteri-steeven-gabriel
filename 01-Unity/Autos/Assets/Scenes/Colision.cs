using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Colision: MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
            Debug.Log("GOLPEEEE");
    }
}
