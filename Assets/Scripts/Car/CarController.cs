using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour
{

    public WheelJoint2D frontwheel;
    public WheelJoint2D backwheel;

    JointMotor2D motorFront;

    JointMotor2D motorBack;

    public float speedF;
    public float speedB;

    public float torqueF;
    public float torqueB;


    public bool TractionFront = true;
    public bool TractionBack = true;


    public float carRotationSpeed;

    private Rigidbody2D m_Rigidbody2d { get { return GetComponent<Rigidbody2D>(); } }

    void Update()
    {

        if (Input.GetAxisRaw("Vertical") > 0)
        {


            if (TractionFront)
            {
                motorFront.motorSpeed = speedF * -1;
                motorFront.maxMotorTorque = torqueF;
                frontwheel.motor = motorFront;
            }

            if (TractionBack)
            {
                motorBack.motorSpeed = speedF * -1;
                motorBack.maxMotorTorque = torqueF;
                backwheel.motor = motorBack;

            }

        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {


            if (TractionFront)
            {
                motorFront.motorSpeed = speedB * -1;
                motorFront.maxMotorTorque = torqueB;
                frontwheel.motor = motorFront;
            }

            if (TractionBack)
            {
                motorBack.motorSpeed = speedB * -1;
                motorBack.maxMotorTorque = torqueB;
                backwheel.motor = motorBack;

            }

        }
        else
        {

            backwheel.useMotor = false;
            frontwheel.useMotor = false;

        }




        if (Input.GetAxisRaw("Horizontal") != 0)
        {

            m_Rigidbody2d.AddTorque(carRotationSpeed * Input.GetAxisRaw("Horizontal") * -1);

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Fuel")
        {
            Destroy(other.gameObject);
            Debug.Log("We got fuel");
        }
    }
}
