using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewBehaviourScript:MonoBehaviour
{
    [SerializeField] private float steerSpeed = 0.1f;

    [SerializeField]private float moveSpeed = 0.01f;
    //Start is called before the first frame update
    void Start()
    { 
        //transform.Rotate(0,0,45);
    }
    
    //Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0,0,-steerAmount);
        transform.Translate(0,moveAmount,0);
    }      
        
}
