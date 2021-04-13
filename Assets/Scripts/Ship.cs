using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Ship : MonoBehaviour
{

    [SerializeField] float turnVelocity = 1f;
    [SerializeField] float fuel = 500f;
    [SerializeField] float thurstVelocity = 1f;
    [SerializeField] float fuelBurn = 10f;
    [SerializeField] float fuelBurnTorque = 5f;

    [SerializeField] float velocityThreshold = 10f;
    [SerializeField] float rotationThreshold = 10f;

    [SerializeField] TextAlignment txtFuelAmount;
    Rigidbody2D rb;


    //Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    //Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            if(fuel > 0)
            {
                rb.AddTorque(turnVelocity * Time.deltaTime);
                fuel -= fuelBurnTorque * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if(fuel > 0)
            {
                rb.AddTorque(-turnVelocity * Time.deltaTime);
                fuel -= fuelBurnTorque * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            if(fuelBurn > 0)
            {
                rb.AddForce(transform.up * turnVelocity * Time.deltaTime);
                fuel-= fuelBurn * Time.deltaTime;
            }
        }


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            if(collision.relativeVelocity.magnitude >= velocityThreshold || Mathf.Abs(transform.localEulerAngles.z)>=rotationThreshold)
            {
                Debug.Log("Game Over");
            }
        }else
        {
            Debug.Log("Game Over");
        }

    }
}




