using UnityEngine;
using System.Collections;

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
    public float fuelConsumption = 0.02f;
    public float nitroMultiplier = 4f;


    internal float m_Fuel = 1f;
    internal Rigidbody2D m_Rigidbody2d { get { return GetComponent<Rigidbody2D>(); } }
    internal float movement;

    JointMotor2D motorFront;
    JointMotor2D motorBack;
    private float currentNitroMultiplier = 1f;
    private CarManager m_CarManager { get { return GetComponentInParent<CarManager>(); } }
    private bool m_OutOfFuel = false;

    private void Start()
    {
        currentNitroMultiplier = 1f;
    }

    void Update()
    {
        if (m_Fuel < 0)
        {
            if (m_OutOfFuel) return;
            m_OutOfFuel = true;
            m_CarManager.m_OutOfFuelCoroutine = StartCoroutine(m_CarManager.OutOfFuelCoroutine());
            return;
        }

        if (movement > 0)
        {


            if (TractionFront)
            {
                motorFront.motorSpeed = speedF * currentNitroMultiplier * -1;
                motorFront.maxMotorTorque = torqueF;
                frontwheel.motor = motorFront;
            }

            if (TractionBack)
            {
                motorBack.motorSpeed = speedF * currentNitroMultiplier * -1;
                motorBack.maxMotorTorque = torqueF;
                backwheel.motor = motorBack;

            }

        }
        else if (movement < 0)
        {


            if (TractionFront)
            {
                motorFront.motorSpeed = speedB * currentNitroMultiplier * -1;
                motorFront.maxMotorTorque = torqueB;
                frontwheel.motor = motorFront;
            }

            if (TractionBack)
            {
                motorBack.motorSpeed = speedB * currentNitroMultiplier * -1;
                motorBack.maxMotorTorque = torqueB;
                backwheel.motor = motorBack;

            }

        }
        else
        {

            backwheel.useMotor = false;
            frontwheel.useMotor = false;

        }

    }

    private void FixedUpdate()
    {
        m_Fuel -= fuelConsumption * Mathf.Abs(movement) * Mathf.Pow(currentNitroMultiplier, 1.5f) * Time.fixedDeltaTime;
        GameManager.Instance.m_FuelManager.m_Image.fillAmount = m_Fuel;
    }


    internal void TurnNitroOn()
    {
        currentNitroMultiplier = nitroMultiplier;
    }

    internal void TurnNitroOff()
    {
        currentNitroMultiplier = 1f;
    }

    private void OutOfFuel()
    {
        backwheel.useMotor = false;
        frontwheel.useMotor = false;
    }

    internal void AddFuel(float value)
    {
        if (m_Fuel < 0)
            m_Fuel = 0;
        m_Fuel += value;
        if (m_Fuel > 1)
        {
            m_Fuel = 1;
        }
        m_OutOfFuel = false;
    }

    internal void CutMovement()
    {
        movement = 0;
    }
}
