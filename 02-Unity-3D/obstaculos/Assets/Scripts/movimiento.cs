using UnityEngine;

public class movimiento : MonoBehaviour
{
    [SerializeField] private float velocidad = 10f;
    
    [SerializeField] private float xValue = 0f;
    [SerializeField] private float yValue = 0.05f;
    [SerializeField] private float zValue = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        float movimientoX = Input.GetAxis("Horizontal") * Time.deltaTime * velocidad;
        float movimientoY = 0f;
        float movimientoZ = Input.GetAxis("Vertical") * Time.deltaTime * velocidad;
        transform.Translate(movimientoX, movimientoY, movimientoZ);
    }
}
