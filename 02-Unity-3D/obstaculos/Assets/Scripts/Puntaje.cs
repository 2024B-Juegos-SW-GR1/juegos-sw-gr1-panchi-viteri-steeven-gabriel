using UnityEngine;

public class Puntaje : MonoBehaviour
{
    private int golpes = 0;
    private void OnCollisionEnter(Collision collision)
    {
        golpes++;
        Debug.Log("El jugador ha golpeado " + golpes + " veces");
    }
}