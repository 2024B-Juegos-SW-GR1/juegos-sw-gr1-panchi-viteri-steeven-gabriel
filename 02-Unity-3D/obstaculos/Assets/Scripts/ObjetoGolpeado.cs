using UnityEngine;

public class ObjetoGolpeado : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<MeshRenderer>().material.color = Color.black;
        Debug.Log("Objeto Golpeado");
    }
}