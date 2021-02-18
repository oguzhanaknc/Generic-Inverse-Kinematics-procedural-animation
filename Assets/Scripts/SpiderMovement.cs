using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMovement : MonoBehaviour
{
    public float speed = 6f;
    public float rotationSpeed = 80f;
  
    


    // Update is called once per frame
    void Update()
    {
        MyInputs();
        
    }

    void MyInputs()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 12f;
        }
        else
        {
            speed = 6f;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0.0f, -rotationSpeed * Time.deltaTime, 0.0f);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0.0f, rotationSpeed * Time.deltaTime, 0.0f);
        }
        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.F) && transform.position.y <= 5.1f)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.C) && transform.position.y >= 2.6f)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }


    }
 
    

}

