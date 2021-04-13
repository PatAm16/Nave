using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Nave : MonoBehaviour
{
    [SerializeField]
    float maxRelativeVelocity = 2f;

    [SerializeField]
    float maxRotation = 10f;



    [SerializeField]
    float thrustForce = 150f;

    [SerializeField]
    float torqueForce = 25f;




    [SerializeField]
    float combustivel = 500f;

    [SerializeField]
    float forcaCombustivel = 10f;

    [SerializeField]
    float combustivelTorque = 5f;


    [SerializeField]
    TMP_Text txtfuelValue;



    private void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {

            if (combustivel > 0)
            { 

            GetComponent<Rigidbody2D>().AddForce(thrustForce * transform.up * Time.deltaTime);
            combustivel -= combustivelTorque * Time.deltaTime;

            }

        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            if (combustivel > 0)
            { 
            GetComponent<Rigidbody2D>().AddTorque(-torqueForce * Time.deltaTime);
                combustivel -= forcaCombustivel * Time.deltaTime;

            }


        } else if ((Input.GetKey(KeyCode.RightArrow)))
        {

            if (combustivel > 0)
            GetComponent<Rigidbody2D>().AddTorque(torqueForce * Time.deltaTime);
            combustivel -= forcaCombustivel * Time.deltaTime;
        }

        txtfuelValue.text = Mathf.RoundToInt(combustivel).ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            //Bati na plataforma
            Debug.Log("Aterrei na plataforma");
            if (collision.relativeVelocity.magnitude < maxRelativeVelocity || Mathf.Abs(transform.localEulerAngles.z) > maxRotation)
            {
                Debug.Log("Mas rebentei!");
            }

        } else
        {
            Debug.Log("Bati na lua...explodi!");
        }

    }


}
