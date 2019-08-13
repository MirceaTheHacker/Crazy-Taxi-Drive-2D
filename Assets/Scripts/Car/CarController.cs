using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{

    public WheelJoint2D frontwheel;
    public WheelJoint2D backwheel;
    public float speedF;
    public float speedB;
    public float torqueF;
    public float torqueB;
    public bool TractionFront = true;
    public bool TractionBack = true;
    public float carRotationSpeed;
    public float fuelConsumption = 0.02f;

    private Rigidbody2D m_Rigidbody2d { get { return GetComponent<Rigidbody2D>(); } }
    private float movement;
    private float fuel = 1f;
    JointMotor2D motorFront;
    JointMotor2D motorBack;
    private FuelManager m_FuelManager;

    private void Start()
    {
        m_FuelManager = GameManager.Instance.m_FuelManager;
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
        m_FuelManager.m_Image.fillAmount = fuel;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Fuel")
        {
            FuelCollectable fuelComp = other.gameObject.GetComponent<FuelCollectable>();
            StartCoroutine(fuelComp.OnDestroyHandler());
            fuel = 1;
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
