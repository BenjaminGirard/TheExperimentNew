using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    Rigidbody2D rBody;
    public float gasPower = 1f;
    public float turnPower = 1f;
    public float turboPower = 1f;
    float steeringAmount, speed, direction;

    // Use this for initialization
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Control
        steeringAmount = -Input.GetAxis("Horizontal");
        speed = Input.GetAxis("Vertical") * gasPower;
        direction = Mathf.Sign(Vector2.Dot(rBody.velocity, rBody.GetRelativeVector(Vector2.up)));
        rBody.rotation += steeringAmount * turnPower * rBody.velocity.magnitude * direction;
        rBody.AddRelativeForce(Vector2.up * speed);
        rBody.AddRelativeForce(-Vector2.right * rBody.velocity.magnitude * steeringAmount / 2);
        //Turbo
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0, turboPower));
        }
    }
}