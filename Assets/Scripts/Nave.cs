using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    [SerializeField]
    float maxRelativeVelocity = 10f;

    [SerializeField]
    float thrustForce = 150f;

    [SerializeField]
    float torqueForce = 25f;

    private void Start()
    {
        
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            GetComponent<Rigidbody2D>().AddForce(thrustForce * Vector2.up * Time.deltaTime);

        } else if(Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody2D>().AddTorque(-torqueForce * Time.deltaTime);

        } else if ((Input.GetKey(KeyCode.RightArrow)))
        {
            GetComponent<Rigidbody2D>().AddTorque(torqueForce * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            //Bati na plataforma
            Debug.Log("Aterrei na plataforma");
        
            if (collision.relativeVelocity.magnitude < maxRelativeVelocity)
            {
                Debug.Log("Mas rebentei!");
            }

        } else
        {
            Debug.Log("Bati na lua...explodi!");
        }

    }


}
