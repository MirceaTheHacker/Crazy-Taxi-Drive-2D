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

    public float maxFuel = 100f;
    public float fuelConsumption = 20f;

    private Rigidbody2D m_Rigidbody2d { get { return GetComponent<Rigidbody2D>(); } }
    private float movement;
    private float fuel;

    private void Awake()
    {
        fuel = maxFuel;
    }

    void Update()
    {
        if (fuel < 0)
        {
            OutOfFuel();
            return;
        }
        movement = Input.GetAxisRaw("Vertical");

        if (movement > 0)
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
        else if (movement < 0)
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




        // if (Input.GetAxisRaw("Horizontal") != 0)
        // {

        //     m_Rigidbody2d.AddTorque(carRotationSpeed * Input.GetAxisRaw("Horizontal") * -1);

        // }
    }

    private void FixedUpdate()
    {
        fuel -= fuelConsumption * Mathf.Abs(movement) * Time.fixedDeltaTime;
        UIMainGasBar.instance.SetValue(fuel);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Fuel")
        {
            Fuel fuelComp = other.gameObject.GetComponent<Fuel>();
            StartCoroutine(fuelComp.OnDestroyHandler());
            fuel = maxFuel;
        }
    }

    private void OutOfFuel()
    {
        motorFront.motorSpeed = 0;
        motorBack.motorSpeed = 0;
        frontwheel.motor = motorFront;
        backwheel.motor = motorBack;

    }
}
